using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;

namespace ECS.Test.Unit
{
    [TestFixture]
    public class TempSensorTests
    {
        private TempSensor uut;
        [SetUp]
        public void Setup()
        {
            uut = new TempSensor();
        }

        [Test]
        public void RunSelfTest_ReturnTrue()
        {
            Assert.IsTrue(uut.RunSelfTest());
        }

        [Test]
        public void GetTemp_ReturnsNumberBetweenMinus5And45()
        {
            int temp = uut.GetTemp();
            Assert.That(temp>=-5 && temp<45);
        }
    }
}