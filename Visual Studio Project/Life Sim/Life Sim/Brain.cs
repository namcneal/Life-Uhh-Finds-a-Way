using System.Collections;
using System.Collections.Generic;

public class Brain {
    public List<Neuron> inputNeurons   = new List<Neuron>();
    public List<Neuron> hiddenNeurons = new List<Neuron>();
    public List<Neuron> outputNeurons = new List<Neuron>();

    public Brain()
    {

    }

    public void addInputNeuron(Neuron newAddition)
    {
        inputNeurons.Add(newAddition);
    }

    public void addHiddenNeuron(Neuron newAddition)
    {
        hiddenNeurons.Add(newAddition);
    }

    public void addOutputNeuron(Neuron newAddition)
    {
        outputNeurons.Add(newAddition);
    }

    public void connectNeurons(Neuron initial, Neuron terminal, float connectionWeight)
    {
        initial.addOutgoingConnection(terminal, connectionWeight);
    }

    public void triggerFiringCascade()
    {
        foreach (Neuron neuron in inputNeurons){
            neuron.fire();
        }
    }
    
}


