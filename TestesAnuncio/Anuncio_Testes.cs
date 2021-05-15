using System;
using Xunit;
using CadastroDeAnuncios;

namespace TestesAnuncio
{
    public class Anuncio_Testes
    {
        [Fact]
        public void Filtrar_UmAnuncioPeloCliente_Corretamente()
        {
            // Arrange
            Anuncio aSerTestado =     new Anuncio("", "cliente", DateTime.MinValue, DateTime.MinValue, 0);
            Anuncio templateCliente = new Anuncio("", "cliente", DateTime.MinValue, DateTime.MinValue, 0);

            //Act
            bool TEMPLATE_FOIRECONHECIDO = aSerTestado.Filtar(templateCliente);

            // Assert
            Assert.True(TEMPLATE_FOIRECONHECIDO);
        }

        [Fact]
        public void Filtrar_UmAnuncioPeloCliente_Erroneamente()
        {
            // Arrange
            Anuncio aSerTestado =     new Anuncio("", "cliente", DateTime.MinValue, DateTime.MinValue, 0);
            Anuncio templateCliente = new Anuncio("", "erro", DateTime.MinValue, DateTime.MinValue, 0);

            //Act
            bool TEMPLATE_FOIRECONHECIDO = aSerTestado.Filtar(templateCliente);

            // Assert
            Assert.False(TEMPLATE_FOIRECONHECIDO);
        }
        
        [Fact]
        public void Filtrar_UmAnuncioPorDataMinima_Corretamente()
        {
            // Arrange
            Anuncio aSerTestado = new Anuncio("", "", new DateTime(2000, 09, 01), DateTime.MinValue, 0);
            Anuncio templateCliente = new Anuncio("", "", new DateTime(1999, 01, 01), DateTime.MinValue, 0);

            //Act
            bool TEMPLATE_FOIRECONHECIDO = aSerTestado.Filtar(templateCliente);

            // Assert
            Assert.True(TEMPLATE_FOIRECONHECIDO);
        }

        [Fact]
        public void Filtrar_UmAnuncioPorDataMinima_Erroneamente()
        {
            // Arrange
            Anuncio aSerTestado = new Anuncio("", "", new DateTime(2000, 09, 01), DateTime.MinValue, 0);
            Anuncio templateCliente = new Anuncio("", "", new DateTime(2005, 01, 01), DateTime.MinValue, 0);

            //Act
            bool TEMPLATE_FOIRECONHECIDO = aSerTestado.Filtar(templateCliente);

            // Assert
            Assert.False(TEMPLATE_FOIRECONHECIDO);
        }

        [Fact]
        public void Filtrar_UmAnuncioPorDataMaxima_Corretamente()
        {
            // Arrange
            Anuncio aSerTestado = new Anuncio("", "", DateTime.MinValue, new DateTime(2002, 11, 01), 0);
            Anuncio templateCliente = new Anuncio("", "", DateTime.MinValue, new DateTime(2004, 01, 01), 0);

            //Act
            bool TEMPLATE_FOIRECONHECIDO = aSerTestado.Filtar(templateCliente);

            // Assert
            Assert.True(TEMPLATE_FOIRECONHECIDO);
        }

        [Fact]
        public void Filtrar_UmAnuncioPorDataMaxima_Erroneamente()
        {
            // Arrange
            Anuncio aSerTestado = new Anuncio("", "", DateTime.MinValue, new DateTime(2002, 11, 01), 0);
            Anuncio templateCliente = new Anuncio("", "", DateTime.MinValue, new DateTime(1999, 01, 01), 0);

            //Act
            bool TEMPLATE_FOIRECONHECIDO = aSerTestado.Filtar(templateCliente);

            // Assert
            Assert.False(TEMPLATE_FOIRECONHECIDO);
        }

        [Fact]
        public void Filtrar_UmAnuncioPorPeriodo_Corretamente()
        {
            // Arrange
            Anuncio aSerTestado = new Anuncio("", "", new DateTime(2001, 01, 01), new DateTime(2001, 01, 01), 0);
            Anuncio templateCliente = new Anuncio("", "", new DateTime(2000, 01, 01), new DateTime(2002, 01, 01), 0);

            //Act
            bool TEMPLATE_FOIRECONHECIDO = aSerTestado.Filtar(templateCliente);

            // Assert
            Assert.True(TEMPLATE_FOIRECONHECIDO);
        }

        [Fact]
        public void Filtrar_UmAnuncioPorPeriodo_Erroneamente()
        {
            // Arrange
            Anuncio aSerTestado = new Anuncio("", "", new DateTime(2002, 01, 02), new DateTime(2002, 01, 02), 0);
            Anuncio templateCliente = new Anuncio("", "", new DateTime(2000, 01, 01), new DateTime(2002, 01, 01), 0);

            //Act
            bool TEMPLATE_FOIRECONHECIDO = aSerTestado.Filtar(templateCliente);

            // Assert
            Assert.False(TEMPLATE_FOIRECONHECIDO);
        }

        [Fact]
        public void Carregar_NomeDoAnuncio_Corretamente()
        {
            // Arrange
            Anuncio anuncio = new Anuncio();

            //Act
            anuncio.Carregar("nome|cliente|01/01/2000 00:00:00|01/01/2000 00:00:00|0");

            // Assert
            Assert.Equal("nome", anuncio.nome);
        }

        [Fact]
        public void Carregar_NomeDoCliente_Corretamente()
        {
            // Arrange
            Anuncio anuncio = new Anuncio();

            //Act
            anuncio.Carregar("nome|cliente|01/01/2000 00:00:00|01/01/2000 00:00:00|0");

            // Assert
            Assert.Equal("cliente", anuncio.cliente);
        }

        [Fact]
        public void PegarInformacoesParaSalvar_InformacoesDeAnuncio_Corretamente()
        {
            // Arrange
            Anuncio anuncio = new Anuncio("nome", "", DateTime.MinValue, DateTime.MinValue, 0);

            //Act
            string info = anuncio.PegarInformacoesParaSalvar();

            // Assert
            Assert.Equal("nome", info.Split("|")[0]);
        }

    }
}
