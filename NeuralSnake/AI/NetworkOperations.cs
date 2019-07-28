using System;
using AForge.Neuro;

namespace NeuralSnake.AI
{
    public class NetworkOperations
    {
        private Random _random;

        private const float MutationChance = 0.3f;
        private const int MaxMutationsCount = 5;

        public NetworkOperations()
        {
            _random = new Random();
        }

        public void Mutate(ActivationNetwork network)
        {
            if (_random.NextDouble() < MutationChance)
            {
                var mutationsCount = _random.Next(1, MaxMutationsCount);
                for (var i = 0; i < mutationsCount; i++)
                {
                    var layerIndex = _random.Next(network.Layers.Length);
                    var layer = network.Layers[layerIndex];

                    var neuronIndex = _random.Next(layer.Neurons.Length);
                    var neuron = layer.Neurons[neuronIndex];

                    var weightIndex = _random.Next(neuron.Weights.Length);
                    neuron.Weights[weightIndex] = _random.NextDouble();
                }
            }
        }

        public ActivationNetwork Breed(ActivationNetwork leftParent, ActivationNetwork rightParent)
        {
            var alpha = ChooseAlpha(leftParent, rightParent);
            var network = new ActivationNetwork(new BipolarSigmoidFunction(alpha), 8, MainWindow.Neurons, 4);

            ChooseWeights(network, leftParent, rightParent);
            return network;
        }

        private double ChooseAlpha(ActivationNetwork leftParent, ActivationNetwork rightParent)
        {
            var choice = _random.Next(0, 3);
            var leftAlpha = GetNetworkAlpha(leftParent);
            var rightAlpha = GetNetworkAlpha(rightParent);

            switch (choice)
            {
                case 0: return leftAlpha;
                case 1: return rightAlpha;
                case 2: return _random.NextDouble();
            }

            return -1;
        }

        private double GetNetworkAlpha(ActivationNetwork network)
        {
            var function = (BipolarSigmoidFunction)((ActivationNeuron)network.Layers[0].Neurons[0]).ActivationFunction;
            return function.Alpha;
        }

        private void ChooseWeights(ActivationNetwork network, ActivationNetwork leftParent, ActivationNetwork rightParent)
        {
            for (var l = 0; l < network.Layers.Length; l++)
            {
                var leftLayer = leftParent.Layers[l];
                var rightLayer = rightParent.Layers[l];

                for (var n = 0; n < leftLayer.Neurons.Length; n++)
                {
                    var leftNeuron = (ActivationNeuron)leftLayer.Neurons[n];
                    var rightNeuron = (ActivationNeuron)rightLayer.Neurons[n];

                    for (var w = 0; w < leftNeuron.Weights.Length; w++)
                    {
                        var neuronToApply = (ActivationNeuron)network.Layers[l].Neurons[n];
                        var random = _random.NextDouble();
                        var range = Math.Abs(leftNeuron.Weights[w] - rightNeuron.Weights[w]);
                        var min = Math.Min(leftNeuron.Weights[w], rightNeuron.Weights[w]);

                        var weight = random * range + min;
                        neuronToApply.Weights[w] = weight;
                        neuronToApply.Threshold = 0;
                    }
                }
            }
        }
    }
}
