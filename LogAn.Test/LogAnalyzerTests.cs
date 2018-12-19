using NUnit.Framework;

namespace LogAn.Tests
{
    public class LogAnalyzerTests
    {
        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            FakeWebService mockService = new FakeWebService();
            LogAnalyzer log = new LogAnalyzer(mockService);
            string tooShortFileName = "abc.ext";

            log.Analyze(tooShortFileName);

            StringAssert.Contains("Filename too short: abc.ext", mockService.LastError);
        }
    }

    public class FakeWebService : IWebService
    {
        public string LastError;

        public void LogError(string message)
        {
            LastError = message;
        }
    }
}