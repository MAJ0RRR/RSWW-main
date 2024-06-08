using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hotelservice.Migrations
{
    public partial class HotelServicePopular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FoodPricePerPerson = table.Column<decimal>(type: "numeric", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PopularHotels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Counter = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopularHotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HotelId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discounts_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HotelId = table.Column<Guid>(type: "uuid", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomReservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomsId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomsReserved = table.Column<int>(type: "integer", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CancelationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomReservations_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "City", "Country", "FoodPricePerPerson", "Name", "Street" },
                values: new object[,]
                {
                    { new Guid("07742431-3af8-4f28-958d-1376cf478c7f"), "Alam", "egipt", 83m, "Bliss Nada Beach Resort", "Sharia Tahrir" },
                    { new Guid("18d18682-f9c6-44d2-8d00-c763d2923cc8"), "Riwiera", "chorwacja", 116m, "Gradac", "Kapucinska ulica" },
                    { new Guid("1abf8993-caa1-415a-b5bd-22edb70e27c7"), "Durres", "albania", 94m, "Mel Holidays", "Bulevardi Bajram Curri" },
                    { new Guid("2b0c4a0b-c5b4-4383-9610-97323a80430c"), "Alam", "egipt", 89m, "MG Alexander The Great", "Sharia Gamal Abdel Nasser" },
                    { new Guid("30708e68-aa83-489b-aeeb-12d03441fe78"), "Riwiera", "chorwacja", 88m, "Nano", "Maksimirska ulica" },
                    { new Guid("4333746e-41a6-420d-b54d-2d8659ad59cf"), "Alam", "egipt", 80m, "Protels Crystal Beach Resort", "Sharia Tahrir" },
                    { new Guid("4357c674-758c-40b9-a37a-862cf404c9c8"), "Turecka", "turcja", 114m, "Kimeros Park Holiday Village", "Bağdat Caddesi" },
                    { new Guid("540b1e5e-f3f8-4071-b755-78db5b80ceca"), "Vlora", "albania", 90m, "Monte Carlo Vlora", "Rruga 28 Nentori" },
                    { new Guid("60df9ecd-6751-4703-b994-58521d544c82"), "Kalabria", "wlochy", 47m, "Baia di Zambrone", "Via Veneto" },
                    { new Guid("6a6115ac-2851-4808-9b2a-e43a63d6c0a2"), "Heraklion", "grecja", 74m, "Irini Studios", "Plateia Syntagmatos" },
                    { new Guid("6b572f55-21b2-468a-b7d1-0cdf182e15f2"), "Marmaris", "turcja", 109m, "Turunc Resort", "Bağdat Caddesi" },
                    { new Guid("6c0a406b-1d48-48f0-aad5-4fd2fb613641"), "Olimpijska", "grecja", 31m, "Dias Apartments", "Plateia Syntagmatos" },
                    { new Guid("7a4dbe3f-bfb2-4ee1-89c5-1272ee9cef64"), "Kalabria", "wlochy", 93m, "Rada Siri", "Via Veneto" },
                    { new Guid("872e219e-2192-4a27-aef3-9aeba61055a1"), "Durres", "albania", 74m, "Casa Durres", "Rruga e Dibres" },
                    { new Guid("96dab790-70c7-4d2f-9eee-d2623046b059"), "Brava", "hiszpania", 37m, "Cartago Nova by Alegria", "Paseo del Prado" },
                    { new Guid("9996c12e-3376-433b-9d0d-50818ff02fb4"), "Peloponez", "grecja", 43m, "Aldemar Olympian Village", "Leoforos Alexandras" },
                    { new Guid("9f67336d-2292-4d17-b5f1-d1c1d01cae3b"), "Chania", "grecja", 91m, "Rethymno Mare Water Park", "Leoforos Vasilissis Sofias" },
                    { new Guid("a02d2882-9290-470b-9d0c-c2cadced8f17"), "Alam", "egipt", 97m, "Marina Resort Port Ghalib", "Sharia Tahrir" },
                    { new Guid("ac8be2a3-fd7b-4801-9201-5ade8eb5ca09"), "Sheikh", "egipt", 74m, "Old Vic Resort Sharm", "Sharia Ramsis" },
                    { new Guid("ae3f1cd0-7a0f-408f-958e-6443275e615c"), "Kalabria", "wlochy", 79m, "San Domenico", "Via del Corso" },
                    { new Guid("b0a34988-a75d-4233-a843-3ac955980637"), "Vlora", "albania", 99m, "MonteCarlo Lungomare", "Rruga e Kavajes" },
                    { new Guid("b1b56584-57d2-41da-82d0-3c6a7426db58"), "Durres", "albania", 83m, "Pinea Resort & Spa", "Rruga e Dibres" },
                    { new Guid("b59bd50d-c9da-4baa-b0e8-b770f7c0b4c9"), "Nero", "grecja", 56m, "Studia Katerina", "Leoforos Vasilissis Sofias" },
                    { new Guid("b9f1112d-59e6-484b-9e19-566f63a4538b"), "Turecka", "turcja", 107m, "Kolibri Hotel", "Atatürk Caddesi" },
                    { new Guid("bc609ca0-869c-4c8b-8c5b-5343a6bcea72"), "Sheikh", "egipt", 116m, "Falcon Naama Star", "Sharia Salah Salem" },
                    { new Guid("bfea1f6f-f260-467b-a952-9b44e48462f8"), "Riwiera", "chorwacja", 42m, "Apartamenty Omiś", "Vukovarska ulica" },
                    { new Guid("c46ad161-cbc1-431e-8443-552d30a4b59d"), "Turecka", "turcja", 111m, "Andriake Beach Club Hotel", "Atatürk Caddesi" },
                    { new Guid("c670897b-810b-44c8-93c3-1800a48bf7e8"), "Durres", "albania", 31m, "Bonita Luxury Hotel", "Rruga Abdyl Frasheri" },
                    { new Guid("c7eac061-0015-45a5-b2f4-cd5d1b6bb88e"), "Alam", "egipt", 33m, "Marina Lodge Port Ghalib", "Sharia Ramsis" },
                    { new Guid("c7fc96fc-2cb0-4fa6-bed1-dd127eccaf25"), "Kalabria", "wlochy", 81m, "Hotel Orizzonte Blu", "Via Nazionale" },
                    { new Guid("ca11b93a-9759-4cc3-aa96-7949ca8bf117"), "Durres", "albania", 34m, "Diamma Resort", "Rruga Abdyl Frasheri" },
                    { new Guid("cfc1053f-749e-4433-a454-325f07593167"), "Nero", "grecja", 110m, "Studia Maria", "Leoforos Alexandras" },
                    { new Guid("d6304d95-c121-4b79-a77c-0cf69f83f331"), "Brava", "hiszpania", 96m, "Evenia Olympic Park", "Calle Mayor" },
                    { new Guid("e3f14182-c16d-4e34-8b6c-1b83a6d645a9"), "Almeria", "hiszpania", 38m, "Evenia Zoraida Beach Resort", "Paseo del Prado" },
                    { new Guid("e432d88b-07d9-4f96-a53c-4cf74acad554"), "Brava", "hiszpania", 67m, "Catalonia", "Calle de Alcalá" },
                    { new Guid("e814608a-3793-489b-ba54-c0d55354de0d"), "Riwiera", "chorwacja", 31m, "Villa Penava", "Trg bana Josipa Jelačića" },
                    { new Guid("ebc1b138-1569-4f81-847e-687bc6d8f25d"), "Turecka", "turcja", 35m, "Kleopatra Micador", "Atatürk Caddesi" },
                    { new Guid("f426ae35-b432-412d-877b-e7b94801901a"), "Maresme", "hiszpania", 106m, "Reymar Playa", "Paseo del Prado" },
                    { new Guid("f52f8b0c-5ed6-4e4e-8958-5a5a3e4fafdb"), "Brava", "hiszpania", 77m, "GHT Oasis Park & Spa", "Gran Vía" },
                    { new Guid("f7e3d8cc-f2f2-4abb-9c8a-cbf3da374901"), "Luz", "hiszpania", 94m, "Estival Islantilla", "Calle Mayor" },
                    { new Guid("f814655e-f6b3-4594-a144-e5f4c5ba9cc2"), "Riwiera", "chorwacja", 83m, "Apartamenty Makarska", "Maksimirska ulica" },
                    { new Guid("fa1ba4de-c45f-4f35-b8c2-59265f1c2e41"), "Turecka", "turcja", 50m, "Melissa", "Halaskargazi Caddesi" },
                    { new Guid("fc6f8ccb-34bb-4dd6-8b40-615ad881f9f5"), "Sheikh", "egipt", 76m, "Barcelo Tiran Sharm Resort", "Sharia Tahrir" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Count", "HotelId", "Price", "Size" },
                values: new object[,]
                {
                    { new Guid("02a86096-ab46-4804-b61e-0d1d22ae271b"), 3, new Guid("1abf8993-caa1-415a-b5bd-22edb70e27c7"), 109m, 3 },
                    { new Guid("0339d81a-ab92-439f-9a35-12b0b84cb77a"), 1, new Guid("6c0a406b-1d48-48f0-aad5-4fd2fb613641"), 183m, 4 },
                    { new Guid("046ed853-3820-4aa5-93c2-d34ca12e3f9e"), 3, new Guid("b59bd50d-c9da-4baa-b0e8-b770f7c0b4c9"), 84m, 4 },
                    { new Guid("0a924d9f-aab0-4df2-827f-acccfd857017"), 3, new Guid("4357c674-758c-40b9-a37a-862cf404c9c8"), 111m, 5 },
                    { new Guid("0cab3bd0-99d6-4a96-a0f4-a35253e34452"), 3, new Guid("c670897b-810b-44c8-93c3-1800a48bf7e8"), 247m, 3 },
                    { new Guid("0dbde87e-6541-49cb-a68f-c46032f80292"), 3, new Guid("4357c674-758c-40b9-a37a-862cf404c9c8"), 148m, 2 },
                    { new Guid("0e02726e-50b3-45eb-81e2-d3b8a13411a4"), 3, new Guid("f52f8b0c-5ed6-4e4e-8958-5a5a3e4fafdb"), 190m, 3 },
                    { new Guid("0e4a81bf-3026-407c-a81c-b42b9fc5871d"), 1, new Guid("b0a34988-a75d-4233-a843-3ac955980637"), 182m, 3 },
                    { new Guid("0e717d69-49c8-46ff-b8fe-ad74024fa5ad"), 1, new Guid("fa1ba4de-c45f-4f35-b8c2-59265f1c2e41"), 175m, 2 },
                    { new Guid("0fd4b9fa-6862-42c5-b597-1d313ff70e89"), 3, new Guid("e432d88b-07d9-4f96-a53c-4cf74acad554"), 92m, 3 },
                    { new Guid("0fea3546-5f60-494a-9d6a-a021ecfbf82b"), 3, new Guid("b9f1112d-59e6-484b-9e19-566f63a4538b"), 215m, 2 },
                    { new Guid("1074a570-093e-4c80-a381-ae7c9abf8a50"), 2, new Guid("b9f1112d-59e6-484b-9e19-566f63a4538b"), 247m, 5 },
                    { new Guid("10fed4b1-4638-427b-af64-bc92dd6ca59c"), 2, new Guid("bfea1f6f-f260-467b-a952-9b44e48462f8"), 221m, 4 },
                    { new Guid("1286e853-7c3f-48f0-8b1e-af0497f940c7"), 1, new Guid("bc609ca0-869c-4c8b-8c5b-5343a6bcea72"), 158m, 2 },
                    { new Guid("1326b48a-7603-4e0e-8cd9-40aa9949752e"), 3, new Guid("7a4dbe3f-bfb2-4ee1-89c5-1272ee9cef64"), 216m, 3 },
                    { new Guid("13d5dc6d-6150-4137-a4a7-ee1af65d4c2e"), 3, new Guid("9996c12e-3376-433b-9d0d-50818ff02fb4"), 208m, 3 },
                    { new Guid("146c9afc-31cf-42b5-9e3e-ed1c65afe2a5"), 1, new Guid("ebc1b138-1569-4f81-847e-687bc6d8f25d"), 201m, 2 },
                    { new Guid("17a9f3a8-d3ee-4ce5-9c0d-68590328103d"), 3, new Guid("f52f8b0c-5ed6-4e4e-8958-5a5a3e4fafdb"), 217m, 5 },
                    { new Guid("17d79a23-db84-454a-85f4-f22d17b8d76c"), 3, new Guid("e432d88b-07d9-4f96-a53c-4cf74acad554"), 241m, 5 },
                    { new Guid("18795135-0209-4630-80f3-5dfc2394d136"), 2, new Guid("9f67336d-2292-4d17-b5f1-d1c1d01cae3b"), 211m, 2 },
                    { new Guid("1a14f0d0-fa9e-4d8a-b429-dc0e825a3c7f"), 2, new Guid("ebc1b138-1569-4f81-847e-687bc6d8f25d"), 219m, 3 },
                    { new Guid("1ae11319-8ee5-4d11-bf51-6fee8e352b87"), 3, new Guid("bc609ca0-869c-4c8b-8c5b-5343a6bcea72"), 154m, 5 },
                    { new Guid("1b40a6d3-b384-4d59-b0e8-2203eb535732"), 3, new Guid("b0a34988-a75d-4233-a843-3ac955980637"), 70m, 5 },
                    { new Guid("1c9c5d2d-e662-476d-abcb-0909e33ae679"), 1, new Guid("d6304d95-c121-4b79-a77c-0cf69f83f331"), 247m, 3 },
                    { new Guid("1cc47ecc-3399-4baf-9856-62a2037cd419"), 2, new Guid("4333746e-41a6-420d-b54d-2d8659ad59cf"), 162m, 4 },
                    { new Guid("1e839581-f716-425a-97fc-1885f4133290"), 2, new Guid("c46ad161-cbc1-431e-8443-552d30a4b59d"), 244m, 3 },
                    { new Guid("1e9a14cf-26d3-4939-9763-90f0b04e5e67"), 2, new Guid("e814608a-3793-489b-ba54-c0d55354de0d"), 201m, 4 },
                    { new Guid("1effeac6-addc-4b31-89cf-5dad3d51d351"), 3, new Guid("540b1e5e-f3f8-4071-b755-78db5b80ceca"), 147m, 3 },
                    { new Guid("22100842-76b4-4648-8533-1bf1c4a22d9c"), 3, new Guid("f52f8b0c-5ed6-4e4e-8958-5a5a3e4fafdb"), 77m, 4 },
                    { new Guid("23361e48-020e-4941-9042-06c06de1eef4"), 3, new Guid("e3f14182-c16d-4e34-8b6c-1b83a6d645a9"), 197m, 4 },
                    { new Guid("242b361e-9897-4e81-afad-25f6541cc797"), 1, new Guid("fa1ba4de-c45f-4f35-b8c2-59265f1c2e41"), 50m, 4 },
                    { new Guid("29fedea0-919c-40e2-b1ff-c5494da6f595"), 1, new Guid("e814608a-3793-489b-ba54-c0d55354de0d"), 73m, 5 },
                    { new Guid("2a983e6b-977c-47d4-ba34-e4cd7f3bbb97"), 3, new Guid("bc609ca0-869c-4c8b-8c5b-5343a6bcea72"), 95m, 4 },
                    { new Guid("2b7da4a9-d035-41b8-88ad-b8e3a943e816"), 1, new Guid("b0a34988-a75d-4233-a843-3ac955980637"), 238m, 4 },
                    { new Guid("2c4255f8-dcce-4d43-baea-03f8e1dcc5a0"), 1, new Guid("f426ae35-b432-412d-877b-e7b94801901a"), 112m, 3 },
                    { new Guid("2da54ee3-fdad-4ff9-a9b7-a4d83be78637"), 3, new Guid("6b572f55-21b2-468a-b7d1-0cdf182e15f2"), 146m, 4 },
                    { new Guid("2e81afda-bff4-4ec7-bec9-789b10294902"), 2, new Guid("c7fc96fc-2cb0-4fa6-bed1-dd127eccaf25"), 73m, 3 },
                    { new Guid("2e9a84bf-2c0c-4005-a10f-685215bd8b39"), 2, new Guid("ac8be2a3-fd7b-4801-9201-5ade8eb5ca09"), 147m, 5 },
                    { new Guid("2f576f86-3e98-4951-aab8-1b532462497f"), 3, new Guid("4333746e-41a6-420d-b54d-2d8659ad59cf"), 129m, 2 },
                    { new Guid("30671c9b-0822-4138-9cc6-8fa30973edab"), 3, new Guid("96dab790-70c7-4d2f-9eee-d2623046b059"), 204m, 3 },
                    { new Guid("3109e80a-87f5-4205-8039-5c434c960a12"), 1, new Guid("bfea1f6f-f260-467b-a952-9b44e48462f8"), 145m, 3 },
                    { new Guid("326b6f8e-c5c5-417d-a977-ba3e8e2fe1d8"), 3, new Guid("b1b56584-57d2-41da-82d0-3c6a7426db58"), 119m, 2 },
                    { new Guid("339dbe64-3ca2-441c-b1d5-79502938a058"), 3, new Guid("d6304d95-c121-4b79-a77c-0cf69f83f331"), 70m, 4 },
                    { new Guid("353795a3-02eb-4176-aa87-2f0e7138cc44"), 1, new Guid("6a6115ac-2851-4808-9b2a-e43a63d6c0a2"), 210m, 4 },
                    { new Guid("36673e3b-3726-497b-b1ad-fe58429de6be"), 2, new Guid("4357c674-758c-40b9-a37a-862cf404c9c8"), 168m, 3 },
                    { new Guid("36a71b2e-4bb7-41a8-b8db-93d9c352e9b1"), 2, new Guid("872e219e-2192-4a27-aef3-9aeba61055a1"), 105m, 5 },
                    { new Guid("37c3b492-681f-4a25-acb3-8b21e70e5b8d"), 1, new Guid("c670897b-810b-44c8-93c3-1800a48bf7e8"), 164m, 4 },
                    { new Guid("38803583-132c-4337-91cd-dfd2cf646616"), 1, new Guid("18d18682-f9c6-44d2-8d00-c763d2923cc8"), 110m, 3 },
                    { new Guid("389766fe-5df5-42a8-90c9-46aa7081758d"), 3, new Guid("f814655e-f6b3-4594-a144-e5f4c5ba9cc2"), 155m, 3 },
                    { new Guid("3a2d0b21-1ebd-46f4-95ba-b73c0801f4a8"), 1, new Guid("e814608a-3793-489b-ba54-c0d55354de0d"), 187m, 3 },
                    { new Guid("3b808083-0d1f-4671-95d8-c98f9c0a05f8"), 3, new Guid("f426ae35-b432-412d-877b-e7b94801901a"), 190m, 2 },
                    { new Guid("3d04f924-524b-4ece-a96f-1befe9c4873a"), 1, new Guid("cfc1053f-749e-4433-a454-325f07593167"), 130m, 2 },
                    { new Guid("429ec3ea-f9f6-4bb0-ada5-4241ef617f6e"), 3, new Guid("c7fc96fc-2cb0-4fa6-bed1-dd127eccaf25"), 118m, 2 },
                    { new Guid("4966bfe6-2234-44cc-b62c-df7deef03941"), 3, new Guid("c46ad161-cbc1-431e-8443-552d30a4b59d"), 132m, 2 },
                    { new Guid("4a1b2a20-1c57-466c-a3f0-91d60c994450"), 3, new Guid("a02d2882-9290-470b-9d0c-c2cadced8f17"), 180m, 4 },
                    { new Guid("4b959c68-607d-4765-add3-866c13a0816a"), 1, new Guid("18d18682-f9c6-44d2-8d00-c763d2923cc8"), 95m, 4 },
                    { new Guid("4d93abfe-134f-40f6-b395-84b8bf30a3c7"), 1, new Guid("ebc1b138-1569-4f81-847e-687bc6d8f25d"), 63m, 5 },
                    { new Guid("4f612483-2055-47a1-bbf5-bfa01290b6dc"), 2, new Guid("30708e68-aa83-489b-aeeb-12d03441fe78"), 220m, 2 },
                    { new Guid("51be6085-8310-47f7-a249-9fc099a4810a"), 2, new Guid("ac8be2a3-fd7b-4801-9201-5ade8eb5ca09"), 125m, 4 },
                    { new Guid("5218c2f3-4650-426f-92ea-4776d224e832"), 1, new Guid("7a4dbe3f-bfb2-4ee1-89c5-1272ee9cef64"), 98m, 4 },
                    { new Guid("528735f6-224b-4565-b49b-f15f01f4115e"), 1, new Guid("30708e68-aa83-489b-aeeb-12d03441fe78"), 143m, 4 },
                    { new Guid("5311755b-7c1d-4ab7-97d5-20779a881887"), 2, new Guid("d6304d95-c121-4b79-a77c-0cf69f83f331"), 87m, 2 },
                    { new Guid("55b5d7a9-b2b3-4785-8ec0-6d47c963aeeb"), 1, new Guid("07742431-3af8-4f28-958d-1376cf478c7f"), 218m, 4 },
                    { new Guid("57fe9bf9-d2ce-44c5-b5c3-0b3cc92e3301"), 2, new Guid("e3f14182-c16d-4e34-8b6c-1b83a6d645a9"), 237m, 5 },
                    { new Guid("589f072f-de7b-4b74-a368-ed5b87381c5d"), 1, new Guid("e432d88b-07d9-4f96-a53c-4cf74acad554"), 53m, 2 },
                    { new Guid("5b417da4-53f3-49d7-a791-529aaa16a74b"), 2, new Guid("6b572f55-21b2-468a-b7d1-0cdf182e15f2"), 207m, 2 },
                    { new Guid("5de97438-0943-48ee-9288-ce2550b2a0e5"), 3, new Guid("ae3f1cd0-7a0f-408f-958e-6443275e615c"), 107m, 3 },
                    { new Guid("5e393c79-4674-4855-8dde-713a9c5ca394"), 2, new Guid("60df9ecd-6751-4703-b994-58521d544c82"), 213m, 2 },
                    { new Guid("6153ed60-b7e5-4289-8b0e-5a8278b58d4e"), 2, new Guid("c7eac061-0015-45a5-b2f4-cd5d1b6bb88e"), 176m, 2 },
                    { new Guid("61ddc3ae-ab82-4d1a-8daf-46a8cb60962e"), 2, new Guid("6a6115ac-2851-4808-9b2a-e43a63d6c0a2"), 88m, 3 },
                    { new Guid("627602d2-2269-4c84-818a-2294e00618fa"), 3, new Guid("f7e3d8cc-f2f2-4abb-9c8a-cbf3da374901"), 242m, 2 },
                    { new Guid("64e04704-3515-447e-b14c-76503a7ae6af"), 1, new Guid("b59bd50d-c9da-4baa-b0e8-b770f7c0b4c9"), 129m, 2 },
                    { new Guid("6b6ca043-9ef2-48e2-ab32-8a117118b184"), 2, new Guid("fc6f8ccb-34bb-4dd6-8b40-615ad881f9f5"), 153m, 2 },
                    { new Guid("6b9dbc6d-0674-4d4b-b0b6-60eefab05729"), 3, new Guid("30708e68-aa83-489b-aeeb-12d03441fe78"), 71m, 5 },
                    { new Guid("6db493bf-2576-4495-8108-5204e40d70b7"), 2, new Guid("30708e68-aa83-489b-aeeb-12d03441fe78"), 96m, 3 },
                    { new Guid("6e175e74-7100-46f3-8fe0-4e7e9db01595"), 1, new Guid("ca11b93a-9759-4cc3-aa96-7949ca8bf117"), 205m, 5 },
                    { new Guid("714dbc1f-0579-4575-bc3a-3669dd733926"), 2, new Guid("c7fc96fc-2cb0-4fa6-bed1-dd127eccaf25"), 81m, 5 },
                    { new Guid("74d817db-a7f3-459d-b991-50190450a0d9"), 1, new Guid("9f67336d-2292-4d17-b5f1-d1c1d01cae3b"), 77m, 3 },
                    { new Guid("75f9c47d-ecd2-4ae1-b6fc-70f65c56c3e7"), 2, new Guid("18d18682-f9c6-44d2-8d00-c763d2923cc8"), 111m, 2 },
                    { new Guid("76bd82b7-2f21-486c-871e-2a98c98bf911"), 3, new Guid("7a4dbe3f-bfb2-4ee1-89c5-1272ee9cef64"), 178m, 2 },
                    { new Guid("78367c7d-5e0c-4927-854e-4974ffe7b3f7"), 3, new Guid("7a4dbe3f-bfb2-4ee1-89c5-1272ee9cef64"), 165m, 5 },
                    { new Guid("78871ab0-f729-49e7-bc05-e7e3acbebce3"), 3, new Guid("1abf8993-caa1-415a-b5bd-22edb70e27c7"), 78m, 4 },
                    { new Guid("7935aeb6-0764-46e2-bfed-305e62d0609e"), 1, new Guid("96dab790-70c7-4d2f-9eee-d2623046b059"), 94m, 5 },
                    { new Guid("7b0d02c9-62d5-4d0a-bfd2-7efd346a5c89"), 3, new Guid("ae3f1cd0-7a0f-408f-958e-6443275e615c"), 162m, 5 },
                    { new Guid("7c5abe66-f217-461f-b99f-e50485678fcb"), 2, new Guid("6a6115ac-2851-4808-9b2a-e43a63d6c0a2"), 165m, 2 },
                    { new Guid("7cbef198-a92b-4d95-b9b8-b1f04b9b8d71"), 2, new Guid("9f67336d-2292-4d17-b5f1-d1c1d01cae3b"), 169m, 4 },
                    { new Guid("7db4a46e-6b62-4197-9375-46448665b0a2"), 2, new Guid("bfea1f6f-f260-467b-a952-9b44e48462f8"), 108m, 5 },
                    { new Guid("80dcf4ff-1a22-4f5c-ab55-4f4a7b90ce87"), 2, new Guid("b59bd50d-c9da-4baa-b0e8-b770f7c0b4c9"), 234m, 3 },
                    { new Guid("810854f2-62c3-46c7-8e6a-fa88ba070b8f"), 2, new Guid("b1b56584-57d2-41da-82d0-3c6a7426db58"), 123m, 4 },
                    { new Guid("84e085e4-d6e5-4ea7-aea0-f56922cb7c9d"), 2, new Guid("f52f8b0c-5ed6-4e4e-8958-5a5a3e4fafdb"), 60m, 2 },
                    { new Guid("865bee79-82d4-4b6f-80ac-5064aef7d800"), 3, new Guid("b0a34988-a75d-4233-a843-3ac955980637"), 193m, 2 },
                    { new Guid("875d96ab-c397-4de8-8fe4-fa664aa4b2c9"), 3, new Guid("872e219e-2192-4a27-aef3-9aeba61055a1"), 104m, 2 },
                    { new Guid("881e4028-06fb-43f3-a4ed-f27272cbfd67"), 1, new Guid("fa1ba4de-c45f-4f35-b8c2-59265f1c2e41"), 219m, 5 },
                    { new Guid("88270b20-2ade-4e6f-bc09-1520261a65d1"), 1, new Guid("6c0a406b-1d48-48f0-aad5-4fd2fb613641"), 84m, 5 },
                    { new Guid("8a2b81e4-365b-45f6-9d61-ac7ee05e70fa"), 2, new Guid("ac8be2a3-fd7b-4801-9201-5ade8eb5ca09"), 179m, 3 },
                    { new Guid("8b6ac292-5ddf-4a52-996f-fc45ecc91fb7"), 1, new Guid("c46ad161-cbc1-431e-8443-552d30a4b59d"), 243m, 4 },
                    { new Guid("8e25960b-f8ee-48c2-94d4-c5d9338fcf33"), 3, new Guid("4357c674-758c-40b9-a37a-862cf404c9c8"), 230m, 4 },
                    { new Guid("8eeb6173-a165-49e0-b8b2-b10228fc1f2d"), 3, new Guid("872e219e-2192-4a27-aef3-9aeba61055a1"), 177m, 4 },
                    { new Guid("8efb1152-b2eb-407c-91af-da5bab63e3df"), 3, new Guid("f7e3d8cc-f2f2-4abb-9c8a-cbf3da374901"), 142m, 4 },
                    { new Guid("90bb4c84-a45b-43d2-8213-be3bb8041a17"), 2, new Guid("f7e3d8cc-f2f2-4abb-9c8a-cbf3da374901"), 154m, 5 },
                    { new Guid("91855397-3d20-4c7d-8502-32af04ba28ed"), 3, new Guid("b9f1112d-59e6-484b-9e19-566f63a4538b"), 163m, 4 },
                    { new Guid("9248f074-3f97-46f8-ae50-a6efa4a1a106"), 1, new Guid("ae3f1cd0-7a0f-408f-958e-6443275e615c"), 164m, 4 },
                    { new Guid("97f9eb7a-4d07-46f5-a889-39fe1986ba6f"), 2, new Guid("a02d2882-9290-470b-9d0c-c2cadced8f17"), 76m, 2 },
                    { new Guid("9aa21c45-69f3-43e8-a25e-eaff9147dcc1"), 2, new Guid("1abf8993-caa1-415a-b5bd-22edb70e27c7"), 143m, 5 },
                    { new Guid("9e6fe85f-ad1a-4046-b54f-f2062836e43d"), 2, new Guid("540b1e5e-f3f8-4071-b755-78db5b80ceca"), 78m, 4 },
                    { new Guid("a32d60d4-c8fd-4a76-a24b-cedb359b8416"), 1, new Guid("6b572f55-21b2-468a-b7d1-0cdf182e15f2"), 119m, 5 },
                    { new Guid("a5e82d93-e441-4e96-bb59-fb602d3f7468"), 1, new Guid("6c0a406b-1d48-48f0-aad5-4fd2fb613641"), 153m, 2 },
                    { new Guid("a5eadc38-5480-4355-86ed-df55620c84ef"), 1, new Guid("e814608a-3793-489b-ba54-c0d55354de0d"), 121m, 2 },
                    { new Guid("a645e444-f78a-41fb-bedc-f5ec6440ab12"), 3, new Guid("96dab790-70c7-4d2f-9eee-d2623046b059"), 233m, 2 },
                    { new Guid("a9a65a09-762b-490f-9d83-ccc2fbce1702"), 2, new Guid("ebc1b138-1569-4f81-847e-687bc6d8f25d"), 76m, 4 },
                    { new Guid("ab612248-34dd-4f85-9b5e-1abdfec51229"), 2, new Guid("c46ad161-cbc1-431e-8443-552d30a4b59d"), 111m, 5 },
                    { new Guid("ab9b2886-b3bc-4cbf-aa56-277c1c9ebdb1"), 3, new Guid("fc6f8ccb-34bb-4dd6-8b40-615ad881f9f5"), 135m, 5 },
                    { new Guid("acbf6628-5989-44d4-962a-ff918826d97e"), 2, new Guid("60df9ecd-6751-4703-b994-58521d544c82"), 131m, 3 },
                    { new Guid("af36dc3a-9a82-4f8c-827d-e4c23870db64"), 3, new Guid("a02d2882-9290-470b-9d0c-c2cadced8f17"), 195m, 3 },
                    { new Guid("b19afdf0-e77f-4f8b-bd8a-895001445ddd"), 3, new Guid("bfea1f6f-f260-467b-a952-9b44e48462f8"), 84m, 2 },
                    { new Guid("b221589a-a1f2-4a33-b9cb-4a5e5183deef"), 3, new Guid("1abf8993-caa1-415a-b5bd-22edb70e27c7"), 219m, 2 },
                    { new Guid("b4ac7f4e-836e-4939-ad18-cfdf62e0b55c"), 1, new Guid("ae3f1cd0-7a0f-408f-958e-6443275e615c"), 146m, 2 },
                    { new Guid("b4dea72e-4980-4b4d-bc36-f7c0e22cb71c"), 2, new Guid("f814655e-f6b3-4594-a144-e5f4c5ba9cc2"), 179m, 2 },
                    { new Guid("b81be36f-76b0-4cae-8a21-81d27a4a2432"), 1, new Guid("07742431-3af8-4f28-958d-1376cf478c7f"), 235m, 5 },
                    { new Guid("bc507cb2-9722-4495-a215-3a0a2f219df7"), 3, new Guid("4333746e-41a6-420d-b54d-2d8659ad59cf"), 191m, 5 },
                    { new Guid("bc860757-dbaf-4d7a-a43c-ef7545c2527e"), 2, new Guid("ca11b93a-9759-4cc3-aa96-7949ca8bf117"), 145m, 2 },
                    { new Guid("bd2b8859-904c-485d-8e9a-0433edae1cd7"), 1, new Guid("9f67336d-2292-4d17-b5f1-d1c1d01cae3b"), 84m, 5 },
                    { new Guid("bdb8b8c0-8e4d-422b-8150-6ab5cbcf8bcc"), 3, new Guid("e3f14182-c16d-4e34-8b6c-1b83a6d645a9"), 149m, 3 },
                    { new Guid("be088051-f09b-4b90-a53a-d4818a0fcf75"), 1, new Guid("07742431-3af8-4f28-958d-1376cf478c7f"), 123m, 2 },
                    { new Guid("c0ef69e9-3065-4663-b2e4-84a3ef98a7d1"), 2, new Guid("4333746e-41a6-420d-b54d-2d8659ad59cf"), 62m, 3 },
                    { new Guid("c146dfca-0972-44af-97c2-d5dfa74164cf"), 1, new Guid("540b1e5e-f3f8-4071-b755-78db5b80ceca"), 84m, 2 },
                    { new Guid("c2464b1a-4047-4e4e-9314-70101ac4800b"), 3, new Guid("18d18682-f9c6-44d2-8d00-c763d2923cc8"), 239m, 5 },
                    { new Guid("c24679bb-1311-4416-8e67-0470bc96d394"), 2, new Guid("6c0a406b-1d48-48f0-aad5-4fd2fb613641"), 125m, 3 },
                    { new Guid("c24b2ae0-43bf-4305-ae8b-6b8b95e6e8b8"), 3, new Guid("c7eac061-0015-45a5-b2f4-cd5d1b6bb88e"), 95m, 3 },
                    { new Guid("c2a265df-2b81-4080-ad4c-3e3f42a3ca77"), 2, new Guid("2b0c4a0b-c5b4-4383-9610-97323a80430c"), 209m, 5 },
                    { new Guid("c619eb55-236c-4f1f-becb-3bbba88d83e5"), 3, new Guid("e432d88b-07d9-4f96-a53c-4cf74acad554"), 250m, 4 },
                    { new Guid("c65a3afe-9222-4eb9-8ae4-f1f291dfa2df"), 1, new Guid("cfc1053f-749e-4433-a454-325f07593167"), 72m, 5 },
                    { new Guid("c8002d53-f8e7-42ef-bcaa-99111e6ffb8c"), 3, new Guid("d6304d95-c121-4b79-a77c-0cf69f83f331"), 184m, 5 },
                    { new Guid("c8857e1f-7e88-4b67-948d-6aa4ab032b6d"), 3, new Guid("fc6f8ccb-34bb-4dd6-8b40-615ad881f9f5"), 223m, 4 },
                    { new Guid("c8fab056-f713-47ab-948d-9871feb33054"), 2, new Guid("bc609ca0-869c-4c8b-8c5b-5343a6bcea72"), 133m, 3 },
                    { new Guid("ce76d8f3-bb46-46ce-81a4-176866b70326"), 2, new Guid("9996c12e-3376-433b-9d0d-50818ff02fb4"), 239m, 2 },
                    { new Guid("ce7d6e52-a572-4071-bbf9-017f55c8ac58"), 1, new Guid("9996c12e-3376-433b-9d0d-50818ff02fb4"), 64m, 5 },
                    { new Guid("cf03720a-a0ea-4179-ab26-b56cfd522958"), 1, new Guid("872e219e-2192-4a27-aef3-9aeba61055a1"), 136m, 3 },
                    { new Guid("cf932f47-b16d-485c-a67b-e762702f6fd6"), 2, new Guid("b1b56584-57d2-41da-82d0-3c6a7426db58"), 215m, 5 },
                    { new Guid("d072e42f-c142-4a17-8f00-10aa74368e03"), 3, new Guid("ca11b93a-9759-4cc3-aa96-7949ca8bf117"), 74m, 4 },
                    { new Guid("d1969e5d-a0ea-4b57-8f77-4bed66195125"), 3, new Guid("cfc1053f-749e-4433-a454-325f07593167"), 97m, 3 },
                    { new Guid("d3df3a6f-cb3c-4014-82eb-90e034ed055a"), 2, new Guid("2b0c4a0b-c5b4-4383-9610-97323a80430c"), 188m, 2 },
                    { new Guid("d5c334c6-3d47-4c41-995f-0ff51be6804b"), 1, new Guid("07742431-3af8-4f28-958d-1376cf478c7f"), 219m, 3 },
                    { new Guid("d895973e-21e5-41bd-bb9b-16bb97cb9678"), 1, new Guid("e3f14182-c16d-4e34-8b6c-1b83a6d645a9"), 76m, 2 },
                    { new Guid("d8c016f3-5b27-41f5-a80f-d35be8833c76"), 2, new Guid("2b0c4a0b-c5b4-4383-9610-97323a80430c"), 90m, 3 },
                    { new Guid("d98c0e7a-8b7e-4e4e-9264-e4e6a8b3eb18"), 3, new Guid("540b1e5e-f3f8-4071-b755-78db5b80ceca"), 110m, 5 },
                    { new Guid("dca50e7a-3f40-4e70-b69b-a1d54bbdc0ae"), 1, new Guid("f814655e-f6b3-4594-a144-e5f4c5ba9cc2"), 195m, 5 },
                    { new Guid("dcbd9103-b5f3-44f2-ab62-9703940572b8"), 3, new Guid("c7eac061-0015-45a5-b2f4-cd5d1b6bb88e"), 127m, 4 },
                    { new Guid("dea7278d-ee1a-4ea1-b3e7-b7998d86b501"), 1, new Guid("fa1ba4de-c45f-4f35-b8c2-59265f1c2e41"), 245m, 3 },
                    { new Guid("e090cedc-dcec-4e85-a4fd-bcb0d5fab136"), 2, new Guid("ac8be2a3-fd7b-4801-9201-5ade8eb5ca09"), 66m, 2 },
                    { new Guid("e3313e2b-35ab-4bd0-9822-467c899351fc"), 2, new Guid("f426ae35-b432-412d-877b-e7b94801901a"), 152m, 4 },
                    { new Guid("e384fd8f-4cd4-4c8f-a88f-85b0d8b77c2a"), 1, new Guid("f426ae35-b432-412d-877b-e7b94801901a"), 177m, 5 },
                    { new Guid("e433567b-baed-49ac-bf24-b711dd8f6df5"), 3, new Guid("cfc1053f-749e-4433-a454-325f07593167"), 165m, 4 },
                    { new Guid("e4b9a719-dc4d-4fe7-b497-42d2da56d2f7"), 3, new Guid("b59bd50d-c9da-4baa-b0e8-b770f7c0b4c9"), 216m, 5 },
                    { new Guid("e4bdab06-ebce-452c-af61-754bcab579ab"), 3, new Guid("c7eac061-0015-45a5-b2f4-cd5d1b6bb88e"), 88m, 5 },
                    { new Guid("e5282cfe-045b-48b9-937a-3f200e6b3975"), 1, new Guid("f7e3d8cc-f2f2-4abb-9c8a-cbf3da374901"), 132m, 3 },
                    { new Guid("e66f6ca2-681e-4bf7-b630-ad0316576fdb"), 1, new Guid("c7fc96fc-2cb0-4fa6-bed1-dd127eccaf25"), 166m, 4 },
                    { new Guid("e8c6a664-0f47-4a94-a05e-b2175b977ef4"), 1, new Guid("f814655e-f6b3-4594-a144-e5f4c5ba9cc2"), 177m, 4 },
                    { new Guid("ed271d94-ba7e-4cc5-bc04-20b456b67864"), 2, new Guid("fc6f8ccb-34bb-4dd6-8b40-615ad881f9f5"), 221m, 3 },
                    { new Guid("ed63ba28-299a-43a1-a064-30c0843961e6"), 2, new Guid("2b0c4a0b-c5b4-4383-9610-97323a80430c"), 166m, 4 },
                    { new Guid("ee82b456-b465-40c7-bb44-7becdbcaf7e3"), 1, new Guid("b9f1112d-59e6-484b-9e19-566f63a4538b"), 164m, 3 },
                    { new Guid("f0ad56e7-1308-40d3-8820-e2d39d93a957"), 1, new Guid("c670897b-810b-44c8-93c3-1800a48bf7e8"), 69m, 5 },
                    { new Guid("f5d0b386-d6e3-4ddc-9ff1-9a2e4d08668d"), 1, new Guid("96dab790-70c7-4d2f-9eee-d2623046b059"), 171m, 4 },
                    { new Guid("f5feedb9-cbbd-40a1-aa90-7ed2fa0c4fa7"), 3, new Guid("a02d2882-9290-470b-9d0c-c2cadced8f17"), 210m, 5 },
                    { new Guid("f982a5e5-4466-4e22-9a4c-7b3a761f1420"), 3, new Guid("9996c12e-3376-433b-9d0d-50818ff02fb4"), 161m, 4 },
                    { new Guid("faf2d93d-4a66-402d-a099-f7dd4591c18a"), 2, new Guid("60df9ecd-6751-4703-b994-58521d544c82"), 140m, 4 },
                    { new Guid("fbf27c82-a896-43f5-bfba-f834827f4ad4"), 1, new Guid("6a6115ac-2851-4808-9b2a-e43a63d6c0a2"), 119m, 5 },
                    { new Guid("fc30784c-a652-48e8-b209-d077a458f7e4"), 2, new Guid("c670897b-810b-44c8-93c3-1800a48bf7e8"), 186m, 2 },
                    { new Guid("fccba2a8-53e0-435d-9957-23c673c1b555"), 3, new Guid("6b572f55-21b2-468a-b7d1-0cdf182e15f2"), 131m, 3 },
                    { new Guid("fea07654-5f06-496c-a24f-b08b48747100"), 2, new Guid("b1b56584-57d2-41da-82d0-3c6a7426db58"), 95m, 3 },
                    { new Guid("ff338b3b-f01b-49d0-904a-7851c38bff83"), 2, new Guid("60df9ecd-6751-4703-b994-58521d544c82"), 250m, 5 },
                    { new Guid("ff80d8e9-f88a-49d5-b837-4fbd2f54f457"), 2, new Guid("ca11b93a-9759-4cc3-aa96-7949ca8bf117"), 138m, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_HotelId",
                table: "Discounts",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomReservations_RoomsId",
                table: "RoomReservations",
                column: "RoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "PopularHotels");

            migrationBuilder.DropTable(
                name: "RoomReservations");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
