using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClawQuest.Data.Migrations
{
    public partial class AddClawMachineToysEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClawMachineToy",
                columns: table => new
                {
                    ToyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClawMachineToy", x => x.ToyId);
                    table.ForeignKey(
                        name: "FK_ClawMachineToy_Toys_ToyId",
                        column: x => x.ToyId,
                        principalTable: "Toys",
                        principalColumn: "ToyId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClawMachineToy");
        }
    }
}
