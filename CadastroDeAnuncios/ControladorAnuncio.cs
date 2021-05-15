using System;
using System.Collections.Generic;

namespace CadastroDeAnuncios
{
    public class ControladorAnuncio
    {
        ControladorSave save = new ControladorSave();
        RepositorioDeAnuncios repositorioAnuncio = new RepositorioDeAnuncios();

        /// <summary>
        /// Cria um anúncio e o coloca no repositorio.
        /// </summary>
        public void CriarAnuncio(string nome, string nomeCliente, DateTime dataTimeInicio, DateTime dataTimeFim, float investimentoDiario) 
        {
            Anuncio anuncio = new Anuncio(nome, nomeCliente, dataTimeInicio, dataTimeFim, investimentoDiario);
            repositorioAnuncio.AdicionarAnuncio(anuncio);
        }

        /// <summary>
        /// Retorna um relatorio de um anúncio pelo nome.
        /// </summary>
        /// <param name="nomeAnuncio"></param>
        /// <returns></returns>
        public string FornecerRelatorio(string nomeAnuncio)
        {
            Anuncio anuncio = repositorioAnuncio.GetAnuncioPorNome(nomeAnuncio);
            if(anuncio != null)
            {
                return anuncio.FornecerRelatorio();
            }


            return "Não encontrou anuncio.";
        }

        /// <summary>
        /// Retorna os relatorios de todos os anúncios que passarem pela filtragem.
        /// </summary>
        public string[] FornecerRelatorios(Anuncio filtragemTemplate)
        {
            List<Anuncio> encontrados = repositorioAnuncio.GetAnunciosPorFiltros(filtragemTemplate);
            List<string> relatorios = new List<string>();
            for (int i = 0; i < encontrados.Count; i++)
            {
                relatorios.Add(encontrados[i].FornecerRelatorio());
            }

            return relatorios.ToArray();
        }

        /// <summary>
        /// Salva o repositorio em disco.
        /// </summary>
        public void Salvar()
        {
            save.Salvar(repositorioAnuncio);
        }

        /// <summary>
        /// Carrega o repositorio do disco.
        /// </summary>
        public void Carregar()
        {
            save.Carregar(repositorioAnuncio);
        }

    }
}
