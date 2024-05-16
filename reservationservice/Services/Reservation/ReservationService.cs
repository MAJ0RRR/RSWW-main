using System;
using System.Collections.Generic;using contracts;
using contracts.Dtos;
using reservationservice.Persistence;

namespace reservationservice.Services.Reservation
{
    public class ReservationService
    {
        private readonly ReservationDbContext _dbContext;

        public ReservationService(ReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public GetAvailableDestinationsResponse GetAvailableDestinations(GetAvailableDestinationsRequest GetAvailableDestinationsRequest)
        {
            var destinations = new Dictionary<string, List<string>>
            {
                { "Poland", new List<string> { "Warsaw", "Krakow" } },
                { "Germany", new List<string> { "Berlin", "Munich" } }
            };
            return new GetAvailableDestinationsResponse(destinations);
        }

        public GetReservationsResponse GetReservations(GetReservationsRequest getReservationsRequest)
        {
            var reservations = new List<ReservationDto>
            {
                new ReservationDto
                {
                    Id = Guid.NewGuid(),
                    UserId = getReservationsRequest.UserId,
                    NumAdults = 2,
                    NumUnder3 = 0,
                    NumUnder10 = 1,
                    NumUnder18 = 0,
                    ToDestinationTransport = Guid.NewGuid(),
                    HotelRoomReservations = new List<Guid> { Guid.NewGuid() },
                    FromDestinationTransport = Guid.NewGuid(),
                    Finalized = true,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddDays(7),
                    Price = 1500.00m,
                    ToCity = "Berlin",
                    FromCity = "Warsaw",
                    TransportType = "Train",
                    ReservedUntil = DateTime.UtcNow.AddMonths(1)
                }
            };
            return new GetReservationsResponse(reservations);
        }

        public GetSingleReservationResponse GetSingleReservation(GetSingleReservationRequest getSingleReservationRequest)
        {
            var reservation = new ReservationDto
            {
                Id = getSingleReservationRequest.ReservationId,
                UserId = Guid.NewGuid(),
                NumAdults = 2,
                NumUnder3 = 0,
                NumUnder10 = 1,
                NumUnder18 = 0,
                ToDestinationTransport = Guid.NewGuid(),
                HotelRoomReservations = new List<Guid> { Guid.NewGuid() },
                FromDestinationTransport = Guid.NewGuid(),
                Finalized = true,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(7),
                Price = 1500.00m,
                ToCity = "Berlin",
                FromCity = "Warsaw",
                TransportType = "Train",
                ReservedUntil = DateTime.UtcNow.AddMonths(1)
            };
            return new GetSingleReservationResponse(reservation);
        }

        public BuyResponse Buy(BuyRequest buyRequest)
        {
            return new BuyResponse(true);
        }

        public GetPopularOffersResponse GetPopularOffers(GetPopularOffersRequest GetPopularOffersRequest)
        {
            var offers = new Dictionary<string, Dictionary<string, List<string>>>
            {
                {
                    "Poland", new Dictionary<string, List<string>>
                    {
                        {
                            "Warsaw", new List<string> { "HotelA1", "HotelA2", "HotelA3" }
                        },
                        {
                            "Cracow", new List<string> { "HotelA4", "HotelA5" }
                        }
                    }
                },
                {
                    "Germany", new Dictionary<string, List<string>>
                    {
                        {
                            "Berlin", new List<string> { "HotelB1" }
                        }
                    }
                }
            };
            
            return new GetPopularOffersResponse(offers);
        }

        public CreateReservationResponse CreateReservation(CreateReservationRequest createReservationRequest)
        {
            var reservation = new ReservationDto
            {
                Id = Guid.NewGuid(),
                UserId = createReservationRequest.Reservation.UserId,
                NumAdults = createReservationRequest.Reservation.NumAdults,
                NumUnder3 = createReservationRequest.Reservation.NumUnder3,
                NumUnder10 = createReservationRequest.Reservation.NumUnder10,
                NumUnder18 = createReservationRequest.Reservation.NumUnder18,
                ToDestinationTransport = createReservationRequest.Reservation.ToDestinationTransport,
                HotelRoomReservations = new List<Guid> { Guid.NewGuid() },
                FromDestinationTransport = createReservationRequest.Reservation.FromDestinationTransport,
                Finalized = true,
                StartDate = createReservationRequest.Reservation.StartDate,
                EndDate = createReservationRequest.Reservation.EndDate,
                Price = 2000.00m,
                ToCity = "Berlin",
                FromCity = "Warsaw",
                TransportType = "Train",
                ReservedUntil = DateTime.UtcNow.AddMonths(1)
            };
            return new CreateReservationResponse(reservation);
        }

        public GetAvailableToursResponse GetAvailableTours(GetAvailableToursRequest getAvailableToursRequest)
        {
            var tours = new List<TourDto>
            {
                new TourDto
                {
                    ToDestinationTransportOption = Guid.NewGuid(),
                    Hotel = Guid.NewGuid(),
                    FromDestinationTransportOption = Guid.NewGuid(),
                    TransportType = "Bus",
                    FromCity = "Warsaw",
                    ToCity = "Berlin",
                    StartDate = DateTime.UtcNow,
                    DurationDays = 5
                }
            };
            return new GetAvailableToursResponse(tours);
        }

        public ReservationGetTransportOptionResponse ReservationGetTransportOption(ReservationGetTransportOptionRequest getTransportOptionRequest)
        {
            var transportOption = new TransportOptionDto
            {
                Id = getTransportOptionRequest.Id,
                Discounts = new List<DiscountDto> { new DiscountDto { Id = Guid.NewGuid(), Value = 10, Start = DateTime.UtcNow, End = DateTime.UtcNow.AddDays(30) } },
                SeatsAvailable = 50,
                From = new AddressDto { City = "Warsaw", Country = "Poland", Street = "Main St" },
                To = new AddressDto { City = "Berlin", Country = "Germany", Street = "Second St" },
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow.AddHours(6),
                PriceAdult = 100.00m,
                PriceUnder3 = 50.00m,
                PriceUnder10 = 75.00m,
                PriceUnder18 = 80.00m,
                Type = "Bus"
            };
            return new ReservationGetTransportOptionResponse(transportOption);
        }

        public ReservationGetTransportOptionsResponse ReservationGetTransportOptions(ReservationGetTransportOptionsRequest getTransportOptionsRequest)
        {
            var transportOptions = new List<TransportOptionDto>
            {
                new TransportOptionDto
                {
                    Id = Guid.NewGuid(),
                    Discounts = new List<DiscountDto> { new DiscountDto { Id = Guid.NewGuid(), Value = 10, Start = DateTime.UtcNow, End = DateTime.UtcNow.AddDays(30) } },
                    SeatsAvailable = 50,
                    From = new AddressDto { City = "Warsaw", Country = "Poland", Street = "Main St" },
                    To = new AddressDto { City = "Berlin", Country = "Germany", Street = "Second St" },
                    Start = DateTime.UtcNow,
                    End = DateTime.UtcNow.AddHours(6),
                    PriceAdult = 100.00m,
                    PriceUnder3 = 50.00m,
                    PriceUnder10 = 75.00m,
                    PriceUnder18 = 80.00m,
                    Type = "Bus"
                }
            };
            return new ReservationGetTransportOptionsResponse(transportOptions);
        }

        public ReservationGetHotelResponse ReservationGetHotel(ReservationGetHotelRequest getHotelRequest)
        {
            var hotel = new HotelDto
            {
                Id = getHotelRequest.Id,
                Name = "Grand Hotel",
                Rooms = new Dictionary<int, Tuple<decimal, int>>
                {
                    { 1, Tuple.Create(100.00m, 10) },
                    { 2, Tuple.Create(150.00m, 5) }
                },
                Bookings = new List<RoomReservationDto>
                {
                    new RoomReservationDto
                    {
                        Id = Guid.NewGuid(),
                        Size = 1,
                        Start = DateTime.UtcNow,
                        End = DateTime.UtcNow.AddDays(7)
                    }
                },
                Address = new AddressDto { City = "Berlin", Country = "Germany", Street = "Main St" },
                Discounts = new List<DiscountDto> { new DiscountDto { Id = Guid.NewGuid(), Value = 15, Start = DateTime.UtcNow, End = DateTime.UtcNow.AddDays(10) } },
                FoodPricePerPerson = 20.00m
            };
            return new ReservationGetHotelResponse(hotel);
        }

        public ReservationGetHotelsResponse ReservationGetHotels(ReservationGetHotelsRequest getHotelsRequest)
        {
            var hotels = new List<HotelDto>
            {
                new HotelDto
                {
                    Id = Guid.NewGuid(),
                    Name = "Grand Hotel",
                    Rooms = new Dictionary<int, Tuple<decimal, int>>
                    {
                        { 1, Tuple.Create(100.00m, 10) },
                        { 2, Tuple.Create(150.00m, 5) }
                    },
                    Bookings = new List<RoomReservationDto>
                    {
                        new RoomReservationDto
                        {
                            Id = Guid.NewGuid(),
                            Size = 1,
                            Start = DateTime.UtcNow,
                            End = DateTime.UtcNow.AddDays(7)
                        }
                    },
                    Address = new AddressDto { City = "Berlin", Country = "Germany", Street = "Main St" },
                    Discounts = new List<DiscountDto> { new DiscountDto { Id = Guid.NewGuid(), Value = 15, Start = DateTime.UtcNow, End = DateTime.UtcNow.AddDays(10) } },
                    FoodPricePerPerson = 20.00m
                }
            };
            return new ReservationGetHotelsResponse(hotels);
        }

        public GetAvailableRoomsResponse GetAvailableRooms(GetAvailableRoomsRequest getAvailableRoomsRequest)
        {
            var rooms = new Dictionary<int, int>
            {
                { 1, 10 },
                { 2, 5 }
            };
            return new GetAvailableRoomsResponse(rooms);
        }
    }
}
