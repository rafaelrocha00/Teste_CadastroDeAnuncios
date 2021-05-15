using System;

namespace CadastroDeAnuncios
{
    /// <summary>
    /// A classe que lida com o Input e Output do usuario.
    /// </summary>
    public class View
    {
        ILogger logger;
        ILeitor leitor;
        ControladorAnuncio C_Anuncio;
        bool funcionando;

        public View(ControladorAnuncio controlador, ILogger logger, ILeitor leitor)
        {
            C_Anuncio = controlador;
            this.logger = logger;
            this.leitor = leitor;
        }

        /// <summary>
        /// Inicializa a view para o usuario.
        /// </summary>
        /// <param name="controlador"></param>
        public void MostrarView()
        {
            funcionando = true;
            ProcessarMainLoop();
        }

        void ProcessarMainLoop()
        {
            while (funcionando)
            {
                MostrarTelaPrincipal();
                LidarComInput(leitor.Ler().ToUpper());
            }
        }

        void MostrarTelaPrincipal()
        {
            logger.Escrever(Environment.NewLine);
            logger.Escrever("1 - Cadastrar Anuncio.");
            logger.Escrever("2 - Ver Anuncio especifico.");
            logger.Escrever("3 - Ver conjunto de Anuncios.");
            logger.Escrever("4 - Salvar anúncios em disco.");
            logger.Escrever("5 - Carregar anúncios do disco.");
            logger.Escrever("X - Sair.");
        }

        void LidarComInput(string input)
        {
            switch (input)
            {
                case "1":
                    CriarAnuncio();
                    break;
                case "2":
                    VerAnuncio();
                    break;
                case "3":
                    VerConjuntoDeAnuncios();
                    break;
                case "4":
                    Salvar();
                    break;
                case "5":
                    Carregar();
                    break;
                case "X":
                    Sair();
                    break;
                default:
                    logger.Escrever("Esse não é um comando válido.");
                    break;
            }
        }

        void Sair()
        {
            funcionando = false;
        }

        void Salvar()
        {
            C_Anuncio.Salvar();
        }

        void Carregar()
        {
            C_Anuncio.Carregar();
        }

        void CriarAnuncio()
        {
            string nome = GetNomeDoAnuncioInput();
            string nomeCliente = GetNomeDoClienteInput();
            DateTime dataTimeInicio = GetDataDeInicio();

            if (dataTimeInicio == DateTime.MaxValue)
            {
                return;
            }

            DateTime dataTimeFim = GetDataDeFim();

            if (dataTimeFim == DateTime.MaxValue)
            {
                return;
            }

            float investimentoDiario = GetInvestimentoDiario();

            if(investimentoDiario < 0)
            {
                logger.Escrever("Esse valor não é válido.");
                return;
            }

            C_Anuncio.CriarAnuncio(nome, nomeCliente, dataTimeInicio, dataTimeFim, investimentoDiario);
        }

        string GetNomeDoAnuncioInput()
        {
            logger.Escrever("Digite o nome do anuncio.");
            return leitor.Ler();
        }

        string GetNomeDoClienteInput()
        {
            logger.Escrever("Digite o nome do cliente.");
            return leitor.Ler();
        }

        float GetInvestimentoDiario()
        {
            logger.Escrever("Digite o investimento diario.");
            UtilitariosParse parse = new UtilitariosParse(logger);
            return parse.ParseFloat(leitor.Ler());
        }

        DateTime GetDataDeInicio()
        {
            logger.Escrever("Digite a data de inicio. aaaa-mm-dd.");
            string dataInicio = leitor.Ler();
            UtilitariosParse parse = new UtilitariosParse(logger);
            return parse.ParseDate(dataInicio);
        }

        DateTime GetDataDeFim()
        {
            logger.Escrever("Digite a data de término. aaaa-mm-dd.");
            string dataFim = leitor.Ler();
            UtilitariosParse parse = new UtilitariosParse(logger);
            return parse.ParseDate(dataFim);
        }

        

        void VerAnuncio()
        {
            string nome = GetNomeDoAnuncioInput();
            logger.Escrever(C_Anuncio.FornecerRelatorio(nome));
        }

        /// <summary>
        /// Retorna o relatorio de anuncios baseado em filtros do usuario.
        /// </summary>
        void VerConjuntoDeAnuncios()
        {
            logger.Escrever("Você quer filtar por cliente? S/N");
            string input = leitor.Ler();
            string cliente = "";
            if (input.ToUpper() == "S")
            {
                cliente = GetNomeDoClienteInput();
            }

            logger.Escrever("Você quer filtrar por data mínima? S/N");
            input = leitor.Ler();
            DateTime dateTimeInicial = DateTime.MinValue;

            if (input.ToUpper() == "S")
            {
                dateTimeInicial = GetDataDeInicio();
                if (dateTimeInicial == DateTime.MaxValue)
                {
                    return;
                }
            }

            logger.Escrever("Você quer filtrar por data máxima? S/N");
            input = leitor.Ler();
            DateTime dateTimeFinal = DateTime.MinValue;

            if (input.ToUpper() == "S")
            {
                dateTimeFinal = GetDataDeFim();
                if (dateTimeFinal == DateTime.MaxValue)
                {
                    return;
                }
            }

            Anuncio template = new Anuncio("", cliente, dateTimeInicial, dateTimeFinal, 0);
            string[] relatorios = C_Anuncio.FornecerRelatorios(template);
            if (relatorios.Length == 0)
            {
                logger.Escrever("Nenhum relatorio encontrado.");
            }
            for (int i = 0; i < relatorios.Length; i++)
            {
                logger.Escrever(relatorios[i]);
            }

        }


    }
}
