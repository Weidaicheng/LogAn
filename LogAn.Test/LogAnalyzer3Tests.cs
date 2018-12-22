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

        [Test]
        public void Returns_ByDefault_WorksForHardCodedArgument()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            fakeRules.IsValidLogFileName(Arg.Any<string>()).Returns(true);

            Assert.IsTrue(fakeRules.IsValidLogFileName("strict.txt"));
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