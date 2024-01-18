using Data.Dominio.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Data.Dominio
{
	public class JugadorMasculino : IJugadorMasculino
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "El campo Nombre es requerido")]
		public string? Nombre { get; set; }

		[Required(ErrorMessage = "El campo Fuerza es requerido")]
		[Range(0, 100, ErrorMessage = "El campo Fuerza debe estar entre 0 y 100")]
		public int Fuerza { get; set; }

		[Required(ErrorMessage = "El campo Velocidad es requerido")]
		[Range(0, 100, ErrorMessage = "El campo Velocidad debe estar entre 0 y 100")]
		public int Velocidad { get; set; }

		[Required(ErrorMessage = "El campo Nivel de Habilidad es requerido")]
		[Range(0, 100, ErrorMessage = "El campo Nive de lHabilidad debe estar entre 0 y 100")]
		public int NivelHabilidad { get; set; }
	}
}
