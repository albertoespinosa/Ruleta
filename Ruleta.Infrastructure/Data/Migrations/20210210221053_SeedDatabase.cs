using Microsoft.EntityFrameworkCore.Migrations;

namespace Ruleta.Infrastructure.Data.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Jugadores (Nombre, Password, Dinero) VALUES ('Jugador_1','Password_1', 5000)");
            migrationBuilder.Sql("INSERT INTO Jugadores (Nombre, Password, Dinero) VALUES ('Jugador_2','Password_2', 20000)");
            migrationBuilder.Sql("INSERT INTO Jugadores (Nombre, Password, Dinero) VALUES ('Jugador_3','Password_3', 2000)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
