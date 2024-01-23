using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
	/// <inheritdoc />
	public partial class AgregadoRelaciones : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_PartidosFemeninos_Torneo_IdTorneo",
				table: "PartidosFemeninos");

			migrationBuilder.DropForeignKey(
				name: "FK_PartidosMasculinos_Torneo_IdTorneo",
				table: "PartidosMasculinos");

			migrationBuilder.DropPrimaryKey(
				name: "PK_Torneo",
				table: "Torneos");

			migrationBuilder.RenameTable(
				name: "Torneos",
				newName: "Torneos");

			migrationBuilder.AddColumn<int>(
				name: "IPartidoSiguiente",
				table: "PartidosMasculinos",
				type: "int",
				nullable: true);

			migrationBuilder.AddColumn<int>(
				name: "IPartidoSiguiente",
				table: "PartidosFemeninos",
				type: "int",
				nullable: true);

			migrationBuilder.AddPrimaryKey(
				name: "PK_Torneos",
				table: "Torneos",
				column: "Id");

			migrationBuilder.CreateIndex(
				name: "IX_PartidosMasculinos_IPartidoSiguiente",
				table: "PartidosMasculinos",
				column: "IPartidoSiguiente");

			migrationBuilder.CreateIndex(
				name: "IX_PartidosFemeninos_IPartidoSiguiente",
				table: "PartidosFemeninos",
				column: "IPartidoSiguiente");

			migrationBuilder.AddForeignKey(
				name: "FK_PartidosFemeninos_PartidosFemeninos_IPartidoSiguiente",
				table: "PartidosFemeninos",
				column: "IPartidoSiguiente",
				principalTable: "PartidosFemeninos",
				principalColumn: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_PartidosFemeninos_Torneos_IdTorneo",
				table: "PartidosFemeninos",
				column: "IdTorneo",
				principalTable: "Torneos",
				principalColumn: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_PartidosMasculinos_PartidosMasculinos_IPartidoSiguiente",
				table: "PartidosMasculinos",
				column: "IPartidoSiguiente",
				principalTable: "PartidosMasculinos",
				principalColumn: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_PartidosMasculinos_Torneos_IdTorneo",
				table: "PartidosMasculinos",
				column: "IdTorneo",
				principalTable: "Torneos",
				principalColumn: "Id");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_PartidosFemeninos_PartidosFemeninos_IPartidoSiguiente",
				table: "PartidosFemeninos");

			migrationBuilder.DropForeignKey(
				name: "FK_PartidosFemeninos_Torneos_IdTorneo",
				table: "PartidosFemeninos");

			migrationBuilder.DropForeignKey(
				name: "FK_PartidosMasculinos_PartidosMasculinos_IPartidoSiguiente",
				table: "PartidosMasculinos");

			migrationBuilder.DropForeignKey(
				name: "FK_PartidosMasculinos_Torneos_IdTorneo",
				table: "PartidosMasculinos");

			migrationBuilder.DropIndex(
				name: "IX_PartidosMasculinos_IPartidoSiguiente",
				table: "PartidosMasculinos");

			migrationBuilder.DropIndex(
				name: "IX_PartidosFemeninos_IPartidoSiguiente",
				table: "PartidosFemeninos");

			migrationBuilder.DropPrimaryKey(
				name: "PK_Torneos",
				table: "Torneos");

			migrationBuilder.DropColumn(
				name: "IPartidoSiguiente",
				table: "PartidosMasculinos");

			migrationBuilder.DropColumn(
				name: "IPartidoSiguiente",
				table: "PartidosFemeninos");

			migrationBuilder.RenameTable(
				name: "Torneos",
				newName: "Torneos");

			migrationBuilder.AddPrimaryKey(
				name: "PK_Torneo",
				table: "Torneos",
				column: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_PartidosFemeninos_Torneo_IdTorneo",
				table: "PartidosFemeninos",
				column: "IdTorneo",
				principalTable: "Torneos",
				principalColumn: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_PartidosMasculinos_Torneo_IdTorneo",
				table: "PartidosMasculinos",
				column: "IdTorneo",
				principalTable: "Torneos",
				principalColumn: "Id");
		}
	}
}
