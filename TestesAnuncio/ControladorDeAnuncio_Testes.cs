using System;
using System.Collections.Generic;
using System.Text;
using CadastroDeAnuncios;
using Xunit;

namespace TestesAnuncio
{
    public class ControladorDeAnuncio_Testes
    {
        [Fact]
        public void FornecerRelatorio_UmAnuncio_NaoVazio()
        {
            //Arrange
            ControladorAnuncio controlador = new ControladorAnuncio();
            controlador.CriarAnuncio("anuncio", "", DateTime.MinValue, DateTime.MinValue, 0);

            //Act
            string relatorio = controlador.FornecerRelatorio("anuncio");

            //Assert
            Assert.NotEmpty(relatorio);
            Assert.NotEqual("Não encontrou anuncio.", relatorio);
        }
    }
}
