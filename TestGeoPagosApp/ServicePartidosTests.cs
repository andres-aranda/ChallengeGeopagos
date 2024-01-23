using AutoMapper;
using Business.Services;
using Data.Dominio;
using Data.Repositorios.Interfaces;
using Dtos;
using Moq;

namespace TestGeoPagosApp
{
	[TestFixture]
	public class ServicePartidosTests
	{
		[Test]
		public void CrearPartidos_CantidadJugadoresPar_CreaPartidosCorrectos()
		{
			// Arrange
			var mapperMock = new Mock<IMapper>();
			var repoMasculinosMock = new Mock<IRepositorioPartidosMasculinos>();
			var repoFemeninosMock = new Mock<IRepositorioPartidosFemeninos>();

			var servicePartidos = new ServicePartidos(mapperMock.Object, repoFemeninosMock.Object, repoMasculinosMock.Object);

			var jugadoresDto = new List<IJugadorDto>
		{
			new JugadorMasculinoDto { Id = 1 },
			new JugadorMasculinoDto { Id = 2 },
			new JugadorMasculinoDto { Id = 3 },
			new JugadorMasculinoDto { Id = 4 }
		};

			// Act
			var partidosDto = servicePartidos.CrearPartidos(jugadoresDto);

			// Assert
			Assert.AreEqual(2, partidosDto.Count);
			Assert.IsInstanceOf<PartidoMasculinoDto>(partidosDto[0]);
			Assert.IsInstanceOf<PartidoMasculinoDto>(partidosDto[1]);

			// Aquí puedes realizar más aserciones según tus necesidades específicas
		}

		[Test]
		public void DeterminarGanadores_ActualizaRepositoriosCorrectamente()
		{
			// Arrange
			var mapperMock = new Mock<IMapper>();
			var repoMasculinosMock = new Mock<IRepositorioPartidosMasculinos>();
			var repoFemeninosMock = new Mock<IRepositorioPartidosFemeninos>();

			var servicePartidos = new ServicePartidos(mapperMock.Object, repoFemeninosMock.Object, repoMasculinosMock.Object);

			var partidosDto = new List<IPartidoDto>
		{
			new PartidoMasculinoDto { Id = 1 },
			new PartidoMasculinoDto { Id = 2 }
		};

			// Act
			var result = servicePartidos.DeterminarGanadores(partidosDto);

			// Assert
			repoMasculinosMock.Verify(repo => repo.Update(It.IsAny<PartidoMasculino>()), Times.Exactly(2));
			repoFemeninosMock.Verify(repo => repo.Update(It.IsAny<PartidoFemenino>()), Times.Never());
			Assert.AreEqual(partidosDto, result);
		}
		[Test]
		public void CrearPartidos_CantidadJugadoresImpar_NoCreaPartidos()
		{
			// Arrange
			var mapperMock = new Mock<IMapper>();
			var repoMasculinosMock = new Mock<IRepositorioPartidosMasculinos>();
			var repoFemeninosMock = new Mock<IRepositorioPartidosFemeninos>();

			var servicePartidos = new ServicePartidos(mapperMock.Object, repoFemeninosMock.Object, repoMasculinosMock.Object);

			var jugadoresDto = new List<IJugadorDto>
		{
			new JugadorMasculinoDto { Id = 1 },
			new JugadorMasculinoDto { Id = 2 },
			new JugadorMasculinoDto { Id = 3 }
		};

			// Act
			var result = servicePartidos.CrearPartidos(jugadoresDto);

			// Assert
			repoMasculinosMock.Verify(repo => repo.Add(It.IsAny<PartidoMasculino>()), Times.Never);
			repoFemeninosMock.Verify(repo => repo.Add(It.IsAny<PartidoFemenino>()), Times.Never);
			Assert.IsEmpty(result);
		}

		[Test]
		public void CrearProximoPartido_TorneoDiferente_RetornaNull()
		{
			// Arrange
			var mapperMock = new Mock<IMapper>();
			var repoMasculinosMock = new Mock<IRepositorioPartidosMasculinos>();
			var repoFemeninosMock = new Mock<IRepositorioPartidosFemeninos>();

			var servicePartidos = new ServicePartidos(mapperMock.Object, repoFemeninosMock.Object, repoMasculinosMock.Object);

			var partidoDto1 = new PartidoMasculinoDto { Id = 1, IdGanador = 2, IdTorneo = 1 };
			var partidoDto2 = new PartidoMasculinoDto { Id = 2, IdGanador = 3, IdTorneo = 2 };

			// Act
			var result = servicePartidos.CrearProximoPartido(partidoDto1, partidoDto2);

			// Assert
			Assert.IsNull(result);
		}
	}
}
