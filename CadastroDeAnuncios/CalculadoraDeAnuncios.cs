using System;

namespace CadastroDeAnuncios
{
    public class CalculadoraDeAnuncios
    {
        public float dinheiroInvestido { get; private set; }
        public int clicksTotais { get; private set; }
        public int compartilhamentosTotais { get; private set; }

        const int visualizacoesPorReal = 30;
        const int maximoDeCompartilhamento = 4;
        const int VisualizacoesPorCompartilhamento = 40;

        /// <summary>
        /// Investe dinheiro para as projeções de visualização.
        /// </summary>
        public void Investir(float valorAInvestir)
        {
            dinheiroInvestido += valorAInvestir;
        }

        /// <summary>
        /// Retorna uma aproximação de visualizações máxima baseado no dinheiro investido.
        /// </summary>
        /// <returns></returns>
        public int ProjetarVisualizacoesGanhasAteAgora()
        {
            int visualizacoesIniciais = CalcularVisualizacoesIniciais();
            int visualizacoesPosteriores = CompartilhamentosToVisualizacoes(visualizacoesIniciais);
            for (int i = 0; i < maximoDeCompartilhamento - 1; i++)
            {
                visualizacoesIniciais += visualizacoesPosteriores;
                if(i < maximoDeCompartilhamento - 2)
                {
                    visualizacoesPosteriores = CompartilhamentosToVisualizacoes(visualizacoesPosteriores);
                }
            }
            return visualizacoesIniciais;
        }

        /// <summary>
        /// Retorna as visualizações obtidas pelos compartilhamentos.
        /// </summary>
        /// <param name="visualizacoes"></param>
        /// <returns></returns>
        int CompartilhamentosToVisualizacoes(int visualizacoes)
        {
            int clicks = CalcularClicks(visualizacoes);
            clicksTotais += clicks;
            int compartilhamentos = CalcularCompartilhamentos(clicks);
            compartilhamentosTotais += compartilhamentos;
            return compartilhamentos * VisualizacoesPorCompartilhamento;
        }

        int CalcularVisualizacoesIniciais()
        {
            return (int)dinheiroInvestido * visualizacoesPorReal;
        }

        int CalcularClicks(float visualizacoes)
        {
            return (int)Math.Floor(visualizacoes / 100) * 12;
        }

        int CalcularCompartilhamentos(float clicks)
        {
            return (int)Math.Floor(clicks / 20) * 3;
        }

    }
}
