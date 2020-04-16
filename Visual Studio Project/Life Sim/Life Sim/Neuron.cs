using System.Collections;
using System.Collections.Generic;

public class Neuron
{
    // The current value of the neuron. It will be a potentially large 
    // until the neuron is activated, as each input will be added to it.
    public float currentValue;

    // The bias that is added to the neuron's value before activation
    public float bias;

    // The type of neuron: initial (sensory), hidden, or terminal
    // public string type;

    // The number of connections from which the neuron expects to receive
    protected int numIncomingConnections;

    // The number of inputs the neuron has received since the last
    // time that it fired, as firing resets this to zero. 
    public int numIncomingReceived;

    // The references to all the neurons this one sends data to
    protected List<Neuron> targetNeurons = new List<Neuron>();

    // The weights associated with all the target neurons. They are
    // put in the same order so the nth target gets the nth weight
    protected List<float> targetWeights = new List<float>();

    /* 
    Requires: A bias for the neuron and a type description
    Mofidies: The member varibles of the given object, setting them to 
              reasonable initial values. 
    Returns: None
    */
    public Neuron(float _bias)
    {
        numIncomingConnections = 0;
        numIncomingReceived = 0;
        currentValue = -1;
        bias = _bias;
    }

    /*
     Requires: A target neuron. This will be automatically passed by reference.
     Modifies: The targetNeurons variable of this instance by adding the neuron 
               to the List. It also modifies the target neuron that we pass by 
               incrementing its number of incoming connections by one. 
     Returns: Nothing
     */
    public void addOutgoingConnection(Neuron targetNeuron, float weight)
    {
        targetNeurons.Add(targetNeuron);
        targetWeights.Add(weight);
        targetNeuron.numIncomingConnections += 1;
    }

    /*
    Requires: A float
    Modifies: Nothing
    Returns:  The logistic sigmoid of the input
    */
    public float LogSigmoid(float x)
    {
        if (x < -45.0) return 0.0F;
        else if (x > 45.0) return 1.0F;
        else return 1.0F / (1.0F + (float)System.Math.Exp(-x));
    }

    /*
    Requires: Nothing
    Modifies: Adds this neurons bias to its current value and then runs 
              it through the activation function. This new value replaces
              the current value.
    Returns: Nothing
    */
    void activate()
    {
        currentValue += bias;
        currentValue = LogSigmoid(currentValue);
    }

    /*
    Requires: Nothing
    Modifies: The current value of each target neuron in the outgoing list. 
              The function transmits this neuron's value weighed by appropriate amount. 
    Returns: Nothing
    */
    public void fire()
    {
        for (int i = 0; i < targetNeurons.Count; i++)
        {
            // Add the current value of this neuron to the target neuron
            // after scaling it with the neuron's appropriate weight.
            targetNeurons[i].currentValue += targetWeights[i] * currentValue;

            // Cause the target neuron to activate if all its connections 
            // have fired. After activation it should fire, creating a cascade.
            if (targetNeurons[i].numIncomingReceived ==
               targetNeurons[i].numIncomingConnections)
            {
                targetNeurons[i].activate();
                targetNeurons[i].fire();
            }
        }

        // After firing the neuron's value should reset so there's a blank
        // slate to which all incoming connections can add when they fire.
        // This is really only important for hidden and terminal neurons.
        currentValue = 0;
    }
}


