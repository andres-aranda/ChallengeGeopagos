using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dtos
{ 
	public class JugadorMasculinoDto : IJugadorDto
	{

		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required(ErrorMessage = "El campo Nombre es requerido")]
		public string? Nombre { get; set; }

		[Required(ErrorMessage = "El campo Fuerza es requerido")]
		[Range(0, 100, ErrorMessage = "El campo Fuerza debe estar entre 0 y 100")]
		public int Fuerza { get; set; } = 0;

		[Required(ErrorMessage = "El campo Velocidad es requerido")]
		[Range(0, 100, ErrorMessage = "El campo Velocidad debe estar entre 0 y 100")]
		public int Velocidad { get; set; } = 0;

		[Required(ErrorMessage = "El campo Nivel de Habilidad es requerido")]
		[Range(0, 100, ErrorMessage = "El campo Nive de lHabilidad debe estar entre 0 y 100")]
		public int NivelHabilidad { get; set; } = 0;

		public int Suerte(IJugadorDto contrincante)
		{
			var suertePorHabilidad = NivelHabilidad - contrincante.NivelHabilidad;
			var suertePorVelocidad = Velocidad - ((JugadorMasculinoDto)contrincante).Velocidad;
			var suertePorFuerza = Fuerza - ((JugadorMasculinoDto)contrincante).Fuerza;
			return Math.Clamp(suertePorHabilidad + suertePorVelocidad + suertePorFuerza, -40, 40);
		}
	}
}
