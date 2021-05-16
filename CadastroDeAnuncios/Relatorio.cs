

namespace CadastroDeAnuncios
{
    public class Relatorio
    {
        public float visualizacoesTotais { private set; get; }
        public float clicksTotais { private set; get; }
        public float investimentoTotal { private set; get; }
        public int CompartilhamentoTotal { private set; get; }

        public Relatorio(float visualizacoesTotais, float clicksTotais, float investimentoTotal, int compartilhamentoTotal)
        {
            this.visualizacoesTotais = visualizacoesTotais;
            this.clicksTotais = clicksTotais;
            this.investimentoTotal = investimentoTotal;
            CompartilhamentoTotal = compartilhamentoTotal;
        }
    }
}
