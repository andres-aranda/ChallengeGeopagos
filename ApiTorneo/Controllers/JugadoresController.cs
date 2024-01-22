using Business.Services.Interfeces;
using Data.Dominio;
using Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiTorneo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JugadoresController : ControllerBase
	{
		private readonly IServiceJugadores _serviceJugadores;

		public JugadoresController(IServiceJugadores serviceJugadores)
		{
			_serviceJugadores = serviceJugadores;
		}

		[HttpGet("Femeninos")]	
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		public IActionResult GetAllJugadoresFemeninos()
		{
			var listaJugadores = _serviceJugadores.GetAllJugadoresFemeninos();
			return Ok(listaJugadores);
		}
		[HttpGet("Masculinos")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		public IActionResult GetAllJugadoresMasculinos()
		{
			var listaJugadores = _serviceJugadores.GetAllJugadoresMasculinos();
			return Ok(listaJugadores);
		}

		[HttpPost("Femeninos")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		public IActionResult AddJugadorFemenino([FromBody] JugadorFemeninoDto jugador)
		{
			var jugadorAgregado = _serviceJugadores.CrearJugador(jugador);
			return Ok(jugadorAgregado);
		}

		[HttpPost("Masculinos")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		public IActionResult AddJugadorMasculino([FromBody] JugadorMasculinoDto jugador)
		{
			var jugadorAgregado = _serviceJugadores.CrearJugador(jugador);
			return Ok(jugadorAgregado);
		}

	}
}
