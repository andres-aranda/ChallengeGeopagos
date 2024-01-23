using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGeoPagosApp
{
    using NUnit.Framework;
    using Moq;
    using Dtos;

    [TestFixture]
    public class PartidoMasculinoDtoTests
    {
        [Test]
        public void DeterminarGanador_Jugador1Gana_GanadorCorrecto()
        {
            // Arrange
            var jugador1Mock = new Mock<JugadorMasculinoDto>();
            jugador1Mock.Setup(j => j.Suerte(It.IsAny<JugadorMasculinoDto>())).Returns(10);

            var jugador2Mock = new Mock<JugadorMasculinoDto>();
            jugador2Mock.Setup(j => j.Suerte(It.IsAny<JugadorMasculinoDto>())).Returns(5);

            var partido = new PartidoMasculinoDto
            {
                Jugador1 = jugador1Mock.Object,
                Jugador2 = jugador2Mock.Object
            };

            // Act
            partido.DeterminarGanador();

            // Assert
            Assert.AreEqual(partido.Jugador1.Id, partido.IdGanador);
            Assert.AreEqual(partido.Jugador1, partido.Ganador);
        }

        [Test]
        public void DeterminarGanador_Jugador2Gana_GanadorCorrecto()
        {
            // Arrange
            var jugador1Mock = new Mock<JugadorMasculinoDto>();
            jugador1Mock.Setup(j => j.Suerte(It.IsAny<JugadorMasculinoDto>())).Returns(5);

            var jugador2Mock = new Mock<JugadorMasculinoDto>();
            jugador2Mock.Setup(j => j.Suerte(It.IsAny<JugadorMasculinoDto>())).Returns(10);

            var partido = new PartidoMasculinoDto
            {
                Jugador1 = jugador1Mock.Object,
                Jugador2 = jugador2Mock.Object
            };

            // Act
            partido.DeterminarGanador();

            // Assert
            Assert.AreEqual(partido.Jugador2.Id, partido.IdGanador);
            Assert.AreEqual(partido.Jugador2, partido.Ganador);
        }

        [Test]
        public void DeterminarGanador_JugadoresNulos_NoAsignaGanador()
        {
            // Arrange
            var partido = new PartidoMasculinoDto();

            // Act
            partido.DeterminarGanador();

            // Assert
            Assert.IsNull(partido.IdGanador);
            Assert.IsNull(partido.Ganador);
        }
    }

}
