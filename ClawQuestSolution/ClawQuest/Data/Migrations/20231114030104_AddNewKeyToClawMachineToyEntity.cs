using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClawQuest.Data.Migrations
{
    public partial class AddNewKeyToClawMachineToyEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClawMachineToy_Toys_ToyId",
                table: "ClawMachineToy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClawMachineToy",
                table: "ClawMachineToy");

            migrationBuilder.RenameTable(
                name: "ClawMachineToy",
                newName: "ClawMachineToys");

            migrationBuilder.AddColumn<int>(
                name: "ClawMachineToyId",
                table: "ClawMachineToys",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClawMachineToys",
                table: "ClawMachineToys",
                column: "ClawMachineToyId");

            migrationBuilder.CreateIndex(
                name: "IX_ClawMachineToys_ToyId",
                table: "ClawMachineToys",
                column: "ToyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClawMachineToys_Toys_ToyId",
                table: "ClawMachineToys",
                column: "ToyId",
                principalTable: "Toys",
                principalColumn: "ToyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClawMachineToys_Toys_ToyId",
                table: "ClawMachineToys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClawMachineToys",
                table: "ClawMachineToys");

            migrationBuilder.DropIndex(
                name: "IX_ClawMachineToys_ToyId",
                table: "ClawMachineToys");

            migrationBuilder.DropColumn(
                name: "ClawMachineToyId",
                table: "ClawMachineToys");

            migrationBuilder.RenameTable(
                name: "ClawMachineToys",
                newName: "ClawMachineToy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClawMachineToy",
                table: "ClawMachineToy",
                column: "ToyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClawMachineToy_Toys_ToyId",
                table: "ClawMachineToy",
                column: "ToyId",
                principalTable: "Toys",
                principalColumn: "ToyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
