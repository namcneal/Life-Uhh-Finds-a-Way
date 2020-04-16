using System;
using System.IO;

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

            brain.addInputNeuron(input);
            brain.addOutputNeuron(output);
            brain.connectNeurons(input, output, 1);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine("test_values.txt")))
            {

                for(float i = -50; i <= 50; i += 0.1F)
                {
                    brain.inputNeurons[0].currentValue = i;
                    brain.triggerFiringCascade();
                    Console.WriteLine(brain.outputNeurons[0].currentValue);
                    outputFile.WriteLine(brain.outputNeurons[0].currentValue);
                }
                
            }
        }
    }
}
