using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace merchFITbackend.Migrations
{
    /// <inheritdoc />
    public partial class ProizvodAddedField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SlikaProizvoda",
                table: "Proizvod",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlikaProizvoda",
                table: "Proizvod");
        }
    }
}
