using System.Collections.Generic;

namespace CadastroDeAnuncios
{
    /// <summary>
    /// Guarda todos os anuncios.
    /// </summary>
    public class RepositorioDeAnuncios
    {
        List<Anuncio> anunciosAtuais = new List<Anuncio>();
        public int Count => anunciosAtuais.Count;

        public Anuncio GetAnuncio(int index)
        {
            return anunciosAtuais[index];
        }

        public void AdicionarAnuncio(Anuncio anuncio)
        {
            anunciosAtuais.Add(anuncio);
        }

        /// <summary>
        /// Retorna todos os anuncios que passarem pela filtragem.
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public List<Anuncio> GetAnunciosPorFiltros(Anuncio template)
        {
            return anunciosAtuais.FindAll(x => x.Filtar(template));
        }

        public Anuncio GetAnuncioPorNome(string nome)
        {
            return anunciosAtuais.Find(x => x.nome == nome);
        }
    }
}
