using NUnit.Framework;

namespace LogAn.Tests
{
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_SupportedExtension_ReturnsTrue()
        {
            TestableLogAnalyzer log = new TestableLogAnalyzer();
            log.IsSupported = true;

            bool result = log.IsValidLogFileName("file.ext");

            Assert.True(result);
        }
    }

    internal class TestableLogAnalyzer : LogAnalyzer
    {
        public bool IsSupported;

        protected override bool IsValid(string fileName)
        {
            return IsSupported;
        }
    }
}