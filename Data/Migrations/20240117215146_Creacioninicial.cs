using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
	/// <inheritdoc />
	public partial class Creacioninicial : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "JugadoresFemeninos",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
					NivelHabilidad = table.Column<int>(type: "int", nullable: false),
					TiempoDeReaccion = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_JugadoresFemeninos", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "JugadoresMasculinos",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Fuerza = table.Column<int>(type: "int", nullable: false),
					Velocidad = table.Column<int>(type: "int", nullable: false),
					NivelHabilidad = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_JugadoresMasculinos", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "PartidosFemeninos",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdJugador1 = table.Column<int>(type: "int", nullable: false),
					IdJugador2 = table.Column<int>(type: "int", nullable: false),
					IdGanador = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PartidosFemeninos", x => x.Id);
					table.ForeignKey(
						name: "FK_PartidosFemeninos_JugadoresFemeninos_IdGanador",
						column: x => x.IdGanador,
						principalTable: "JugadoresFemeninos",
						principalColumn: "Id");
					table.ForeignKey(
						name: "FK_PartidosFemeninos_JugadoresFemeninos_IdJugador1",
						column: x => x.IdJugador1,
						principalTable: "JugadoresFemeninos",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
					table.ForeignKey(
						name: "FK_PartidosFemeninos_JugadoresFemeninos_IdJugador2",
						column: x => x.IdJugador2,
						principalTable: "JugadoresFemeninos",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
				});

			migrationBuilder.CreateTable(
				name: "PartidosMasculinos",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					IdJugador1 = table.Column<int>(type: "int", nullable: false),
					IdJugador2 = table.Column<int>(type: "int", nullable: false),
					IdGanador = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PartidosMasculinos", x => x.Id);
					table.ForeignKey(
						name: "FK_PartidosMasculinos_JugadoresMasculinos_IdGanador",
						column: x => x.IdGanador,
						principalTable: "JugadoresMasculinos",
						principalColumn: "Id");
					table.ForeignKey(
						name: "FK_PartidosMasculinos_JugadoresMasculinos_IdJugador1",
						column: x => x.IdJugador1,
						principalTable: "JugadoresMasculinos",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
					table.ForeignKey(
						name: "FK_PartidosMasculinos_JugadoresMasculinos_IdJugador2",
						column: x => x.IdJugador2,
						principalTable: "JugadoresMasculinos",
						principalColumn: "Id",
						onDelete: ReferentialAction.NoAction);
				});

			migrationBuilder.CreateIndex(
				name: "IX_PartidosFemeninos_IdGanador",
				table: "PartidosFemeninos",
				column: "IdGanador");

			migrationBuilder.CreateIndex(
				name: "IX_PartidosFemeninos_IdJugador1",
				table: "PartidosFemeninos",
				column: "IdJugador1");

			migrationBuilder.CreateIndex(
				name: "IX_PartidosFemeninos_IdJugador2",
				table: "PartidosFemeninos",
				column: "IdJugador2");

			migrationBuilder.CreateIndex(
				name: "IX_PartidosMasculinos_IdGanador",
				table: "PartidosMasculinos",
				column: "IdGanador");

			migrationBuilder.CreateIndex(
				name: "IX_PartidosMasculinos_IdJugador1",
				table: "PartidosMasculinos",
				column: "IdJugador1");

			migrationBuilder.CreateIndex(
				name: "IX_PartidosMasculinos_IdJugador2",
				table: "PartidosMasculinos",
				column: "IdJugador2");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "PartidosFemeninos");

			migrationBuilder.DropTable(
				name: "PartidosMasculinos");

			migrationBuilder.DropTable(
				name: "JugadoresFemeninos");

			migrationBuilder.DropTable(
				name: "JugadoresMasculinos");
		}
	}
}
