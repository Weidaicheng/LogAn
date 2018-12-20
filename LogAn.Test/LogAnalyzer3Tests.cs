using NUnit.Framework;

namespace LogAn.Test
{
    public class LogAnalyzer3Tests
    {
        [Test]
        public void Analyze_TooShortFileName_CallLogger()
        {
            FakeLogger logger = new FakeLogger();

            LogAnalyzer3 analyzer = new LogAnalyzer3(logger);
            analyzer.MinNameLength = 6;
            analyzer.Analyze("a.txt");

            StringAssert.Contains("too short", logger.LastError);
        }
    }

    public class FakeLogger : ILogger
    {
        public string LastError;

        public void LogError(string message)
        {
            LastError = message;
        }
    }
}