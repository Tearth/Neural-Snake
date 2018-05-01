using System;
using System.Drawing;
using System.Linq;
using AForge.Neuro;

namespace NeuralSnake.AI
{
    public class NeuralNetwork
    {
        public double[] LastInput { get; private set; }
        public double[] LastOutput { get; private set; }

        private ActivationNetwork _network;

        public NeuralNetwork()
        {
            _network = new ActivationNetwork(new BipolarSigmoidFunction(0.5), 4, 8, 4);
        }

        public Direction Calculate(FieldType[,] board, Point head)
        {
            var input = new[]
            {
                GetFieldValue(board[head.X, head.Y - 1]),
                GetFieldValue(board[head.X + 1, head.Y]),
                GetFieldValue(board[head.X, head.Y + 1]),
                GetFieldValue(board[head.X - 1, head.Y])
            };

            var output = _network.Compute(input).ToList();
            var maxValue = output.Max();
            var maxIndex = output.IndexOf(maxValue);

            LastInput = input;
            LastOutput = _network.Output;

            return (Direction)maxIndex + 1;
        }

        public ActivationNetwork Clone()
        {
            var clonedNeuralNetwork = new ActivationNetwork(new BipolarSigmoidFunction(0.5), 4, 8, 4);
            for(var l=0; l<_network.Layers.Length; l++)
            {
                var layer = _network.Layers[l];
                for(var n=0; n<layer.Neurons.Length; n++)
                {
                    var neuron = (ActivationNeuron)layer.Neurons[n];

                    for (var w = 0; w < neuron.Weights.Length; w++)
                    {
                        var clonedNeuron = (ActivationNeuron)clonedNeuralNetwork.Layers[l].Neurons[n];
                        clonedNeuron.Weights[w] = neuron.Weights[w];
                        clonedNeuron.Threshold = neuron.Threshold;
                    }
                }
            }

            return clonedNeuralNetwork;
        }

        private double GetFieldValue(FieldType type)
        {
            return Convert.ToDouble(type == FieldType.Empty || type == FieldType.Food);
        }
    }
}
