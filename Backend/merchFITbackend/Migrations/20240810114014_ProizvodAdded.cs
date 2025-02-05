using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace merchFITbackend.Migrations
{
    /// <inheritdoc />
    public partial class ProizvodAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UzrastID",
                table: "Proizvod",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_UzrastID",
                table: "Proizvod",
                column: "UzrastID");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvod_Uzrast_UzrastID",
                table: "Proizvod",
                column: "UzrastID",
                principalTable: "Uzrast",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_Uzrast_UzrastID",
                table: "Proizvod");

            migrationBuilder.DropIndex(
                name: "IX_Proizvod_UzrastID",
                table: "Proizvod");

            migrationBuilder.DropColumn(
                name: "UzrastID",
                table: "Proizvod");
        }
    }
}
