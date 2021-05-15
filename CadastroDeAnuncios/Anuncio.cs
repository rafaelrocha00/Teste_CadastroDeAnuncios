using System;

namespace CadastroDeAnuncios
{
    /// <summary>
    /// A classe de anuncio base.
    /// </summary>
    public class Anuncio
    {
        public string nome { get; private set; }
        public string cliente { get; private set; }
        public DateTime dataInicio { get; private set; }
        public DateTime dataTermino { get; private set; }
        float investimentoPorDia;

        public Anuncio(string nome, string cliente, DateTime dataInicio, DateTime dataTermino, float investimentoPorDia)
        {
            this.nome = nome;
            this.cliente = cliente;
            this.dataInicio = dataInicio;
            this.dataTermino = dataTermino;
            this.investimentoPorDia = investimentoPorDia;
        }

        public Anuncio()
        {

        }

        /// <summary>
        /// Fornece uma string formatada com as informações do anuncio.
        /// </summary>
        /// <returns></returns>
        public string FornecerRelatorio()
        {
            float views = GetViewsAteAgora();
            return "# Nome: " + nome + " | Cliente: " + cliente + " | Investimento diario: " + investimentoPorDia.ToString() + " | Visualizações até agora: " + views;
        }

        TimeSpan FornecerTempoPassado(DateTime dia)
        {
            return dia - dataInicio;
        }

        /// <summary>
        /// Retorna todo o investimento feito diariamente até o dia de hoje, respeitando o dia de término do anuncio.
        /// </summary>
        /// <returns></returns>
        public float GetInvestimentoTotalAteAgora()
        {
            float investimentoTotal = 0;
            TimeSpan diasPassados = FornecerTempoPassado(DateTime.Now);

            if(DateTime.Now > dataTermino)
            {
                diasPassados = FornecerTempoPassado(dataTermino);
            }

            for (int i = 0; i < diasPassados.TotalDays; i++)
            {
                investimentoTotal += investimentoPorDia;
            }
            return investimentoTotal;
        }

        /// <summary>
        /// Retorna as visualizações aproximadas da data de inicio até agora.
        /// </summary>
        /// <returns></returns>
        public float GetViewsAteAgora()
        {
            CalculadoraDeAnuncios calculadora = new CalculadoraDeAnuncios();
            calculadora.Investir(GetInvestimentoTotalAteAgora());
            return calculadora.ProjetarVisualizacoesGanhasAteAgora();
        }

        /// <summary>
        /// Retorna True se essa classe possuir valores dentro dos determinados pelo template, que não estejam vazios.
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public bool Filtar(Anuncio template)
        {
            bool igual = true;

            if (template.cliente != "")
            {
                igual = cliente == template.cliente;
            }
            if (template.dataInicio != DateTime.MinValue)
            {
                igual = dataInicio >= template.dataInicio;
            }
            if (template.dataTermino != DateTime.MinValue)
            {
                igual = dataTermino <= template.dataTermino;
            }

            return igual;
        }

        /// <summary>
        /// Devolve as informações da classe em uma string.
        /// </summary>
        /// <returns></returns>
        public string PegarInformacoesParaSalvar()
        {
            return nome + "|" + cliente + "|" + dataInicio.ToString() + "|" + dataTermino.ToString() + "|" + investimentoPorDia;
        }

        /// <summary>
        /// Carrega as informações na classe passadas pela string.
        /// </summary>
        /// <param name="info"></param>
        public void Carregar(string info)
        {
            string[] infoSeparada = info.Split('|');

            nome = infoSeparada[0];
            cliente = infoSeparada[1];
            dataInicio = DateTime.Parse(infoSeparada[2]);
            dataTermino = DateTime.Parse(infoSeparada[3]);
            investimentoPorDia = float.Parse(infoSeparada[4]);

        }
    }
}
