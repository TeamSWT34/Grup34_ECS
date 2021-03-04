using System;
using System.Runtime.InteropServices.ComTypes;
using NSubstitute;
using NUnit.Framework;

namespace ECS.Test.Unit
{
    [TestFixture]
    public class ECSTests
    {
        private ECS _uut;
        private IHeater _fakeHeater;
        private ITempSensor _fakeTempSensor;

        [SetUp]
        public void Setup()
        {
            _fakeHeater = Substitute.For<IHeater>();
            _fakeTempSensor = Substitute.For<ITempSensor>();
            _uut = new ECS(20, _fakeHeater, _fakeTempSensor);

        }

        [TestCase(15, 20, 1)]
        [TestCase(20, 15, 0)]
        [TestCase(17, 18, 1)]
        [TestCase(15, 15, 0)]
        public void Regulate_TempBelowThreshold_HeaterTurnedOn(int curTemp, int thres, int reg)
        {
            _fakeTempSensor.GetTemp().Returns(curTemp);
            _uut.SetThreshold(thres);
            _uut.Regulate();
            _fakeHeater.Received(reg).TurnOn();

        }

        [TestCase(15, 20, 0)]
        [TestCase(20, 15, 1)]
        [TestCase(17, 18, 0)]
        [TestCase(15, 15, 1)]
        public void Regulate_TempAboveThreshold_HeaterTurnedOff(int curTemp, int thres, int reg)
        {
            _fakeTempSensor.GetTemp().Returns(curTemp);
            _uut.SetThreshold(thres);
            _uut.Regulate();
            _fakeHeater.Received(reg).TurnOff();
        }

        [TestCase(true, true, true)]
        [TestCase(false, true, false)]
        [TestCase(true, false, false)]
        [TestCase(false, false, false)]
        public void RunSelfTest_HeaterSensor_Res(bool hSelftest, bool tSSelfTest, bool res)
        {
            _fakeHeater.RunSelfTest().Returns(hSelftest);
            _fakeTempSensor.RunSelfTest().Returns(tSSelfTest);
            Assert.That(_uut.RunSelfTest() == res);
        }
    }
}