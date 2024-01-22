using Business.Services.Interfeces;
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
		[ProducesResponseType(StatusCodes.Status201Created)]
		public IActionResult AddJugadorFemenino([FromBody] Dtos.JugadorFemeninoDto jugadorFemenino)
		{
			_serviceJugadores.CrearJugador(jugadorFemenino);
			return Created();
		}

	}
}
