using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Preceptron
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);
        static void Main(string[] args)
        {
            Cartisian_x_y_learn();
     
        }


        static void Maximize()
        {
            Process p = Process.GetCurrentProcess();
            ShowWindow(p.MainWindowHandle, 3); //SW_MAXIMIZE = 3
        }
        static void Non_Cartisian_x_y_learn()
        {
            Point[] points = new Point[100];
            Preceptron p = new Preceptron(2);
            Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop);
            Console.SetWindowSize(90, 30);
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point();
            }
            for (int i = 0; i < 30; i++)
            {
                Console.SetCursorPosition(i, i);
                Console.Write("#");
            }
            foreach (Point poo in points)//shows the state before
            {
                if (1 == poo.lable)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                poo.show();
            }
            Console.ReadLine();
            Console.Clear();
            for (int l = 0; l < 100;)
            {//trains the preceptron

                foreach (Point po in points)
                {
                    l = 0;
                    p.train(new double[] { po.x, po.y }, po.lable);
                    foreach (Point poo in points)//shows after each train
                    {
                        if (p.guess(new double[] { poo.x, poo.y }) == poo.lable)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            l++;
                        }
                        else
                            Console.ForegroundColor = ConsoleColor.Red;
                        poo.show();
                    }

                }


            }
        }
        static void Cartisian_x_y_learn()
        {


            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetWindowPosition(0, 0);

            Cartisian.DrawSystem();
            Cartisian.DrawBasicFunction(7, -8);

            Point[] points = new Point[100];
            Preceptron p = new Preceptron(2);
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point(true);
                if (points[i].y <= 7 * points[i].x-8)
                    points[i].lable = 1;
                else
                    points[i].lable = -1;
            }

            foreach (Point poo in points)//shows the state before
            {
                if (1 == poo.lable)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                poo.CartShow();


            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();

            Cartisian.DrawSystem();
            Cartisian.DrawBasicFunction(7, -8);

            for (int l = 0; l < 100;)
            {//trains the preceptron
                
                foreach (Point po in points)
                {
                    l = 0;
                    p.train(new double[] { po.x, po.y }, po.lable);
                    foreach (Point poo in points)//shows after each train
                    {
                        if (p.guess(new double[] { poo.x, poo.y }) == poo.lable)
                        {
                            l++;
                        }
                        if (p.guess(new double[] { poo.x, poo.y }) == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                            Console.ForegroundColor = ConsoleColor.Red;
                        poo.CartShow();
                       
                    }

                    Console.WriteLine(p);
                }



            }

            Console.ReadLine();
            Console.WriteLine(p);
            Cartisian.DrawBasicFunction((int)Math.Round(p.GetM()), (int)Math.Round(p.GetB()));
            

        }
    }
}
