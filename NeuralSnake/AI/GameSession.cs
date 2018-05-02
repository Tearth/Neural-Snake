using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralSnake.AI
{
    public class GameSession
    {
        public Board Board { get; }
        public NeuralNetwork NeuralNetwork { get; }

        public GameState GameState { get; private set; }

        public GameSession(int width, int height, int foodInterval, int foodDensity, int neurons, float alpha)
        {
            Board = new Board(width, height, foodInterval, foodDensity);
            NeuralNetwork = new NeuralNetwork(neurons, alpha);
        }

        public void NextTurn()
        {
            if (GameState != GameState.Done)
            {
                Board.Direction = NeuralNetwork.Calculate(Board, Board.SnakeHead);
                Board.NextTurn();
            }

            if (Board.Dead)
            {
                GameState = GameState.Done;
            }
        }
    }
}
