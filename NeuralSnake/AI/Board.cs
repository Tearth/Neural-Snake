using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace NeuralSnake.AI
{
    public class Board
    {
        public GameState GameState { get; private set; }
        public int Width { get; }
        public int Height { get; }
        public int Turn { get; private set; }
        public Direction Direction { get; set; }

        private FieldType[,] _board;
        private int _foodInterval;
        private int _foodDensity;
        private List<Point> _snake;

        private Random _random;

        public Board(int width, int height, int foodInterval, int foodDensity)
        {
            _board = new FieldType[width, height];
            _foodInterval = foodInterval;
            _foodDensity = foodDensity;
            _snake = new List<Point>();
            _random = new Random();

            GameState = GameState.Waiting;
            Width = width;
            Height = height;
            Turn = 1;
            Direction = Direction.None;

            for (var i = 0; i < Width; i++)
            {
                _board[i, 0] = FieldType.Wall;
                _board[i, Height - 1] = FieldType.Wall;
            }

            for (var i = 0; i < Height; i++)
            {
                _board[0, i] = FieldType.Wall;
                _board[Width - 1, i] = FieldType.Wall;
            }

            _snake.Add(new Point(Width / 2, Height / 2));
            _board[_snake[0].X, _snake[0].Y] = FieldType.Head;
        }

        public void NextTurn()
        {
            GameState = GameState.Running;

            UpdateSnake();
            if (Turn % _foodInterval == 0)
            {
                AddRandomFood();
            }

            Turn++;
        }

        public FieldType[,] GetAll()
        {
            return _board;
        }

        public FieldType this[int x, int y]
        {
            get => _board[x, y];
            set => _board[x, y] = value;
        }

        private void AddRandomFood()
        {
            for (var i = 0; i < _foodDensity; i++)
            {
                var failedCount = 0;
                while (failedCount < 10)
                {
                    var x = _random.Next(Width - 1);
                    var y = _random.Next(Height - 1);

                    var field = _board[x, y];
                    if (field != FieldType.Empty)
                    {
                        failedCount++;
                        continue;
                    }

                    _board[x, y] = FieldType.Food;
                    break;
                }
            }
        }

        private void UpdateSnake()
        {
            if (Direction == Direction.None) return;

            var updatedHeadPos = _snake[0];
            switch (Direction)
            {
                case Direction.Up:
                {
                    updatedHeadPos = new Point(updatedHeadPos.X, updatedHeadPos.Y - 1);
                    break;
                }

                case Direction.Down:
                {
                    updatedHeadPos = new Point(updatedHeadPos.X, updatedHeadPos.Y + 1);
                    break;
                }

                case Direction.Right:
                {
                    updatedHeadPos = new Point(updatedHeadPos.X + 1, updatedHeadPos.Y);
                    break;
                }

                case Direction.Left:
                {
                    updatedHeadPos = new Point(updatedHeadPos.X - 1, updatedHeadPos.Y);
                    break;
                }
            }

            var updatedHeadField = _board[updatedHeadPos.X, updatedHeadPos.Y];
            if (updatedHeadField == FieldType.Body || updatedHeadField == FieldType.Wall)
            {
                GameState = GameState.Done;
                return;
            }

            _board[_snake[0].X, _snake[0].Y] = FieldType.Body;
            _snake.Insert(0, updatedHeadPos);
            _board[_snake[0].X, _snake[0].Y] = FieldType.Head;

            if (updatedHeadField != FieldType.Food)
            {
                _board[_snake.Last().X, _snake.Last().Y] = FieldType.Empty;
                _snake.Remove(_snake.Last());
            }
        }
    }
}
