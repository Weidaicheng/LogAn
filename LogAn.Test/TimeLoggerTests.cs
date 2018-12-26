using NUnit.Framework;

namespace LogAn
{
    public class TimeLoggerTests
    {
        [Test]
        public void SettingSystemTime_Always_ChangesTime()
        {
            SystemTime.Set(new System.DateTime(2000, 1, 1));

            string output = TimeLogger.CreateMessage("a");

            StringAssert.Contains("2000-01-01", output);
        }

        [TearDown]
        public void TearDown()
        {
            SystemTime.Reset();
        }
    }
}