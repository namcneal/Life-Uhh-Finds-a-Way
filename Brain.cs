using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain {
    List<Neuron> inputNeurons;
    List<Neuron> hiddenNeurons;
    List<Neuron> outputNeurons;

    public void addInputNeuron(Neuron newAddition)
    {
        inputNeurons.add(newNeuron);
    }

    public void addHiddenNeuron(Neuron newAddition)
    {
        hiddenNeurons.add(newNeuron);
    }

    public void addOutputNeuron(Neuron newAddition)
    {
        outputNeurons.add(newNeuron);
    }

    public void connectNeurons(Neuron initial, Neuron terminal, float connectionWeight)
    {
        initial.addOutgoingConnection(terminal, connectionWeight);
    }
    
}


