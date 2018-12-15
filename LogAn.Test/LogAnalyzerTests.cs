using NUnit.Framework;
using System;

namespace LogAn.Tests
{
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_VariousExtensions_ChecksThem()
        {
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            myFakeManager.WillBaValid = true;

            LogAnalyzer log = new LogAnalyzer(myFakeManager);

            bool result = log.IsValidLogFileName("short.txt");

            Assert.True(result);
        }

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            FakeExtensionManager myFakeManager = new FakeExtensionManager();
            myFakeManager.WillThrow = new Exception("this is fake");

            LogAnalyzer log = new LogAnalyzer(myFakeManager);
            bool result = log.IsValidLogFileName("anything.anyextension");

            Assert.False(result);
        }
    }

    internal class FakeExtensionManager : IExtensionManager
    {
        public bool WillBaValid = false;
        public Exception WillThrow = null;

        public bool IsValid(string fileName)
        {
            if(WillThrow != null)
            {
                throw WillThrow;
            }

            return WillBaValid;
        }
    }
}