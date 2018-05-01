using System;

namespace NeuralSnake.AI
{
    public class Board
    {
        public int Width { get; }
        public int Height { get; }
        public int Turn { get; private set; }

        private FieldType[,] _board;
        private int _foodInterval;
        private int _foodDensity;

        private Random _random;

        public FieldType this[int x, int y]
        {
            get => _board[x, y];
            set => _board[x, y] = value;
        }

        public Board(int width, int height, int foodInterval, int foodDensity)
        {
            _board = new FieldType[width, height];
            _foodInterval = foodInterval;
            _foodDensity = foodDensity;
            _random = new Random();

            Width = width;
            Height = height;
            Turn = 1;

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
        }

        public void NextTurn()
        {
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
    }
}
