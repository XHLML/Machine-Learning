using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Neural_Network
{
    class Program
    {
        static void Main(string[] args)
        {
            Neural3Deep nn = new Neural3Deep(2, 2, 3);
            double[,] inp = { { 1, 0.3 } };
            double[,] answers = { { 0.5 }, { 0.4 }, { 0.1 } };
            Matrix_Math input = new Matrix_Math(inp);
            input.TransposeSelf();
            nn.train(input.data, answers);

        }

    }
}
 