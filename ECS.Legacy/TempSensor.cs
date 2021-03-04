using System;
using System.Runtime.CompilerServices;
[assembly:InternalsVisibleTo("ECS.Legacy.Test.Unit")]
namespace ECS.Legacy
{
    
    internal class TempSensor : ITempSensor
    {
        private Random gen = new Random();

        public int GetTemp()
        {
            return gen.Next(-5, 45);
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}