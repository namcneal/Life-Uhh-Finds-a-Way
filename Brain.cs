using System;
using System.Collections.Generic;

public class Brain {

    // Store input neurons in list 1, hidden neurons in list 2, and outputs in list 3
    public List<List<Neuron>> neurons = new List<List<Neuron>>();

    /*
    Requires: Nothing
    Modifies: nothing
    Returns: A new brain instance is created
    */
    public Brain()
    {
        neurons.Add(new List<Neuron>());
        neurons.Add(new List<Neuron>());
        neurons.Add(new List<Neuron>());
    }

    /*
    Requires: The type of neuron to be create
    Modifies: The brain's list of neurons, adding the neuron with the defauly 
              bias to the proper sublist
    Returns: Nothing
    */
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

    /*
        Requires: The type of neuron to be create, and its bias
        Effect:  Adds the neuron with the given bias to the proper sublist
        Returns: Nothing
    */
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

    /*
    Requires: Two neurons to be connected, one initial one final. 
              Also requires the weight of the connection
    Effect: Modifies the neuron named "initial" through the funcionality of its class.
            The "terminal" neuron is "connected" to it.
    Returns: Nothing
    */
    public void connectNeurons(Neuron initial, Neuron terminal, float connectionWeight)
    {
        initial.addOutgoingConnection(terminal, connectionWeight);
    }

    /*
        Requires: Nothing
        Effect: Causes all the input neurons to fire, triggering all neurons connected
                to them to also fire when appropriate. This eventually causes all 
                neurons to fire, making the output neurons run their actions
                if their threshold is crossed.
        Modifies: All fired neurons have their current value zeroed out. So the network
                  will have all neuron's set to zero by the end of the function. 
        Returns: Nothing
    */
    public void triggerFiringCascade()
    {
        foreach (Neuron neuron in neurons[0])
        {
            neuron.fire();
        }
    }
}


