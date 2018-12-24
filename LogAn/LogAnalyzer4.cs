using System;

namespace LogAn
{
    public class LogAnalyzer4
    {
        private ILogger _logger;
        private IWebService _webService;

        public LogAnalyzer4(ILogger logger, IWebService webService)
        {
            _logger = logger;
            _webService = webService;
        }

        public int MinNameLength { get; set; }

        public void Analyze(string filename)
        {
            if(filename.Length < MinNameLength)
            {
                try
                {
                    _logger.LogError($"Filename too short: {filename}");
                }
                catch(Exception e)
                {
                    _webService.LogError($"Error from Logger: {e}");
                }
            }
        }
    }
}