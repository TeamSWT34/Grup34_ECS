namespace ECS
{
    public class ECS
    {
        private int _threshold;
        private readonly ITempSensor _tempSensor;
        private readonly IHeater _heater;

        public ECS(int thr, IHeater heater, ITempSensor tempSensor)
        {
            SetThreshold(thr);
            _tempSensor = tempSensor;
            _heater = heater;
        }

        public void Regulate()
        {
            if (GetCurTemp() < GetThreshold())
                _heater.TurnOn();
            else
                _heater.TurnOff();
        }

        public void SetThreshold(int thr) => _threshold = thr;

        public int GetThreshold() => _threshold;

        public int GetCurTemp() => _tempSensor.GetTemp();

        public bool RunSelfTest() => _tempSensor.RunSelfTest() && _heater.RunSelfTest();

    }
}
