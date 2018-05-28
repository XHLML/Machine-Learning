using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Neural_Network
{
    class Neural3Deep
    {
        int Num_input, Num_hidden, Num_output;
        private Matrix_Math weights_Input_Hidden, weights_Hidden_Output, bias_hidden, bias_output;
        public Neural3Deep(int Num_input, int Num_hidden, int Num_output)
        {
            this.Num_hidden = Num_hidden;
            this.Num_input = Num_input;
            this.Num_output = Num_output;
            this.weights_Input_Hidden = new Matrix_Math(Num_hidden, Num_input);
            this.weights_Hidden_Output = new Matrix_Math(Num_output, Num_hidden);
            this.weights_Hidden_Output.RandomiseSelf(1);
            this.weights_Input_Hidden.RandomiseSelf(1);
            bias_hidden = new Matrix_Math(Num_hidden, 1);
            bias_hidden.RandomiseSelf(1);
            bias_output = new Matrix_Math(Num_output, 1);
            bias_output.RandomiseSelf(1);


        }

        public double[,] FeedForward(Matrix_Math input)
        {
            Matrix_Math hidden = Matrix_Math.multiply(this.weights_Input_Hidden, input); //multiples the weights by the input
            hidden.AddSelf(this.bias_hidden); // adds the bias
            hidden.MapSelf(sigmoid); // sigmoids everything - that's now the output that is transfered to the next layer
            Matrix_Math output = Matrix_Math.multiply(weights_Hidden_Output, hidden); //multiples the weights by the input(that is the preivoius output
            output.AddSelf(bias_output);//adds bias
            output.MapSelf(sigmoid);//sigmoids everything

            //weights_Input_Hidden.PrintSelf();
            //input.PrintSelf();
            //Console.WriteLine();
            //hidden.PrintSelf();
            //weights_Hidden_Output.PrintSelf();
            //Console.WriteLine();
            //output.PrintSelf();
            return output.data;//gives out the output
        }
        public void train(double[,] train_data, double[,] answer)
        {
            Matrix_Math Output = new Matrix_Math(FeedForward(new Matrix_Math(train_data))); // passes the training data threw the feed forward and puts the output into a matrix
            Matrix_Math errors = Matrix_Math.Subtract( new Matrix_Math(answer),Output);//creates a matrix of error by converting the answers to matrix and subtracting the output matrix from it  

            //double herror1 = weights_Hidden_Output.data[0, 0] / (weights_Hidden_Output.data[0, 0] + weights_Hidden_Output.data[0, 1])*error; //the error of the first neuron of hidden layer
            //double herror2 = weights_Hidden_Output.data[0, 1] / (weights_Hidden_Output.data[0, 0] + weights_Hidden_Output.data[0, 1])*error;//the error of the second neuron of hidden layer
            Matrix_Math hidden_errors = new Matrix_Math(Num_hidden,1);
            double[] sumOfWeights = new double[Num_output];
            for (int l = 0; l < Num_output; l++)
            {
                sumOfWeights[l] = 0;
                for (int i = 0; i < Num_hidden; i++)
                {
                    sumOfWeights[l] += weights_Hidden_Output.data[l, i]; //creates the sum of both weights of each output neuron 

                }
            }
            //Output.PrintSelf();
            //new Matrix_Math(answer).PrintSelf();
            //errors.PrintSelf();
            for (int l = 0; l < Num_output; l++)
            {


                for (int i = 0; i < Num_hidden; i++)
                {
                    hidden_errors.data[i, 0] += weights_Hidden_Output.data[l, i] / sumOfWeights[l] * errors.data[l,0];//creates the error for each hidden layer neuron
                }
            }
          //  hidden_errors.PrintSelf();

          // Keep the prints for testing 
        }

        public static double sigmoid(double x, int rows, int cols)
        {
            return (Math.Pow(Math.E, x)) / (Math.Pow(Math.E, x) + 1);
        }
    }
}
