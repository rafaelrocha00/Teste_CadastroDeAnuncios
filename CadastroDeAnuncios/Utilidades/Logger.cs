using System;
using System.Collections.Generic;

namespace CadastroDeAnuncios
{
    /// <summary>
    /// Responsavel por escrever e guardar texto do console. 
    /// </summary>
    public class Logger : ILogger
    {
        List<string> textoAteAgora = new List<string>();
        bool escreverNoConsole = true;

        /// <summary>
        /// Escreve o texto no console e o guarda em uma lista.
        /// </summary>
        /// <param name="texto"></param>
        public void Escrever(string texto)
        {
            textoAteAgora.Add(texto);
            if (escreverNoConsole)
            {
                Console.WriteLine(texto);
            }
        }

        /// <summary>
        /// Retorna todos os textos escritos no console desde o inicio do programa.
        /// </summary>
        /// <returns></returns>
        public string[] GetLog()
        {
            return textoAteAgora.ToArray();
        }

        public void PararDeEscreverNoConsole()
        {
            escreverNoConsole = false;
        }
    }
}
