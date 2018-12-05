using NUnit.Framework;

namespace LogAn.Tests
{
    public class LogAnalyzerTests
    {
        private LogAnalyzer _analyzer;

        [SetUp]
        public void Setup()
        {
            _analyzer = new LogAnalyzer();
        }

        [Test]
        public void IsValidFileName_BadExtension_ReturnsFalse()
        {
            bool result = _analyzer.IsValidLogFileName("filewithbadextension.foo");

            Assert.False(result);
        }

        [Test]
        public void IsValidFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            bool result = _analyzer.IsValidLogFileName("filewithgoodextension.slf");

            Assert.True(result);
        }

        [Test]
        public void IsValidFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            bool result = _analyzer.IsValidLogFileName("filewithgoodextension.SLF");

            Assert.True(result);
        }
    }
}