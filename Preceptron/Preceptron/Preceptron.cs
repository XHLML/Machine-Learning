using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preceptron
{
    class Preceptron
    {
        private double[] weights;
        private double bias;
        private double LR = 0.05;
        public Preceptron(int n)
        {
            weights = new double[n];
            Random r = new Random();
            //Random weights
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = (double)r.Next(-10000, 10001) / 10000;
            }
            bias= (double)r.Next(-10000, 10001) / 10000;
        }
        public int guess(double[] inputs)
        {
            double sum = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                sum += inputs[i] * weights[i];
            }
            sum += bias;
            int output = Math.Sign(sum);//fancy eqation turns everything to +-1
            return output;
        }
        public void train(double[] inputs, int target)
        {
            int guess = this.guess(inputs);
            int error = target - guess;
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] += error * inputs[i] * LR;
            }
            bias += error * LR;
        }

        public double GetM()
        {
            return -(weights[0] / weights[1]);
        }

       public double GetB()
        {
            return -(bias/weights[1]);
        }

        public override string ToString()
        {
            string s = "The Weights Are: \n";
            for (int i = 0; i < weights.Length; i++)
            {
                s+="Weight "+i+" : "+weights[i]+"\n";
            }
            s += "Bias is: " + bias+"\nThe function is: "+GetM()+"X + "+GetB();
            return s;
        }

    }
}
