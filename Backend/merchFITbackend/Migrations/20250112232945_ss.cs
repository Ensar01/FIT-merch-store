using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace merchFITbackend.Migrations
{
    /// <inheritdoc />
    public partial class ss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Wishlist_KorisnikID",
                table: "Wishlist");

            migrationBuilder.DropIndex(
                name: "IX_Korpa_KorisnikID",
                table: "Korpa");


            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_KorisnikID",
                table: "Wishlist",
                column: "KorisnikID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Korpa_KorisnikID",
                table: "Korpa",
                column: "KorisnikID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Wishlist_KorisnikID",
                table: "Wishlist");

            migrationBuilder.DropIndex(
                name: "IX_Korpa_KorisnikID",
                table: "Korpa");

          

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_KorisnikID",
                table: "Wishlist",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Korpa_KorisnikID",
                table: "Korpa",
                column: "KorisnikID");
        }
    }
}
