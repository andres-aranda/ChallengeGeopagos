using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
	/// <inheritdoc />
	public partial class CreacionTorneo : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<int>(
				name: "IdTorneo",
				table: "PartidosMasculinos",
				type: "int",
				nullable: true);

			migrationBuilder.AddColumn<int>(
				name: "IdTorneo",
				table: "PartidosFemeninos",
				type: "int",
				nullable: true);

			migrationBuilder.CreateTable(
				name: "Torneos",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Torneo", x => x.Id);
				});

			migrationBuilder.CreateIndex(
				name: "IX_PartidosMasculinos_IdTorneo",
				table: "PartidosMasculinos",
				column: "IdTorneo");

			migrationBuilder.CreateIndex(
				name: "IX_PartidosFemeninos_IdTorneo",
				table: "PartidosFemeninos",
				column: "IdTorneo");

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

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_PartidosFemeninos_Torneo_IdTorneo",
				table: "PartidosFemeninos");

			migrationBuilder.DropForeignKey(
				name: "FK_PartidosMasculinos_Torneo_IdTorneo",
				table: "PartidosMasculinos");

			migrationBuilder.DropTable(
				name: "Torneos");

			migrationBuilder.DropIndex(
				name: "IX_PartidosMasculinos_IdTorneo",
				table: "PartidosMasculinos");

			migrationBuilder.DropIndex(
				name: "IX_PartidosFemeninos_IdTorneo",
				table: "PartidosFemeninos");

			migrationBuilder.DropColumn(
				name: "IdTorneo",
				table: "PartidosMasculinos");

			migrationBuilder.DropColumn(
				name: "IdTorneo",
				table: "PartidosFemeninos");
		}
	}
}
