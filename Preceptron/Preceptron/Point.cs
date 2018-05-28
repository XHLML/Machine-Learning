using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preceptron
{
    class Point
    {
       private static Random r = new Random();
       public int x;
       public int y;
       public  int lable;
        public Point()
        {

            x = r.Next(-0, 30);
            y = r.Next(-0, 30);
            if (x > y)
                lable = 1;
            else
                lable = -1;
        }
        public Point(bool b)
        {

            x = r.Next(-30, 30);
            y = r.Next(-30, 30);
            if (x > y)
                lable = 1;
            else
                lable = -1;
        }
    
        public void show()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.Write('*');
        }
        public void CartShow()
        {
            Cartisian.SetCartCoords(this.x, this.y);
            Console.Write('*');
        }
    }
}
