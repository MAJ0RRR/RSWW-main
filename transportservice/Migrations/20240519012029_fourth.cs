using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace transportservice.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportOptions_Addresses_FromAddressId1",
                table: "TransportOptions");

            migrationBuilder.DropIndex(
                name: "IX_TransportOptions_FromAddressId1",
                table: "TransportOptions");

            migrationBuilder.DropColumn(
                name: "FromAddressId1",
                table: "TransportOptions");

            migrationBuilder.DropColumn(
                name: "TransportId",
                table: "Addresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FromAddressId1",
                table: "TransportOptions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TransportId",
                table: "Addresses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TransportOptions_FromAddressId1",
                table: "TransportOptions",
                column: "FromAddressId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportOptions_Addresses_FromAddressId1",
                table: "TransportOptions",
                column: "FromAddressId1",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
