using System;
using System.Collections.Generic;using contracts;
using contracts.Dtos;
using MassTransit;
using reservationservice.Persistence;

namespace reservationservice.Services.Reservation;

    public class ReservationService
    {
        private readonly ReservationDbContext _dbContext;
        private readonly IRequestClient<GetTransportOptionRequest> _getTransportOptionClient;
        private readonly IRequestClient<GetTransportOptionsRequest> _getTransportOptionsClient;
        private readonly IRequestClient<GetHotelRequest> _getHotelClient;
        private readonly IRequestClient<GetHotelsRequest> _getHotelsClient;
        private readonly IRequestClient<HotelGetAvailableRoomsRequest> _getAvailableRoomsClient;
        private readonly IRequestClient<GetPopularDestinationsRequest> _getPopularDestinationsClient;
        private readonly ILogger<ReservationService> _logger;

        public ReservationService(ReservationDbContext dbContext,
            IRequestClient<GetTransportOptionRequest> getTransportOptionClient,
            IRequestClient<GetTransportOptionsRequest> getTransportOptionsClient,
            IRequestClient<GetHotelRequest> getHotelClient,
            IRequestClient<GetHotelsRequest> getHotelsClient,
            IRequestClient<HotelGetAvailableRoomsRequest> getAvailableRoomsClient,
            IRequestClient<GetPopularDestinationsRequest> getPopularDestinationsClient,
            ILogger<ReservationService> logger)
        {
            _dbContext = dbContext;
            _getTransportOptionClient = getTransportOptionClient;
            _getTransportOptionsClient = getTransportOptionsClient;
            _getHotelClient = getHotelClient;
            _getHotelsClient = getHotelsClient;
            _getAvailableRoomsClient = getAvailableRoomsClient;
            _getPopularDestinationsClient = getPopularDestinationsClient;
            _logger = logger;
        }

        public async Task<GetAvailableDestinationsResponse> GetAvailableDestinations(
            GetAvailableDestinationsRequest GetAvailableDestinationsRequest)
        {
            // Fetch all hotels
            var hotelsResponse = await _getHotelsClient.GetResponse<GetHotelsResponse>(new GetHotelsRequest());

            // Create a dictionary of Country -> List of Cities from the hotels
            var hotelDestinations = hotelsResponse.Message.Hotels
                .GroupBy(hotel => hotel.Address.Country)
                .ToDictionary(
                    group => group.Key,
                    group => group.Select(hotel => hotel.Address.City).Distinct().ToList()
                );

            // Fetch all transport options
            var transportOptionsResponse = await _getTransportOptionsClient.GetResponse<GetTransportOptionsResponse>(new GetTransportOptionsRequest());

            // Create a dictionary of Country -> List of Cities from the transport options
            var transportDestinations = transportOptionsResponse.Message.TransportOptions
                .GroupBy(option => option.To.Country)
                .ToDictionary(
                    group => group.Key,
                    group => group.Select(option => option.To.City).Distinct().ToList()
                );

            // Find common destinations in both dictionaries
            var commonDestinations = hotelDestinations
                .Where(hotelCountry => transportDestinations.ContainsKey(hotelCountry.Key))
                .ToDictionary(
                    hotelCountry => hotelCountry.Key,
                    hotelCountry => hotelCountry.Value.Intersect(transportDestinations[hotelCountry.Key]).ToList()
                );

            return new GetAvailableDestinationsResponse(commonDestinations);
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

        public GetSingleReservationResponse GetSingleReservation(
            GetSingleReservationRequest getSingleReservationRequest)
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

        public async Task<GetPopularOffersResponse> GetPopularOffers(GetPopularOffersRequest GetPopularOffersRequest)
        {
            var destinationsResponse = await _getPopularDestinationsClient.GetResponse<GetPopularDestinationsResponse>(
                new GetPopularDestinationsRequest());
            
            var offers = new Dictionary<string, Dictionary<string, List<string>>>();
            
            // iterate over destinationsResponse, extract To Address from each one and save City + Country
            foreach (var transport in destinationsResponse.Message.TransportOptions)
            {
                var country = transport.To.Country;
                var city = transport.To.City;

                if (!offers.ContainsKey(country))
                {
                    offers[country] = new Dictionary<string, List<string>>();
                }

                if (!offers[country].ContainsKey(city))
                {
                    offers[country][city] = new List<string>();
                }
            }
            // Get all hotels
            var hotelsResponse = await _getHotelsClient.GetResponse<GetHotelsResponse>(new GetHotelsRequest());
            
            // For each City + Country combination save list of hotels in this location
            hotelsResponse.Message.Hotels
                .Where(hotel => offers.ContainsKey(hotel.Address.Country) && offers[hotel.Address.Country].ContainsKey(hotel.Address.City))
                .ToList()
                .ForEach(hotel => offers[hotel.Address.Country][hotel.Address.City].Add(hotel.Name));

            return new GetPopularOffersResponse(offers);
        }

        public CreateReservationResponse CreateReservation(CreateReservationRequest createReservationRequest)
        {
            /*
             * public Guid UserId { get; set; }
             * public int NumAdults { get; set; }
             * public int NumUnder3 { get; set; }
             * public int NumUnder10 { get; set; }
             * public int NumUnder18 { get; set; }
             * public Guid ToDestinationTransport { get; set; }
             * public Guid Hotel { get; set; }
             * public Dictionary<int, int> Rooms { get; set; }
             * public Guid FromDestinationTransport { get; set; }
             * public bool WithFood { get; set; }
             * public DateTime StartDate { get; set; }
             * public DateTime EndDate { get; set; }
             */
            // Implement the saga:
            // 1. Try to book hotel with given number of rooms
            // 2. Try to reserve ToDestinationTransport 
            // 3. Try to reserve FromDestinationTransport
            // 4. If all above were positive, create Reservation object and add it to database
            //    otherwise, revert the transactions and return error code
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

        public async Task<ReservationGetTransportOptionResponse> ReservationGetTransportOption(
            ReservationGetTransportOptionRequest getTransportOptionRequest)
        {
            var response =
                await _getTransportOptionClient.GetResponse<GetTransportOptionResponse>(
                    new GetTransportOptionRequest(getTransportOptionRequest.Id));
            return new ReservationGetTransportOptionResponse(response.Message.TransportOption);
        }

        public async Task<ReservationGetTransportOptionsResponse> ReservationGetTransportOptions(
            ReservationGetTransportOptionsRequest getTransportOptionsRequest)
        {
            var response =
                await _getTransportOptionsClient.GetResponse<GetTransportOptionsResponse>(
                    new GetTransportOptionsRequest());
            return new ReservationGetTransportOptionsResponse(response.Message.TransportOptions);
        }

        public async Task<ReservationGetHotelResponse> ReservationGetHotel(ReservationGetHotelRequest getHotelRequest)
        {
            var response = await _getHotelClient.GetResponse<GetHotelResponse>(new GetHotelRequest(getHotelRequest.Id));
            return new ReservationGetHotelResponse(response.Message.Hotel);
        }

        public async Task<ReservationGetHotelsResponse> ReservationGetHotels(ReservationGetHotelsRequest getHotelsRequest)
        {
            var response = await _getHotelsClient.GetResponse<GetHotelsResponse>(new GetHotelsRequest());
            return new ReservationGetHotelsResponse(response.Message.Hotels);
        }

        public async Task<GetAvailableRoomsResponse> GetAvailableRooms(
            GetAvailableRoomsRequest getAvailableRoomsRequest)
        {
            var response = await _getAvailableRoomsClient.GetResponse<HotelGetAvailableRoomsResponse>(
                new HotelGetAvailableRoomsRequest(getAvailableRoomsRequest.HotelId, getAvailableRoomsRequest.Start,
                    getAvailableRoomsRequest.End));
            return new GetAvailableRoomsResponse(response.Message.Rooms);
        }
    }
        