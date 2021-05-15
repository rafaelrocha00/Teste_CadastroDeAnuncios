using CadastroDeAnuncios;
using System.Collections.Generic;

namespace TestesAnuncio
{
    /// <summary>
    /// Simula a ação de input do usuario.
    /// </summary>
    class LeitorDeTestes : ILeitor
    {
        List<string> respostas = new List<string>();
        int index = -1;
        public string Ler()
        {
            if (respostas.Count == 0)
            {
                return "";
            }
            index++;
            return respostas[index];
        }

        public void AdicionarResposta(string resposta)
        {
            respostas.Add(resposta);
        }
    }
}
