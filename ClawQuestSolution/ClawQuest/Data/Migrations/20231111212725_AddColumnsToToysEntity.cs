using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClawQuest.Data.Migrations
{
    public partial class AddColumnsToToysEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Toys",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WinProbability",
                table: "Toys",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Toys");

            migrationBuilder.DropColumn(
                name: "WinProbability",
                table: "Toys");
        }
    }
}
