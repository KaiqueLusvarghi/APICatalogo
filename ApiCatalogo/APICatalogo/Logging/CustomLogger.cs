
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace APICatalogo.Logging
{
    public class CustomLogger : ILogger
    {
        readonly String loggerName;
        readonly CustomLoggerProviderConfiguration loggerConfig;

        public CustomLogger(string loggerName, CustomLoggerProviderConfiguration config)
        {
            this.loggerName = loggerName;
            this.loggerConfig = config;
        }

  

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
           return logLevel == loggerConfig.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string mensagem = $"{logLevel.ToString()}: {eventId.Id} - {formatter(state, exception)}";
            EscreverTextoNoArquivo(mensagem);
        }

        private void EscreverTextoNoArquivo(object mensagem)
        {
            string caminhoArquivoLog = @"C:\Users\GAMER\OneDrive\Área de Trabalho\Projetos\Lusvarghi_Log.txt";
            using (StreamWriter streamWriter = new StreamWriter(caminhoArquivoLog, true))
            { 
                try
                {
                    streamWriter.WriteLine(mensagem);
                    streamWriter.Close();
                }
                catch (Exception)  
                {
                    throw;
                }
            }
        }
    }
}
