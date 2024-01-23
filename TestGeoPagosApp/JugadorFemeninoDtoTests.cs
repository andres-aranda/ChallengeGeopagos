using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGeoPagosApp
{
	[TestFixture]
	public class JugadorFemeninoDtoTests
	{
		[Test]
		public void Suerte_ContrincanteConMenorNivelHabilidad_SuertePositiva()
		{
			// Arrange
			var jugador = new JugadorFemeninoDto
			{
				NivelHabilidad = 60,
				TiempoDeReaccion = 50
			};

			var contrincante = new JugadorFemeninoDto
			{
				NivelHabilidad = 50,
				TiempoDeReaccion = 40
			};

			// Act
			var suerte = jugador.Suerte(contrincante);

			// Assert
			Assert.Greater(suerte, 0);
		}

		[Test]
		public void Suerte_ContrincanteConMayorNivelHabilidad_SuerteNegativa()
		{
			// Arrange
			var jugador = new JugadorFemeninoDto
			{
				NivelHabilidad = 60,
				TiempoDeReaccion = 40
			};

			var contrincante = new JugadorFemeninoDto
			{
				NivelHabilidad = 70,
				TiempoDeReaccion = 40
			};

			// Act
			var suerte = jugador.Suerte(contrincante);

			// Assert
			Assert.Less(suerte, 0);
		}

		[Test]
		public void Suerte_ContrincanteConIgualNivelHabilidad_SuerteCercanaACero()
		{
			// Arrange
			var jugador = new JugadorFemeninoDto
			{
				NivelHabilidad = 60,
				TiempoDeReaccion = 40
			};

			var contrincante = new JugadorFemeninoDto
			{
				NivelHabilidad = 60,
				TiempoDeReaccion = 40
			};

			// Act
			var suerte = jugador.Suerte(contrincante);

			// Assert
			Assert.AreEqual(0, suerte);
		}

		[Test]
		public void Suerte_ContrincanteConMenorTiempoDeReaccion_SuertePositiva()
		{
			// Arrange
			var jugador = new JugadorFemeninoDto
			{
				NivelHabilidad = 50,
				TiempoDeReaccion = 50
			};

			var contrincante = new JugadorFemeninoDto
			{
				NivelHabilidad = 50,
				TiempoDeReaccion = 40
			};

			// Act
			var suerte = jugador.Suerte(contrincante);

			// Assert
			Assert.Greater(suerte, 0);
		}

		[Test]
		public void Suerte_ContrincanteConMayorTiempoDeReaccion_SuerteNegativa()
		{
			// Arrange
			var jugador = new JugadorFemeninoDto
			{
				NivelHabilidad = 60,
				TiempoDeReaccion = 50
			};

			var contrincante = new JugadorFemeninoDto
			{
				NivelHabilidad = 60,
				TiempoDeReaccion = 60
			};

			// Act
			var suerte = jugador.Suerte(contrincante);

			// Assert
			Assert.Less(suerte, 0);
		}

		[Test]
		public void Suerte_ContrincanteConIgualTiempoDeReaccion_SuerteCercanaACero()
		{
			// Arrange
			var jugador = new JugadorFemeninoDto
			{
				NivelHabilidad = 60,
				TiempoDeReaccion = 50
			};

			var contrincante = new JugadorFemeninoDto
			{
				NivelHabilidad = 60,
				TiempoDeReaccion = 50
			};

			// Act
			var suerte = jugador.Suerte(contrincante);

			// Assert
			Assert.AreEqual(0, suerte);
		}

	}
}
