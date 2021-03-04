namespace ECS.Legacy
{
    public class Application
    {
        public static void Main(string[] args)
        {
            var ecs = new ECS(28, new Heater(), new TempSensor());

            ecs.Regulate();

            ecs.SetThreshold(20);

            ecs.Regulate();
        }
    }
}
