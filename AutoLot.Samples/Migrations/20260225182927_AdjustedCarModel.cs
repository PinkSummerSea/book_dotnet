using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoLot.Samples.Migrations
{
    /// <inheritdoc />
    public partial class AdjustedCarModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateBuilt",
                schema: "dbo",
                table: "Inventory",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<bool>(
                name: "IsDrivable",
                schema: "dbo",
                table: "Inventory",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Display",
                schema: "dbo",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "[PetName] + ' (' + [Color] + ')'",
                stored: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Display",
                schema: "dbo",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "DateBuilt",
                schema: "dbo",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "IsDrivable",
                schema: "dbo",
                table: "Inventory");
        }
    }
}
