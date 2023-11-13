using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClawQuest.Data.Migrations
{
    public partial class UpdatePriceToPointsOnToysEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Toys",
                newName: "Points");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Points",
                table: "Toys",
                newName: "Price");
        }
    }
}
