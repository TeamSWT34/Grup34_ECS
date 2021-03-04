using NUnit.Framework;

namespace ECS.Legacy.Test.Unit
{
    [TestFixture]
    public class HeaterTests
    {
        private Heater uut;
        [SetUp]
        public void Setup()
        {
            uut = new Heater();
        }

        [Test]
        public void RunSelfTest_ReturnTrue()
        {
            Assert.IsTrue(uut.RunSelfTest());
        }
    }
}