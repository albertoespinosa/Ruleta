using Microsoft.EntityFrameworkCore.Migrations;

namespace Ruleta.Infrastructure.Data.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JuegoRuletas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuegoRuletas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jugador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Dinero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apuestas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoApuesta = table.Column<string>(nullable: true),
                    SeleccionApuesta = table.Column<string>(nullable: true),
                    MontoDinero = table.Column<int>(nullable: false),
                    JugadorId = table.Column<int>(nullable: false),
                    JuegoRuletaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apuestas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apuestas_JuegoRuletas_JuegoRuletaId",
                        column: x => x.JuegoRuletaId,
                        principalTable: "JuegoRuletas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apuestas_Jugador_JugadorId",
                        column: x => x.JugadorId,
                        principalTable: "Jugador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apuestas_JuegoRuletaId",
                table: "Apuestas",
                column: "JuegoRuletaId");

            migrationBuilder.CreateIndex(
                name: "IX_Apuestas_JugadorId",
                table: "Apuestas",
                column: "JugadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apuestas");

            migrationBuilder.DropTable(
                name: "JuegoRuletas");

            migrationBuilder.DropTable(
                name: "Jugador");
        }
    }
}
