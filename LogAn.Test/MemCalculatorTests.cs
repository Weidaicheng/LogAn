using NUnit.Framework;

namespace LogAn.Test
{
    public class MemCalculatorTests
    {
        private MemCalculator _memCalculator = null;

        [SetUp]
        public void Setup()
        {
            _memCalculator = new MemCalculator();
        }

        [Test]
        public void Sum_ByDefault_ReturnsZero()
        {
            int lastsum = _memCalculator.Sum();

            Assert.AreEqual(0, lastsum);
        }

        [Test]
        public void Add_WhenCalled_ChangesSum()
        {
            _memCalculator.Add(1);
            int sum = _memCalculator.Sum();

            Assert.AreEqual(1, sum);
        }

        [TearDown]
        public void TearDown()
        {
            _memCalculator = null;
        }
    }
}
