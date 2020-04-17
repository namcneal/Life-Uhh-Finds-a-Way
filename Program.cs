using System;
using System.IO;

namespace Life_Sim
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting test");

            // Create the brain
            Brain brain = new Brain();

            // Add one input neuron and one output neuron
            brain.growNeuron("input");
            float testBias = 0;
            brain.growNeuron("output", testBias);

            // Connect the input neuron to the output neuron with a connection of weight 1.
            float testWeight = 1;
            brain.connectNeurons(brain.neurons[0][0], brain.neurons[2][0], testWeight);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine("test_values.txt")))
            {
                // Set the output neuron's action to print its value to the console
                void func()
                {
                    outputFile.WriteLine(brain.neurons[2][0].currentValue);
                }
                brain.neurons[2][0].setOutputFunction(func);

                // Set the input value to a series of numbers. The brain should ouput a file.
                // If things are connected correctly, it will be the activation function shifted by one unit. . 
                for (float i = -50; i <= 50; i += 0.1F)
                {
                    // Set the value of the input neuron
                    brain.neurons[0][0].currentValue = i;

                    // Cause the input neuron to fire. This should then trigger the output neuron to fire
                    // Thus writing its value to file
                    brain.neurons[0][0].fire();
                }
            }
            

            Console.WriteLine("Testing finished");
                
        }
    }
}
