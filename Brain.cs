﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain {
    List<Neuron> inputNeuron   = new List<Neuron>();
    List<Neuron> hiddenNeurons = new List<Neuron>();
    List<Neuron> outputNeurons = new List<Neuron>();

    public Brain()
    {

    }

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

    public void triggerFiringCascade()
    {
        foreach (Neuron neuron in inputNeurons){
            neuron.fire();
        }
    }
    
}


