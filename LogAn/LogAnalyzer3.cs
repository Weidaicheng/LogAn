namespace LogAn
{
    public class LogAnalyzer3
    {
        private readonly ILogger _logger;

        public LogAnalyzer3(ILogger logger)
        {
            _logger = logger;
        }

        public int MinNameLength { get; set; }

        public void Analyze(string fileName)
        {
            if(fileName.Length < MinNameLength)
            {
                _logger.LogError("too short");
            }
        }
    }
}