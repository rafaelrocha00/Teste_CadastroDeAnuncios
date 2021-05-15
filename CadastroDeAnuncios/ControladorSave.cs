using System;
using System.IO;

namespace CadastroDeAnuncios
{
    class ControladorSave
    {
        string path = Environment.CurrentDirectory;
        string nomeDoArquivo = "Anuncios.txt";

        /// <summary>
        /// Salva o repositorio em um arquivo de texto.
        /// </summary>
        /// <param name="anuncios">Repositorio para salvar.</param>
        public void Salvar(RepositorioDeAnuncios anuncios)
        {
            string salvar = "";

            for (int i = 0; i < anuncios.Count; i++)
            {
                salvar += anuncios.GetAnuncio(i).PegarInformacoesParaSalvar();
                salvar += Environment.NewLine;
            }


            File.WriteAllText(path + @"\" + nomeDoArquivo, salvar);
        }

        /// <summary>
        /// Carrega os anúncios de um arquivo de texto para o repositorio.
        /// </summary>
        /// <param name="anuncios">Repositorio para onde carregar os anúncios.</param>
        public void Carregar(RepositorioDeAnuncios anuncios)
        {
            string[] info = File.ReadAllLines(path + @"\" + nomeDoArquivo);
            for (int i = 0; i < info.Length; i++)
            {
                Anuncio novoAnuncio = new Anuncio();
                novoAnuncio.Carregar(info[i]);
                anuncios.AdicionarAnuncio(novoAnuncio);
            }

        }
    }
}
