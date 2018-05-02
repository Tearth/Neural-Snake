using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Neuro;

namespace NeuralSnake.AI
{
    public class GameSession
    {
        public Board Board { get; }
        public ActivationNetwork NeuralNetwork { get; }

        public GameState GameState { get; private set; }

        public double[] LastInput { get; private set; }
        public double[] LastOutput => NeuralNetwork.Output;

        public GameSession(int width, int height, int foodInterval, int foodDensity, int neurons, float alpha)
        {
            Board = new Board(width, height, foodInterval, foodDensity);
            NeuralNetwork = new ActivationNetwork(new SigmoidFunction(alpha), 4, neurons, 4);
        }

        public GameSession(int width, int height, int foodInterval, int foodDensity, int neurons, float alpha, ActivationNetwork network)
        {
            Board = new Board(width, height, foodInterval, foodDensity);
            NeuralNetwork = network;
        }

        public void NextTurn()
        {
            if (GameState != GameState.Done)
            {
                Board.Direction = CalculateDirection(Board, Board.SnakeHead);
                Board.NextTurn();
            }

            if (Board.Dead || Board.Turn >= 60)
            {
                GameState = GameState.Done;
            }
        }

        private Direction CalculateDirection(Board board, Point head)
        {
            var input = new[]
            {
                GetFieldValue(board[head.X, head.Y - 1]),
                GetFieldValue(board[head.X + 1, head.Y]),
                GetFieldValue(board[head.X, head.Y + 1]),
                GetFieldValue(board[head.X - 1, head.Y])
            };

            var output = NeuralNetwork.Compute(input).ToList();
            var maxValue = output.Max();
            var maxIndex = output.IndexOf(maxValue);

            LastInput = input;

            return (Direction)maxIndex + 1;
        }

        private double GetFieldValue(FieldType type)
        {
            return Convert.ToDouble(type == FieldType.Empty || type == FieldType.Food);
        }
    }
}
