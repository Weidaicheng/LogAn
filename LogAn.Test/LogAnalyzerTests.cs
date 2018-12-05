using NUnit.Framework;

namespace LogAn.Tests
{
    public class LogAnalyzerTests
    {
        private LogAnalyzer _analyzer = null;

        [SetUp]
        public void Setup()
        {
            _analyzer = new LogAnalyzer();
        }

        [TestCase("filewithgoodextension.SLF", true)]
        [TestCase("filewithgoodextension.slf", true)]
        [TestCase("filewithbadextension.foo", false)]
        public void IsValidFileName_VariousExtensions_ChecksThem(string file, bool expected)
        {
            bool result = _analyzer.IsValidLogFileName(file);

            Assert.AreEqual(expected, result);
        }

        [TearDown]
        public void TearDown()
        {
            _analyzer = null;
        }
    }
}