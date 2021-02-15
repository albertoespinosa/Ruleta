using Microsoft.EntityFrameworkCore.Migrations;

namespace Ruleta.Infrastructure.Data.Migrations
{
    public partial class CreateRestrictions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apuestas_JuegoRuletas_JuegoRuletaId",
                table: "Apuestas");

            migrationBuilder.DropForeignKey(
                name: "FK_Apuestas_Jugador_JugadorId",
                table: "Apuestas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jugador",
                table: "Jugador");

            migrationBuilder.RenameTable(
                name: "Jugador",
                newName: "Jugadores");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "JuegoRuletas",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TipoApuesta",
                table: "Apuestas",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SeleccionApuesta",
                table: "Apuestas",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Jugadores",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Jugadores",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jugadores",
                table: "Jugadores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apuestas_JuegoRuletas_JuegoRuletaId",
                table: "Apuestas",
                column: "JuegoRuletaId",
                principalTable: "JuegoRuletas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Apuestas_Jugadores_JugadorId",
                table: "Apuestas",
                column: "JugadorId",
                principalTable: "Jugadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apuestas_JuegoRuletas_JuegoRuletaId",
                table: "Apuestas");

            migrationBuilder.DropForeignKey(
                name: "FK_Apuestas_Jugadores_JugadorId",
                table: "Apuestas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jugadores",
                table: "Jugadores");

            migrationBuilder.RenameTable(
                name: "Jugadores",
                newName: "Jugador");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "JuegoRuletas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "TipoApuesta",
                table: "Apuestas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "SeleccionApuesta",
                table: "Apuestas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Jugador",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Jugador",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jugador",
                table: "Jugador",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apuestas_JuegoRuletas_JuegoRuletaId",
                table: "Apuestas",
                column: "JuegoRuletaId",
                principalTable: "JuegoRuletas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apuestas_Jugador_JugadorId",
                table: "Apuestas",
                column: "JugadorId",
                principalTable: "Jugador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
