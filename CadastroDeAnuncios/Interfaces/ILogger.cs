using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroDeAnuncios
{
    public interface ILogger
    {
        public void Escrever(string texto);
        public string[] GetLog();
    }
}
