using System;


namespace CadastroDeAnuncios
{
    /// <summary>
    /// Classe de utilidades de parse para views.
    /// </summary>
    class UtilitariosParse
    {
        ILogger logger;
        public UtilitariosParse(ILogger logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Retorna -1 se não conseguir dar parse na string.
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public float ParseFloat(string valor)
        {
            try
            {
                float parse = float.Parse(valor);
                return parse;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Retorna MaxValue se não conseguir dar parse na string.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DateTime ParseDate(string data)
        {
            try
            {
                DateTime dateTime = DateTime.Parse(data);
                return dateTime;
            }
            catch
            {
                logger.Escrever("Esse valor não é válido.");
            }

            return DateTime.MaxValue;
        }
    }
}
