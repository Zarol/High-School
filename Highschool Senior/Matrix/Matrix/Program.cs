using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix
{
    class Program
    {
        static Random random = new Random();

        static char randomCharacter
        {
            get
            {
                int t = random.Next(10);
                if (t <= 2)
                    return (char)('0' + random.Next(10));
                else if (t <= 4)
                    return (char)('a' + random.Next(27));
                else if (t <= 6)
                    return (char)('A' + random.Next(27));
                else
                    return (char)(random.Next(32, 255));
            }
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WindowLeft = Console.WindowTop = 0;
            Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;
            Console.WriteLine("Press Any Key To Begin...");
            Console.ReadKey();
            Console.CursorVisible = false;

            int width, height;
            int[] y;

            height = Console.WindowHeight;
            width = Console.WindowWidth - 1;

            y = new int[width];

            Console.Clear();
            for (int x = 0; x < width; ++x)
            {
                y[x] = random.Next(height);
            }

            while (true)
                UpdateAllColumns(width, height, y);
        }
        private static void UpdateAllColumns(int width, int height, int[] y)
        {
            int x;
            for (x = 0; x < width; ++x)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(x, y[x]);
                Console.Write(randomCharacter);

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                int temp = y[x] - 2;
                Console.SetCursorPosition(x, onScreen(temp, height));
                Console.Write(randomCharacter);

                int temp1 = y[x] - 20;
                Console.SetCursorPosition(x, onScreen(temp1, height));
                Console.Write(' ');

                y[x] = onScreen(y[x] + 1, height);
            }
        }

        public static int onScreen(int yPosition, int height)
        {
            if (yPosition < 0)
                return yPosition + height;
            else if (yPosition < height)
                return yPosition;
            else
                return 0;
        }
    }
}
