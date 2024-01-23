using AutoMapper;
using Business.Services;
using Data.Dominio;
using Data.Repositorios.Interfaces;
using Dtos;
using Moq;

namespace TestGeoPagosApp
{

	[TestFixture]
	public class ServiceJugadoresTests
	{
		[Test]
		public void GetAllJugadoresMasculinos_ReturnsAllMasculinos()
		{
			// Arrange
			var mapperMock = new Mock<IMapper>();
			var repoMasculinosMock = new Mock<IRepositorioJugadoresMasculinos>();
			var repoFemeninosMock = new Mock<IRepositorioJugadoresFemeninos>();

			var serviceJugadores = new ServiceJugadores(mapperMock.Object, repoFemeninosMock.Object, repoMasculinosMock.Object);

			var jugadoresMasculinosDominio = new List<JugadorMasculino>
		{
			new JugadorMasculino { Id = 1, Nombre = "Jugador1" },
			new JugadorMasculino { Id = 2, Nombre = "Jugador2" }
		};

			var jugadoresMasculinosDto = new List<JugadorMasculinoDto>
		{
			new JugadorMasculinoDto { Id = 1, Nombre = "Jugador1" },
			new JugadorMasculinoDto { Id = 2, Nombre = "Jugador2" }
		};

			repoMasculinosMock.Setup(repo => repo.GetAll()).Returns(jugadoresMasculinosDominio);
			mapperMock.Setup(mapper => mapper.Map<List<JugadorMasculinoDto>>(jugadoresMasculinosDominio)).Returns(jugadoresMasculinosDto);

			// Act
			var result = serviceJugadores.GetAllJugadoresMasculinos();

			// Assert
			CollectionAssert.AreEqual(jugadoresMasculinosDto, result);
		}

		[Test]
		public void GetAllJugadoresFemeninos_ReturnsAllFemeninos()
		{
			// Arrange
			var mapperMock = new Mock<IMapper>();
			var repoMasculinosMock = new Mock<IRepositorioJugadoresMasculinos>();
			var repoFemeninosMock = new Mock<IRepositorioJugadoresFemeninos>();

			var serviceJugadores = new ServiceJugadores(mapperMock.Object, repoFemeninosMock.Object, repoMasculinosMock.Object);

			var jugadoresFemeninosDominio = new List<JugadorFemenino>
		{
			new JugadorFemenino { Id = 1, Nombre = "Jugadora1" },
			new JugadorFemenino { Id = 2, Nombre = "Jugadora2" }
		};

			var jugadoresFemeninosDto = new List<JugadorFemeninoDto>
		{
			new JugadorFemeninoDto { Id = 1, Nombre = "Jugadora1" },
			new JugadorFemeninoDto { Id = 2, Nombre = "Jugadora2" }
		};

			repoFemeninosMock.Setup(repo => repo.GetAll()).Returns(jugadoresFemeninosDominio);
			mapperMock.Setup(mapper => mapper.Map<List<JugadorFemeninoDto>>(jugadoresFemeninosDominio)).Returns(jugadoresFemeninosDto);

			// Act
			var result = serviceJugadores.GetAllJugadoresFemeninos();

			// Assert
			CollectionAssert.AreEqual(jugadoresFemeninosDto, result);
		}

		[Test]
		public void CrearJugador_Masculino_CreatMasculinoAndReturnsDto()
		{
			// Arrange
			var mapperMock = new Mock<IMapper>();
			var repoMasculinosMock = new Mock<IRepositorioJugadoresMasculinos>();
			var repoFemeninosMock = new Mock<IRepositorioJugadoresFemeninos>();

			var serviceJugadores = new ServiceJugadores(mapperMock.Object, repoFemeninosMock.Object, repoMasculinosMock.Object);

			var jugadorMasculinoDto = new JugadorMasculinoDto { Id = 1, Nombre = "NuevoJugador" };
			var jugadorMasculino = new JugadorMasculino { Id = 1, Nombre = "NuevoJugador" };

			repoMasculinosMock.Setup(repo => repo.Add(It.IsAny<JugadorMasculino>())).Returns(jugadorMasculino);
			mapperMock.Setup(mapper => mapper.Map<JugadorMasculino, JugadorMasculinoDto>(jugadorMasculino)).Returns(jugadorMasculinoDto);
			mapperMock.Setup(mapper => mapper.Map<JugadorMasculinoDto, JugadorMasculino>(jugadorMasculinoDto)).Returns(jugadorMasculino);

			// Act
			var result = serviceJugadores.CrearJugador(jugadorMasculinoDto);

			// Assert
			repoMasculinosMock.Verify(repo => repo.Add(It.IsAny<JugadorMasculino>()), Times.Once);
			Assert.AreEqual(jugadorMasculinoDto, result);
		}

		[Test]
		public void CrearJugador_Femenino_CreaFemeninoAndReturnsDto()
		{
			// Arrange
			var mapperMock = new Mock<IMapper>();
			var repoMasculinosMock = new Mock<IRepositorioJugadoresMasculinos>();
			var repoFemeninosMock = new Mock<IRepositorioJugadoresFemeninos>();

			var serviceJugadores = new ServiceJugadores(mapperMock.Object, repoFemeninosMock.Object, repoMasculinosMock.Object);

			var jugadorFemeninoDto = new JugadorFemeninoDto { Id = 1, Nombre = "NuevaJugadora" };
			var jugadorFemenino = new JugadorFemenino { Id = 1, Nombre = "NuevaJugadora" };

			repoFemeninosMock.Setup(repo => repo.Add(It.IsAny<JugadorFemenino>())).Returns(jugadorFemenino);
			mapperMock.Setup(mapper => mapper.Map<JugadorFemenino, JugadorFemeninoDto>(jugadorFemenino)).Returns(jugadorFemeninoDto);
			mapperMock.Setup(mapper => mapper.Map<JugadorFemeninoDto, JugadorFemenino>(jugadorFemeninoDto)).Returns(jugadorFemenino);

			// Act
			var result = serviceJugadores.CrearJugador(jugadorFemeninoDto);

			// Assert
			repoFemeninosMock.Verify(repo => repo.Add(It.IsAny<JugadorFemenino>()), Times.Once);
			Assert.AreEqual(jugadorFemeninoDto, result);
		}



	}
}
