
namespace CadastroDeAnuncios
{
    /// <summary>
    /// Classe que inicializa o programa e depedencias.
    /// </summary>
    class SetUp
    {
        static Logger logger;
        static Leitor leitor;
        static ControladorAnuncio controladorAnuncio;
        static View viewInicial;

        /// <summary>
        /// Metodo inicial do programa.
        /// </summary>
        static void Main(string[] args)
        {
            logger = new Logger();
            leitor = new Leitor();
            controladorAnuncio = new ControladorAnuncio();

            viewInicial = new View(controladorAnuncio, logger, leitor);
            viewInicial.MostrarView();
        }

    }
}
