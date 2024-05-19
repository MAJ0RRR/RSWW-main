using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace transportservice.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adult",
                table: "TransportOptions",
                newName: "PriceAdult");

            migrationBuilder.AddColumn<Guid>(
                name: "FromAddressId1",
                table: "TransportOptions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "InitialSeats",
                table: "TransportOptions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ToAddressId1",
                table: "TransportOptions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TransportOptions_FromAddressId1",
                table: "TransportOptions",
                column: "FromAddressId1");

            migrationBuilder.CreateIndex(
                name: "IX_TransportOptions_ToAddressId1",
                table: "TransportOptions",
                column: "ToAddressId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportOptions_Addresses_FromAddressId1",
                table: "TransportOptions",
                column: "FromAddressId1",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportOptions_Addresses_ToAddressId1",
                table: "TransportOptions",
                column: "ToAddressId1",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportOptions_Addresses_FromAddressId1",
                table: "TransportOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportOptions_Addresses_ToAddressId1",
                table: "TransportOptions");

            migrationBuilder.DropIndex(
                name: "IX_TransportOptions_FromAddressId1",
                table: "TransportOptions");

            migrationBuilder.DropIndex(
                name: "IX_TransportOptions_ToAddressId1",
                table: "TransportOptions");

            migrationBuilder.DropColumn(
                name: "FromAddressId1",
                table: "TransportOptions");

            migrationBuilder.DropColumn(
                name: "InitialSeats",
                table: "TransportOptions");

            migrationBuilder.DropColumn(
                name: "ToAddressId1",
                table: "TransportOptions");

            migrationBuilder.RenameColumn(
                name: "PriceAdult",
                table: "TransportOptions",
                newName: "Adult");
        }
    }
}
