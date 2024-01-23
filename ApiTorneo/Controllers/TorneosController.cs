using Business.Services.Interfeces;
using Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiTorneo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TorneosController : ControllerBase
	{
		private readonly IServiceTorneos _serviceTorneos;

		public TorneosController(IServiceTorneos serviceTorneos)
		{
			_serviceTorneos = serviceTorneos;
		}

		[HttpGet("ObtenerTodos")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		public IActionResult GetAllTorneos()
		{
			var listaTorneos = _serviceTorneos.GetAllTorneos();
			return Ok(listaTorneos);
		}
		[HttpGet("ObtenerFiltrados")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		public IActionResult GetAllTorneosFinalizados(bool? masculino, DateTime? fechaDesde, DateTime? fechaHasta)
		{
			var listaTorneos = _serviceTorneos.GetAllTorneosFinalizados(masculino, fechaDesde, fechaHasta);
			return Ok(listaTorneos);
		}

		[HttpPost("CrearTorneoFemenino")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		public IActionResult CrearTorneo([FromBody] List<JugadorFemeninoDto> jugador)
		{
			var jugadores = new List<IJugadorDto>();
			jugador.ToList().ForEach(j => jugadores.Add(j));
			var nuevoTorneo = _serviceTorneos.CrearTorneo(jugadores);
			return Ok(nuevoTorneo);
		}

		[HttpPost("CrearTorneoMasculino")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public IActionResult CrearTorneo([FromBody] List<JugadorMasculinoDto> jugador)
		{
			var jugadores = new List<IJugadorDto>();
			jugador.ToList().ForEach(j => jugadores.Add(j));
			var nuevoTorneo = _serviceTorneos.CrearTorneo(jugadores);
			return Ok(nuevoTorneo);
		}
		[HttpPost("CrearTorneoYFinalizarFemenino")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		public IActionResult CrearTorneoYFinalizar([FromBody] List<JugadorFemeninoDto> jugador)
		{
			var jugadores = new List<IJugadorDto>();
			jugador.ToList().ForEach(j => jugadores.Add(j));
			var torneoCreado = _serviceTorneos.CrearTorneo(jugadores);
			if (torneoCreado == null)
				return NoContent();
			var torneoFinalizado = _serviceTorneos.FinalizarTorneo(torneoCreado.Id);
			return Ok(torneoFinalizado);
		}

		[HttpPost("CrearTorneoYFinalizarMasculino")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		public IActionResult CrearTorneoYFinalizar([FromBody] List<JugadorMasculinoDto> jugador)
		{
			var jugadores = new List<IJugadorDto>();
			jugador.ToList().ForEach(j => jugadores.Add(j));
			var torneoCreado = _serviceTorneos.CrearTorneo(jugadores);
			if (torneoCreado == null)
				return NoContent();
			var torneoFinalizado = _serviceTorneos.FinalizarTorneo(torneoCreado.Id);
			return Ok(torneoFinalizado);
		}

		[HttpDelete("{id:int}", Name = "BorrarTorneo")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status409Conflict)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult BorrarTorneo(int id)
		{
			var torneo = _serviceTorneos.BorrarTorneo(id);

			if (torneo)
				return NoContent();

			return NotFound();
		}

		[HttpGet("FinalizarTorneo/{id:int}", Name = "FinalizarTorneo")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult FinalizarTorneo(int id)
		{
			var torneo = _serviceTorneos.FinalizarTorneo(id);

			if (torneo == null)
				return NotFound();

			return Ok(torneo);
		}

	}

}
