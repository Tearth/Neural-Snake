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

        private double GetFieldValue(FieldType type)
        {
            return Convert.ToDouble(type == FieldType.Empty || type == FieldType.Food);
        }
    }
}
