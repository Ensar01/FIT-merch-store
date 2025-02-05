using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace merchFITbackend.Migrations
{
    /// <inheritdoc />
    public partial class ProizvodVelicina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Velicina",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Velicina", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProizvodVelicina",
                columns: table => new
                {
                    ProizvodID = table.Column<int>(type: "int", nullable: false),
                    VelicinaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProizvodVelicina", x => new { x.ProizvodID, x.VelicinaID });
                    table.ForeignKey(
                        name: "FK_ProizvodVelicina_Proizvod_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvod",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProizvodVelicina_Velicina_VelicinaID",
                        column: x => x.VelicinaID,
                        principalTable: "Velicina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodVelicina_VelicinaID",
                table: "ProizvodVelicina",
                column: "VelicinaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProizvodVelicina");

            migrationBuilder.DropTable(
                name: "Velicina");
        }
    }
}
