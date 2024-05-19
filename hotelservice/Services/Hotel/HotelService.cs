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
        var hotel = new Models.Hotel
        {
            Id = Guid.NewGuid(),
            Name = request.Hotel.Name,
            City = request.Hotel.City,
            Country = request.Hotel.Country,
            Street = request.Hotel.Street,
            FoodPricePerPerson = request.Hotel.FoodPricePerPerson,
            Discounts = new List<Discount>(),
        };
        
        var Rooms = request.Hotel.Rooms.Select(rc => new Room
        {
            Id = Guid.NewGuid(),
            HotelId = hotel.Id,
            Size = rc.Size,
            Price = rc.Price,
            Count = rc.Count,
            Bookings = new List<RoomReservation>()
        }).ToList();


        hotel.Rooms = Rooms;

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

    public HotelBookRoomsResponse BookRooms(HotelBookRoomsRequest request)
    {
        return new HotelBookRoomsResponse(new List<RoomReservationDto>
        {
            new RoomReservationDto
            {
                Id = Guid.NewGuid(),
                Size = 2,
                Start = request.BookingDetails.Start,
            }
        });
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
    
    private Dictionary<int, int> GetRoomCounts(List<Room> rooms)
    {
        var roomCounts = new Dictionary<int, int>();
        foreach (var room in rooms)
        {
            if (roomCounts.ContainsKey(room.Size))
            {
                roomCounts[room.Size] += room.Count;
            }
            else
            {
                roomCounts[room.Size] = room.Count;
            }
        }
        return roomCounts;
    }

    private List<Dictionary<int, int>> GetConfigs(List<int> rooms, Dictionary<int, int> numRooms, int numPeople)
    {
        if (rooms.Count == 1)
        {
            var configs = new List<Dictionary<int, int>>();
            for (int i = 0; i <= numRooms[rooms[0]]; i++)
            {
                if (rooms[0] * i >= numPeople)
                {
                    configs.Add(new Dictionary<int, int> { { rooms[0], i } });
                }
            }
            return configs;
        }

        var allConfigs = new List<Dictionary<int, int>>();
        for (int i = 0; i <= numRooms[rooms[0]]; i++)
        {
            var subConfigs = GetConfigs(rooms.Skip(1).ToList(), numRooms, numPeople - i * rooms[0]);
            foreach (var subConfig in subConfigs)
            {
                var newConfig = new Dictionary<int, int> { { rooms[0], i } };
                foreach (var kvp in subConfig)
                {
                    if (newConfig.ContainsKey(kvp.Key))
                    {
                        newConfig[kvp.Key] += kvp.Value;
                    }
                    else
                    {
                        newConfig[kvp.Key] = kvp.Value;
                    }
                }
                allConfigs.Add(newConfig);
            }
        }
        return allConfigs;
    }

    public bool IsAvailable(DateTime start, DateTime end, int minLength, int numPeople)
    {
        var roomCounts = GetRoomCounts(_dbContext.Rooms.ToList());
        var bestConfigs = new Dictionary<int, List<Dictionary<int, int>>>();

        for (int i = 1; i <= 10; i++)
        {
            bestConfigs[i] = GetConfigs(roomCounts.Keys.ToList(), roomCounts, i);
        }

        foreach (var config in bestConfigs[numPeople])
        {
            bool allAvailable = true;
            foreach (var kvp in config)
            {
                int roomSize = kvp.Key;
                int roomsRequired = kvp.Value;
                if (roomsRequired == 0) continue;

                var room = _dbContext.Rooms.FirstOrDefault(r => r.Size == roomSize);
                if (room == null) continue;

                var availability = GetAvailability(room, start, end, minLength, roomsRequired);
                if (!availability.Any())
                {
                    allAvailable = false;
                    break;
                }
            }
            if (allAvailable)
            {
                return true;
            }
        }
        return false;
    }

    private List<Tuple<DateTime, DateTime>> GetAvailability(Room room, DateTime rangeStart, DateTime rangeEnd, int minLength, int nRooms)
    {
        if ((rangeEnd - rangeStart).TotalDays < minLength || (rangeEnd - rangeStart).TotalDays >= 31)
        {
            throw new ArgumentException("Invalid range: minLength should be less than the range duration and the range should be less than 31 days.");
        }

        var rangeDays = (int)(rangeEnd - rangeStart).TotalDays + 1;
        var freeRooms = Enumerable.Repeat(room.Count, rangeDays).ToArray();

        foreach (var reservation in room.Bookings)
        {
            if (reservation.CancelationDate.HasValue) continue;
            var resStart = reservation.Start > rangeStart ? reservation.Start : rangeStart;
            var resEnd = reservation.End < rangeEnd ? reservation.End : rangeEnd;

            if (resStart <= resEnd)
            {
                for (int i = 0; i <= (resEnd - resStart).TotalDays; i++)
                {
                    freeRooms[(resStart - rangeStart).Days + i] -= reservation.RoomsReserved;
                }
            }
        }

        var results = new List<Tuple<DateTime, DateTime>>();
        int idx = 0;

        while (idx <= rangeDays - minLength)
        {
            if (freeRooms.Skip(idx).Take(minLength).Any(fr => fr < nRooms))
            {
                idx++;
                continue;
            }

            int endIdx = idx + minLength;
            while (endIdx < rangeDays && freeRooms[endIdx] >= nRooms)
            {
                endIdx++;
            }

            results.Add(Tuple.Create(rangeStart.AddDays(idx), rangeStart.AddDays(endIdx - 1)));
            idx = endIdx;
        }

        return results;
    }
}

