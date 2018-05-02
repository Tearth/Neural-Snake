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

        public GameSession(int width, int height, int foodInterval, int foodDensity, int neurons, float alpha, int seed)
        {
            Board = new Board(width, height, foodInterval, foodDensity, seed);
            NeuralNetwork = new ActivationNetwork(new BipolarSigmoidFunction(alpha), 8, neurons, 4);
        }

        public GameSession(int width, int height, int foodInterval, int foodDensity, int neurons, float alpha, int seed, ActivationNetwork network)
        {
            Board = new Board(width, height, foodInterval, foodDensity, seed);
            NeuralNetwork = network;
        }

        public void NextTurn()
        {
            if (GameState != GameState.Done)
            {
                Board.Direction = CalculateDirection();
                Board.NextTurn();
            }

            if (Board.Dead || Board.Turn >= 500 || Board.Score < -80)
            {
                GameState = GameState.Done;
            }
        }

        private Direction CalculateDirection()
        {
            var nearestFood = Board.GetNearestFood();
            var input = new[]
            {
                GetFieldValue(Board[Board.SnakeHead.X, Board.SnakeHead.Y - 1]) * 2 - 1,
                GetFieldValue(Board[Board.SnakeHead.X + 1, Board.SnakeHead.Y]) * 2 - 1,
                GetFieldValue(Board[Board.SnakeHead.X, Board.SnakeHead.Y + 1]) * 2 - 1,
                GetFieldValue(Board[Board.SnakeHead.X - 1, Board.SnakeHead.Y]) * 2 - 1,

                Convert.ToDouble(nearestFood.Item1.Y < Board.SnakeHead.Y) * 2 - 1,
                Convert.ToDouble(nearestFood.Item1.X > Board.SnakeHead.X) * 2 - 1,
                Convert.ToDouble(nearestFood.Item1.Y > Board.SnakeHead.Y) * 2 - 1,
                Convert.ToDouble(nearestFood.Item1.X < Board.SnakeHead.X) * 2 - 1
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
