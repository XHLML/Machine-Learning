using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preceptron
{
    class Cartisian
    {
        public static void SetCartCoords(int Cx, int Cy)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 + Cx, Console.WindowHeight / 2 - Cy);
        }
        public static void DrawSystem()
        {
            for (int i = -Console.LargestWindowWidth / 2; i < Console.LargestWindowWidth / 2; i++)
            {
                Cartisian.SetCartCoords(i, 0);
                Console.Write("#");
            }
            for (int i = -Console.LargestWindowHeight / 2; i < Console.LargestWindowHeight / 2; i++)
            {
                Cartisian.SetCartCoords(0, i);
                Console.Write("#");
            }
        }
        public static  void DrawBasicFunction(int x, int b)
        {
            for (int i = -Console.LargestWindowHeight / 2; x*i+b < Console.LargestWindowHeight/2&&i<Console.LargestWindowWidth/2; i++)
            {
                Cartisian.SetCartCoords(i, x * i + b);
                Console.Write('#');
            }
        }
    }
}
