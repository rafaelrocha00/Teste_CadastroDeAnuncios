using System;
using CadastroDeAnuncios;
using Xunit;

namespace TestesAnuncio
{
    public class RepositorioDeAnuncios_Testes
    {
        [Fact]
        public void GetAnuncio_UmAnuncio_Corretamente()
        {
            //Arrange
            RepositorioDeAnuncios repositorio = new RepositorioDeAnuncios();
            Anuncio anuncio = new Anuncio("", "", DateTime.MinValue, DateTime.MinValue, 0);
            
            //Act
            repositorio.AdicionarAnuncio(anuncio);

            //Assert
            Assert.Equal(anuncio, repositorio.GetAnuncio(0));
        }

        [Fact]
        public void GetAnuncioPorNome_UmAnuncio_Corretamente()
        {
            //Arrange
            RepositorioDeAnuncios repositorio = new RepositorioDeAnuncios();
            Anuncio anuncio = new Anuncio("anuncio", "", DateTime.MinValue, DateTime.MinValue, 0);

            //Act
            repositorio.AdicionarAnuncio(anuncio);

            //Assert
            Assert.Equal(anuncio, repositorio.GetAnuncioPorNome("anuncio"));
        }

        [Fact]
        public void GetAnuncioPorFiltros_UmAnuncio_Corretamente()
        {
            //Arrange
            RepositorioDeAnuncios repositorio = new RepositorioDeAnuncios();
            Anuncio filtro = new Anuncio("anuncio", "", DateTime.MinValue, DateTime.MinValue, 0);
            Anuncio anuncio = new Anuncio("anuncio", "", DateTime.MinValue, DateTime.MinValue, 0);

            //Act
            repositorio.AdicionarAnuncio(anuncio);

            //Assert
            Assert.Equal(anuncio, repositorio.GetAnunciosPorFiltros(filtro)[0]);
        }
    }
}
