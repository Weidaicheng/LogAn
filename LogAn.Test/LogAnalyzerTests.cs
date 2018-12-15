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
    }

    internal class FakeExtensionManager : IExtensionManager
    {
        public bool WillBaValid = false;

        public bool IsValid(string fileName)
        {
            return WillBaValid;
        }
    }
}