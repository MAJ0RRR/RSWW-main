using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace transportservice.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TransportId = table.Column<Guid>(type: "uuid", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    ShowName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ToAddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    FromAddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Adult = table.Column<decimal>(type: "numeric", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportOptions_Addresses_FromAddressId",
                        column: x => x.FromAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportOptions_Addresses_ToAddressId",
                        column: x => x.ToAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TransportOptionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discounts_TransportOptions_TransportOptionId",
                        column: x => x.TransportOptionId,
                        principalTable: "TransportOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeatsChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TransportOptionId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChangeBy = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatsChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatsChanges_TransportOptions_TransportOptionId",
                        column: x => x.TransportOptionId,
                        principalTable: "TransportOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_TransportOptionId",
                table: "Discounts",
                column: "TransportOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatsChanges_TransportOptionId",
                table: "SeatsChanges",
                column: "TransportOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportOptions_FromAddressId",
                table: "TransportOptions",
                column: "FromAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportOptions_ToAddressId",
                table: "TransportOptions",
                column: "ToAddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "SeatsChanges");

            migrationBuilder.DropTable(
                name: "TransportOptions");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
