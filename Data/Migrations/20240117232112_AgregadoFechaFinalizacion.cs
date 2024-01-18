using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
	/// <inheritdoc />
	public partial class AgregadoFechaFinalizacion : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<DateTime>(
				name: "FechaFinalizacion",
				table: "Torneos",
				type: "datetime2",
				nullable: true);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "FechaFinalizacion",
				table: "Torneos");
		}
	}
}
