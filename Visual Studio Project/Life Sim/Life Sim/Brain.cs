using System;
using System.Collections.Generic;

public class Brain {

    // Store input neurons in list 1, hidden neurons in list 2, and outputs in list 3
    public List<List<Neuron>> neurons = new List<List<Neuron>>();

    public Brain()
    {
        neurons.Add(new List<Neuron>());
        neurons.Add(new List<Neuron>());
        neurons.Add(new List<Neuron>());


    }

    public void growNeuron(string type)
    {
        switch (type)
        {
            case "input":
                neurons[0].Add(new Neuron());
                break;
            case "hidden":
                neurons[1].Add(new Neuron());
                break;
            case "output":
                neurons[2].Add(new Neuron());
                break;       
        }
    }

    public void growNeuron(string type, float bias)
    {
        switch (type)
        {
            case "input":
                neurons[0].Add(new Neuron(bias));
                break;
            case "hidden":
                neurons[1].Add(new Neuron(bias));
                break;
            case "output":
                neurons[2].Add(new Neuron(bias));
                break;
        }
    }

    public void connectNeurons(Neuron initial, Neuron terminal, float connectionWeight)
    {
        initial.addOutgoingConnection(terminal, connectionWeight);
    }

    public void triggerFiringCascade()
    {
        foreach (Neuron neuron in neurons[0])
        {
            neuron.fire();
        }
    }
}


