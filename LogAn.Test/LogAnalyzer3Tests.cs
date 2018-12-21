using NSubstitute;
using NUnit.Framework;

namespace LogAn.Test
{
    public class LogAnalyzer3Tests
    {
        [Test]
        public void Analyze_TooShortFileName_CallLogger()
        {
            ILogger logger = Substitute.For<ILogger>();

            LogAnalyzer3 analyzer = new LogAnalyzer3(logger);
            analyzer.MinNameLength = 6;
            analyzer.Analyze("a.txt");

            logger.Received().LogError("Filename too short: a.txt");
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