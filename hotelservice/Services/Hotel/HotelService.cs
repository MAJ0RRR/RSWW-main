﻿using contracts;
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
        var rooms = new List<Room>(); 
        foreach (var roomDto in request.Hotel.Rooms)
        {
            var room = new Room
            {
                Id = Guid.NewGuid(),
                Size = roomDto.Key,
                Price = roomDto.Value.Item1,
                Count = roomDto.Value.Item2,
                Bookings = new List<RoomReservation>()
            };
            rooms.Add(room);
        }
            
        var hotel = new Models.Hotel
        {

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

    }

    public async Task<GetHotelsResponse> GetHotels(GetHotelsRequest request)
    {

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
                NumberOfNights = request.BookingDetails.NumberOfNights
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
    
}

