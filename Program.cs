using System;

namespace app
{
    class Program
    {
        public static Random random = new();
        private static ParticleManager pm = new();
        public static void Main()
        {
            Console.Clear();
            Console.CursorVisible = false;
            while (true)
            {
                pm.Update();
            }
        }
    }


}