using System;
using NSubstitute;
using NUnit.Framework;

namespace LogAn
{
    public class LogAnalyzer4Test
    {
        [Test]
        public void Analyze_LoggerThrows_CallsWebService()
        {
            var mockWebService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILogger>();
            stubLogger.When(logger => logger.LogError(Arg.Any<string>()))
            .Do(info => 
            {
                throw new Exception("fake exception");
            });

            var analyzer = new LogAnalyzer4(stubLogger, mockWebService);
            analyzer.MinNameLength = 10;
            analyzer.Analyze("Short.txt");

            mockWebService.Received()
                .LogError(Arg.Is<string>(s => s.Contains("fake exception")));
        }
    }
}