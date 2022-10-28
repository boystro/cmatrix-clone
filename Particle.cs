using System;

namespace app
{
    class Particle
    {
        readonly int x;
        int y;
        readonly int trailLength;
        readonly string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789+-*/|\\[]{}()=&%$#@!<>?;:";
        public bool IsDead { get; private set; }

        public Particle()
        {
            x = Program.random.Next() % Console.WindowWidth;
            y = -1;
            trailLength = 5 + (Program.random.Next() % 6);
        }

        public void Render()
        {
            if (IsDead)
                return;
            int isDark = 4;
            int renderLimit = Math.Min(Console.BufferHeight, Console.WindowHeight);
            if (y > renderLimit + trailLength || x < 0 || x > Console.BufferWidth)
                IsDead = true;
            int temp = y;
            int len = trailLength;
            while (temp >= 0 && len > 0)
            {
                if (temp > renderLimit)
                {
                    temp--; len--; isDark--;
                    continue;
                }
                Console.SetCursorPosition(x, temp);
                if (temp == y)
                    Console.ForegroundColor = ConsoleColor.White;
                else
                {
                    if (isDark < 1)
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write(characters[Program.random.Next() % characters.Length]);
                temp--; len--; isDark--;
            }

            if (temp > 0)
            {
                Console.SetCursorPosition(x, --temp);
                Console.Write(' ');
            }

            y++;
        }
    }

}