using Xunit;
using CadastroDeAnuncios;
using System;

namespace TestesAnuncio
{
    public class CalculadoraDeAnuncios_Testes
    {
        CalculadoraDeAnuncios calculadora;

        [Theory]
        [InlineData(100, 7560)]
        [InlineData(50, 3780)]
        public void ProjetarVisualizacoes_Investe_DevolveVisualizacoesCorretas(float investimento, float retornoEmVisualizacoes)
        {
            // Arrange
            calculadora = new CalculadoraDeAnuncios();
            calculadora.Investir(investimento);

            // Act
            float visualizacoes = calculadora.ProjetarVisualizacoesGanhasAteAgora();

            // Assert 
            Assert.Equal(visualizacoes, retornoEmVisualizacoes);
        }
    }
}
