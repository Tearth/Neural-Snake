using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Neuro;

namespace NeuralSnake.AI
{
    public class NeuralNetwork
    {
        private ActivationNetwork _network;

        public NeuralNetwork()
        {
            _network = new ActivationNetwork(new SigmoidFunction(), 4, 8, 4);
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

            return (Direction)maxIndex + 1;
        }

        private double GetFieldValue(FieldType type)
        {
            return Convert.ToDouble(type == FieldType.Empty || type == FieldType.Food);
        }
    }
}
