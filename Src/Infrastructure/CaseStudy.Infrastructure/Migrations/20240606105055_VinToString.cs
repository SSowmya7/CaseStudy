using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseStudy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VinToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleVin",
                table: "userFavourites");

            migrationBuilder.AddColumn<string>(
                name: "VIN",
                table: "userFavourites",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VIN",
                table: "userFavourites");

            migrationBuilder.AddColumn<int>(
                name: "VehicleVin",
                table: "userFavourites",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
