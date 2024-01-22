﻿using System.ComponentModel.DataAnnotations;

namespace Dtos
{
	public class JugadorFemeninoDto : IJugadorDto
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "El nombre es requerido")]
		public string? Nombre { get; set; }

		[Required(ErrorMessage = "El nivel de habilidad es requerido")]
		[Range(1, 100, ErrorMessage = "El nivel de habilidad debe estar entre 1 y 100")]
		public int NivelHabilidad { get; set; }

		[Required(ErrorMessage = "El tiempo de reacción es requerido")]
		[Range(0, 100, ErrorMessage = "El tiempo de reacción debe estar entre 0 y 100")]
		public int TiempoDeReaccion { get; set; }

		public int Suerte(IJugadorDto contrincante)
		{
			var suertePorHabilidad = NivelHabilidad - contrincante.NivelHabilidad;
			var suertePorTiempoDeReaccion = TiempoDeReaccion - ((JugadorFemeninoDto)contrincante).TiempoDeReaccion;
			return Math.Clamp(suertePorHabilidad + suertePorTiempoDeReaccion, -40, 40);
		}
	}
}
