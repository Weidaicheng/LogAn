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

        [Test]
        [Ignore("there is a problem with this test")]
        [Category("Tests that has problems")]
        public void IsValidFileName_AlwaysFail()
        {
            Assert.True(false);
        }

        [Test]
        public void IsValidFileName_EmptyFileName_ThrowsFluent()
        {
            var ex = Assert.Catch<ArgumentException>(() =>
            {
                _analyzer.IsValidLogFileName("");
            });

            Assert.That(ex.Message.Contains("filename has to be provided"));
        }

        [Test]
        [TestCase("badfile.foo", false)]
        [TestCase("goodfile.slf", true)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string file, bool expected)
        {
            _analyzer.IsValidLogFileName(file);

            Assert.AreEqual(expected, _analyzer.WasLastFileNameValid);
        }

        [TearDown]
        public void TearDown()
        {
            _analyzer = null;
        }
    }
}