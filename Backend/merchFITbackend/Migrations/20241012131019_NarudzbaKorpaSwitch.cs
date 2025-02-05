using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace merchFITbackend.Migrations
{
    /// <inheritdoc />
    public partial class NarudzbaKorpaSwitch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korpa_Dostavljac_DostavljacID",
                table: "Korpa");

            migrationBuilder.DropIndex(
                name: "IX_Korpa_DostavljacID",
                table: "Korpa");

            migrationBuilder.DropColumn(
                name: "DostavljacID",
                table: "Korpa");

            migrationBuilder.AddColumn<int>(
                name: "DostavljacID",
                table: "Narudzba",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_DostavljacID",
                table: "Narudzba",
                column: "DostavljacID");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Dostavljac_DostavljacID",
                table: "Narudzba",
                column: "DostavljacID",
                principalTable: "Dostavljac",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Dostavljac_DostavljacID",
                table: "Narudzba");

            migrationBuilder.DropIndex(
                name: "IX_Narudzba_DostavljacID",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "DostavljacID",
                table: "Narudzba");

            migrationBuilder.AddColumn<int>(
                name: "DostavljacID",
                table: "Korpa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Korpa_DostavljacID",
                table: "Korpa",
                column: "DostavljacID");

            migrationBuilder.AddForeignKey(
                name: "FK_Korpa_Dostavljac_DostavljacID",
                table: "Korpa",
                column: "DostavljacID",
                principalTable: "Dostavljac",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
