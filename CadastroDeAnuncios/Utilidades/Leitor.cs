using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroDeAnuncios
{
    public class Leitor : ILeitor
    {
        public string Ler()
        {
            return Console.ReadLine();
        }
    }
}
