using contracts;
using contracts.Dtos;
using hotelservice.Models;
using Microsoft.EntityFrameworkCore;


namespace hotelservice.Services.Hotel;

public class HotelService
{
    private readonly HotelDbContext _dbContext;

    public HotelService(HotelDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AddHotelResponse> AddHotel(AddHotelRequest request)
    {
        var hotelGuid = Guid.NewGuid();
        
        var rooms = request.Hotel.Rooms.Select(rc => new Room
        {
            Id = Guid.NewGuid(),
            HotelId = hotelGuid,
            Size = rc.Size,
            Price = rc.Price,
            Count = rc.Count,
            Bookings = new List<RoomReservation>()
        }).ToList();
        
        var hotel = new Models.Hotel
        {
            Id = hotelGuid,
            Name = request.Hotel.Name,
            City = request.Hotel.City,
            Country = request.Hotel.Country,
            Street = request.Hotel.Street,
            FoodPricePerPerson = request.Hotel.FoodPricePerPerson,
            Discounts = new List<Discount>(),
            Rooms = rooms,
            GuestConfigurations = new Dictionary<int, List<Dictionary<int, int>>>()
        };

        var roomCounts = hotel.GetRoomCounts();

        for (int i = 1; i <= 10; i++)
        {
            hotel.GuestConfigurations[i] = GetConfigs(roomCounts.Keys.ToList(), roomCounts, i);
        }
        
        await _dbContext.Hotels.AddAsync(hotel);
        await _dbContext.SaveChangesAsync();

        return new AddHotelResponse(hotel.ToDto());
    }

    public async Task<HotelSearchResponse> SearchHotels(HotelSearchRequest request)
    {
        var searchCriteria = request.SearchCriteria;
        var hotelsQuery = _dbContext.Hotels
            .Include(h => h.Discounts)
            .Include(h => h.Rooms)
                .ThenInclude(r => r.Bookings)
            .AsQueryable();

        if (!string.IsNullOrEmpty(searchCriteria.City))
        {
            hotelsQuery = hotelsQuery.Where(h => h.City == searchCriteria.City);
        }

        if (!string.IsNullOrEmpty(searchCriteria.Country))
        {
            hotelsQuery = hotelsQuery.Where(h => h.Country == searchCriteria.Country);
        }

        if (searchCriteria.MinimumGuests.HasValue)
        {
            hotelsQuery = hotelsQuery.Where(h =>
                h.Rooms.Sum(r => r.Count * r.Size) >= searchCriteria.MinimumGuests.Value);
        }

        if (searchCriteria.MinStart.HasValue || searchCriteria.MaxEnd.HasValue)
        {
            hotelsQuery = hotelsQuery.Where(h =>
                h.Rooms.Any(r =>
                    r.Bookings.Any(b =>
                        (!searchCriteria.MinStart.HasValue || b.Start >= searchCriteria.MinStart.Value) &&
                        (!searchCriteria.MaxEnd.HasValue || b.End <= searchCriteria.MaxEnd.Value))));
        }

        if (searchCriteria.MinDuration.HasValue || searchCriteria.MaxDuration.HasValue)
        {
            hotelsQuery = hotelsQuery.Where(h =>
                h.Rooms.Any(r =>
                    r.Bookings.Any(b =>
                        (!searchCriteria.MinDuration.HasValue || EF.Functions.DateDiffDay(b.Start, b.End) >= searchCriteria.MinDuration.Value) &&
                        (!searchCriteria.MaxDuration.HasValue || EF.Functions.DateDiffDay(b.Start, b.End) <= searchCriteria.MaxDuration.Value))));
        }

        var hotels = await hotelsQuery.ToListAsync();
        var hotelsDto = hotels.Select(hotel => hotel.ToDto()).ToList();

        return new HotelSearchResponse(hotelsDto);
    }

    public async Task<GetHotelsResponse> GetHotels(GetHotelsRequest request)
    {
        var hotels = await _dbContext.Hotels
            .Include(h => h.Discounts)
            .Include(h => h.Rooms)
            .ThenInclude(r => r.Bookings)
            .ToListAsync();
        
        var hotelsDto = hotels.Select(hotel => hotel.ToDto()).ToList();

        return new GetHotelsResponse(hotelsDto);
    }

    public async Task<GetHotelResponse> GetHotel(GetHotelRequest request)
    {
        var hotel = await _dbContext.Hotels
            .Include(h => h.Discounts)
            .Include(h => h.Rooms)
            .ThenInclude(r => r.Bookings)
            .FirstOrDefaultAsync(h => h.Id == request.Id);

        if (hotel == null)
        {
            return null;
        }

        var hotelDto = hotel.ToDto();

        return new GetHotelResponse(hotelDto);
    }

    public async Task<IEnumerable<RoomReservationDto>> BookRooms(HotelBookRoomsRequest request)
    {
        var hotel = await _dbContext.Hotels
            .Include(h => h.Rooms)
            .ThenInclude(r => r.Bookings)
            .FirstOrDefaultAsync(h => h.Id == request.BookingDetails.Id);

        if (hotel == null)
        {
            return Enumerable.Empty<RoomReservationDto>();
        }

        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            var roomReservationDtos = new List<RoomReservationDto>();
            var startDate = request.BookingDetails.Start;
            var endDate = request.BookingDetails.Start.AddDays(request.BookingDetails.NumberOfNights);

            foreach (var size in request.BookingDetails.Sizes)
            {
                int roomSize = size.Key;
                int nRooms = size.Value;

                var room = hotel.Rooms.FirstOrDefault(r => r.Size == roomSize);
                if (room == null)
                {
                    // Room of requested size does not exist in the hotel
                    throw new InvalidOperationException("Requested room size not available");
                }

                if (!room.GetAvailability(startDate, endDate, nRooms).Any())
                {
                    // Not enough rooms available, rollback the transaction
                    throw new InvalidOperationException("Not enough rooms available for requested size");
                }
                
                var reservation = new RoomReservation
                {
                    Id = Guid.NewGuid(),
                    RoomsId = room.Id,
                    RoomsReserved = nRooms,
                    Start = startDate,
                    End = endDate,
                };

                _dbContext.RoomReservations.Add(reservation);
                roomReservationDtos.Add(reservation.ToDto());
            }

            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
            return roomReservationDtos;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            return Enumerable.Empty<RoomReservationDto>();
        }
    }

    public HotelGetAvailableRoomsResponse GetAvailableRooms(HotelGetAvailableRoomsRequest request)
    {
        return new HotelGetAvailableRoomsResponse(new RoomAvailabilityDto {StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddDays(1), Rooms = new List<RoomsCount>(){new RoomsCount{Price = 10, Size = 2, Count = 1}}});
    }

    public HotelAddDiscountResponse AddDiscount(HotelAddDiscountRequest request)
    {
        return new HotelAddDiscountResponse();
    }

    public HotelCancelBookRoomsResponse CancelBookRooms(HotelCancelBookRoomsRequest request)
    {
        return new HotelCancelBookRoomsResponse();
    }

    private List<Dictionary<int, int>> GetConfigs(List<int> rooms, Dictionary<int, int> numRooms, int numPeople)
    {
        var configs = new List<Dictionary<int, int>>();
        
        if (rooms.Count == 1)
        {
            for (int i = 0; i <= numRooms[rooms[0]]; i++)
            {
                if (rooms[0] * i >= numPeople)
                {
                    configs.Add(new Dictionary<int, int> { { rooms[0], i } });
                }
            }
            return configs;
        }

        var existingRecursiveConfigs = new List<Dictionary<int, int>>();

        for (int i = 0; i <= numRooms[rooms[0]]; i++)
        {
            var recursiveConfigs = GetConfigs(rooms.Skip(1).ToList(), numRooms, numPeople - i * rooms[0]);
            foreach (var rc in recursiveConfigs)
            {
                if (!existingRecursiveConfigs.Any(c => c.SequenceEqual(rc)))
                {
                    existingRecursiveConfigs.Add(rc);
                    var newConfig = new Dictionary<int, int> { { rooms[0], i } };
                    foreach (var kvp in rc)
                    {
                        newConfig[kvp.Key] = kvp.Value;
                    }
                    configs.Add(newConfig);
                }
            }
        }

        return configs;
    }
}

