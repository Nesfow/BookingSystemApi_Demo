using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystemApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingIsPaidToSeat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Seat",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "PaymentExpirationDate",
                table: "Booking",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "PaymentExpirationDate",
                table: "Booking");
        }
    }
}
