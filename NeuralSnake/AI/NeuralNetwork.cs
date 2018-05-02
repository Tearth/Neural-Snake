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
        private int _neurons;
        private float _alpha;

        private static Random _random = new Random();

        public NeuralNetwork(int neurons, float alpha)
        {
            _network = new ActivationNetwork(new SigmoidFunction(alpha), 4, neurons, 4);
            _neurons = neurons;
            _alpha = alpha;
        }

        public NeuralNetwork(ActivationNetwork neuralNetwork)
        {
            _network = neuralNetwork;
        }

        public Direction Calculate(Board board, Point head)
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
            var clonedNeuralNetwork = new ActivationNetwork(new BipolarSigmoidFunction(_alpha), 4, _neurons, 4);
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

        public void Mutate()
        {
            if (_random.NextDouble() < 0.5)
            {
                var mutationsCount = _random.Next(1, 4);
                for (var i = 0; i < mutationsCount; i++)
                {
                    var layerIndex = _random.Next(_network.Layers.Length);
                    var layer = _network.Layers[layerIndex];

                    var neuronIndex = _random.Next(layer.Neurons.Length);
                    var neuron = layer.Neurons[neuronIndex];

                    var weightIndex = _random.Next(neuron.Weights.Length);
                    neuron.Weights[weightIndex] = _random.NextDouble();
                }
            }
        }

        private double GetFieldValue(FieldType type)
        {
            return Convert.ToDouble(type == FieldType.Empty || type == FieldType.Food);
        }
    }
}
