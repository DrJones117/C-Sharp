using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wedding_planner.Migrations
{
    public partial class CorrectedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RSVPs_Weddings_WeddingRespondedToWeddingId",
                table: "RSVPs");

            migrationBuilder.DropIndex(
                name: "IX_RSVPs_WeddingRespondedToWeddingId",
                table: "RSVPs");

            migrationBuilder.DropColumn(
                name: "WeddingRespondedToWeddingId",
                table: "RSVPs");

            migrationBuilder.AddColumn<int>(
                name: "WeddingId",
                table: "RSVPs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RSVPs_WeddingId",
                table: "RSVPs",
                column: "WeddingId");

            migrationBuilder.AddForeignKey(
                name: "FK_RSVPs_Weddings_WeddingId",
                table: "RSVPs",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RSVPs_Weddings_WeddingId",
                table: "RSVPs");

            migrationBuilder.DropIndex(
                name: "IX_RSVPs_WeddingId",
                table: "RSVPs");

            migrationBuilder.DropColumn(
                name: "WeddingId",
                table: "RSVPs");

            migrationBuilder.AddColumn<int>(
                name: "WeddingRespondedToWeddingId",
                table: "RSVPs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RSVPs_WeddingRespondedToWeddingId",
                table: "RSVPs",
                column: "WeddingRespondedToWeddingId");

            migrationBuilder.AddForeignKey(
                name: "FK_RSVPs_Weddings_WeddingRespondedToWeddingId",
                table: "RSVPs",
                column: "WeddingRespondedToWeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId");
        }
    }
}
