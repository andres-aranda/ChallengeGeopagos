using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGeoPagosApp
{
    using Dtos;
    using NUnit.Framework;

    [TestFixture]
    public class JugadorMasculinoDtoTests
    {
        [Test]
        public void Suerte_ContrincanteConMenorNivelHabilidad_SuertePositiva()
        {
            // Arrange
            var jugador = new JugadorMasculinoDto
            {
                NivelHabilidad = 60,
                Velocidad = 50,
                Fuerza = 70
            };

            var contrincante = new JugadorMasculinoDto
            {
                NivelHabilidad = 50,
                Velocidad = 40,
                Fuerza = 60
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
            var jugador = new JugadorMasculinoDto
            {
                NivelHabilidad = 60,
                Velocidad = 50,
                Fuerza = 0
            };

            var contrincante = new JugadorMasculinoDto
            {
                NivelHabilidad = 70,
                Velocidad = 40,
                Fuerza = 60
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
            var jugador = new JugadorMasculinoDto
            {
                NivelHabilidad = 60,
                Velocidad = 50,
                Fuerza = 70
            };

            var contrincante = new JugadorMasculinoDto
            {
                NivelHabilidad = 60,
                Velocidad = 40,
                Fuerza = 60
            };

            // Act
            var suerte = jugador.Suerte(contrincante);

            // Assert
            Assert.AreEqual(20, suerte);
        }

    }

}
