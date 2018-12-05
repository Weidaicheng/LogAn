using NUnit.Framework;
using System;

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

        [Test]
        public void IsValidFileName_EmptyFileName_ThrowsException()
        {
            var ex = Assert.Catch<Exception>(() =>
            {
                _analyzer.IsValidLogFileName("");
            });
            StringAssert.Contains("filename has to be provided", ex.Message);
        }

        [TearDown]
        public void TearDown()
        {
            _analyzer = null;
        }
    }
}