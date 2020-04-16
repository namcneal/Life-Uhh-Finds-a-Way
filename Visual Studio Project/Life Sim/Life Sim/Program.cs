using System;

namespace Life_Sim
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Brain brain = new Brain();

            Neuron input = new Neuron(0);
            Neuron output = new Neuron(0);

            brain.connectNeurons(input, output, 1);
        }
    }
}
