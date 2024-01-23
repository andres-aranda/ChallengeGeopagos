using AutoMapper;
using Business.Services.Interfeces;
using Business.Services;
using Data.Repositorios.Interfaces;
using Dtos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Dominio;
using Data.Dominio.Interfaces;
using System.Linq.Expressions;

namespace TestGeoPagosApp
{
	[TestFixture]
	public class ServiceTorneosTests
	{
		[Test]
		public void CrearTorneo_CantidadJugadoresDos_NoCreaTorneo()
		{
			// Arrange
			var mapperMock = new Mock<IMapper>();
			var repoTorneosMock = new Mock<IRepositorioTorneos>();
			var servicePartidosMock = new Mock<IServicePartidos>();

			var serviceTorneos = new ServiceTorneos(mapperMock.Object, repoTorneosMock.Object, servicePartidosMock.Object);

			var jugadoresDto = new List<IJugadorDto>
		{
			new JugadorMasculinoDto { Id = 1 },
			new JugadorMasculinoDto { Id = 2 },
			new JugadorMasculinoDto { Id = 3 },
			new JugadorMasculinoDto { Id = 4 }
		};

			servicePartidosMock.Setup(sp => sp.CrearPartidos(It.IsAny<List<IJugadorDto>>()))
							  .Returns(new List<IPartidoDto> { new PartidoMasculinoDto(), new PartidoMasculinoDto() });

			// Act
			var result = serviceTorneos.CrearTorneo(jugadoresDto);

			// Assert
			repoTorneosMock.Verify(repo => repo.Add(It.IsAny<Torneo>()), Times.Once);
			Assert.IsNull(result);
		}

		[Test]
		public void CrearTorneo_CantidadJugadoresImpar_NoCreaTorneo()
		{
			// Arrange
			var mapperMock = new Mock<IMapper>();
			var repoTorneosMock = new Mock<IRepositorioTorneos>();
			var servicePartidosMock = new Mock<IServicePartidos>();

			var serviceTorneos = new ServiceTorneos(mapperMock.Object, repoTorneosMock.Object, servicePartidosMock.Object);

			var jugadoresDto = new List<IJugadorDto>
		{
			new JugadorMasculinoDto { Id = 1 },
			new JugadorMasculinoDto { Id = 2 },
			new JugadorMasculinoDto { Id = 3 }
		};

			// Act
			var result = serviceTorneos.CrearTorneo(jugadoresDto);

			// Assert
			repoTorneosMock.Verify(repo => repo.Add(It.IsAny<Torneo>()), Times.Never);
			Assert.IsNull(result);
		}
		[Test]
		public void FinalizarTorneo_TorneoExistente_FinalizaTorneoCorrectamente()
		{
			// Arrange
			var mapperMock = new Mock<IMapper>();
			var repoTorneosMock = new Mock<IRepositorioTorneos>();
			var servicePartidosMock = new Mock<IServicePartidos>();

			var serviceTorneos = new ServiceTorneos(mapperMock.Object, repoTorneosMock.Object, servicePartidosMock.Object);

			var torneoDto = new TorneoDto { Id = 1, PartidosMasculinos = new List<PartidoMasculinoDto>(), PartidosFemeninos = new List<PartidoFemeninoDto>() };

			var torneo = new Torneo { Id = 1, PartidosMasculinos = new List<PartidoMasculino>(), PartidosFemeninos = new List<PartidoFemenino>() };

			repoTorneosMock.Setup(repo => repo.GetById(1)).Returns(torneo);
			mapperMock.Setup(mapper => mapper.Map<Torneo, TorneoDto>(torneo)).Returns(torneoDto);

			// Act
			var result = serviceTorneos.FinalizarTorneo(1);

			// Assert
			repoTorneosMock.Verify(repo => repo.FinalizarTorneo(1), Times.Once);
			Assert.IsNotNull(result);
			Assert.AreEqual(torneoDto, result);
		}

		[Test]
		public void FinalizarTorneo_TorneoNoExistente_RetornaNull()
		{
			// Arrange
			var mapperMock = new Mock<IMapper>();
			var repoTorneosMock = new Mock<IRepositorioTorneos>();
			var servicePartidosMock = new Mock<IServicePartidos>();

			var serviceTorneos = new ServiceTorneos(mapperMock.Object, repoTorneosMock.Object, servicePartidosMock.Object);

			repoTorneosMock.Setup(repo => repo.GetById(1)).Returns((Torneo)null);

			// Act
			var result = serviceTorneos.FinalizarTorneo(1);

			// Assert
			repoTorneosMock.Verify(repo => repo.FinalizarTorneo(1), Times.Never);
			Assert.IsNull(result);
		}

	}
}
