using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using NeuralSnake.AI;

namespace NeuralSnake
{
    public partial class MainWindow : Form
    {
        public const int BoardWidth = 25;
        public const int BoardHeight = 20;
        public const int FoodInterval = 10;
        public const int FoodDensity = 10;
        public const int Neurons = 100;
        public const float Alpha = 0.5f;

        private List<GameSession> _sessions;
        private System.Timers.Timer _turnTimer;
        private Random _random;

        private int _selectedBoard;
        private int _generation;
        private int _maxScore;
        private int _avgScore;

        public MainWindow()
        {
            InitializeComponent();

            _sessions = new List<GameSession>();
            _random = new Random();

            _turnTimer = new System.Timers.Timer(20);
            _turnTimer.Elapsed += TurnTimer_Elapsed;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            var seed = (int)DateTime.Now.Ticks;
            for (var i = 0; i < 18; i++)
            {
                _sessions.Add(new GameSession(BoardWidth, BoardHeight, FoodInterval, FoodDensity, Neurons, Alpha, seed));
                Invoke(new Action(() => BoardsListBox.Items.Add("")));
            }

            _turnTimer.Start();
        }

        private void TurnTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _turnTimer.Stop();
            if (_sessions.Count > 0)
            {
                UpdateUI();
                Redraw();
            }

            for(int i=0; i<1000; i++)
            UpdateGeneration();
            _turnTimer.Start();
        }

        private void UpdateUI()
        {
            for (var i = 0; i < _sessions.Count; i++)
            {
                var item = $"{_sessions[i].GameState}, {_sessions[i].Board.Score}";
                Invoke(new Action(() => BoardsListBox.Items[i] = item));
            }

            if (_sessions.Count > 0)
            {
                var lastInput = _sessions[_selectedBoard].LastInput;
                var lastOutput = _sessions[_selectedBoard].LastOutput;

                if (lastInput != null)
                {
                    Invoke(new Action(() => InputTopLabel.Text = $"Top: {lastInput[0]}"));
                    Invoke(new Action(() => InputRightLabel.Text = $"Rig: {lastInput[1]}"));
                    Invoke(new Action(() => InputBottomLabel.Text = $"Bot: {lastInput[2]}"));
                    Invoke(new Action(() => InputLeftLabel.Text = $"Lef: {lastInput[3]}"));

                    Invoke(new Action(() => InputFoodTopLabel.Text = $"FTo: {lastInput[4]}"));
                    Invoke(new Action(() => InputFoodRightLabel.Text = $"FRi: {lastInput[5]}"));
                    Invoke(new Action(() => InputFoodBottomLabel.Text = $"FBo: {lastInput[6]}"));
                    Invoke(new Action(() => InputFoodLeftLabel.Text = $"FLe: {lastInput[7]}"));
                }

                if (lastOutput != null)
                {
                    Invoke(new Action(() => OutputTopLabel.Text = $"Top: {lastOutput[0]:0.000}"));
                    Invoke(new Action(() => OutputRightLabel.Text = $"Rig: {lastOutput[1]:0.000}"));
                    Invoke(new Action(() => OutputBottomLabel.Text = $"Bot: {lastOutput[2]:0.000}"));
                    Invoke(new Action(() => OutputLeftLabel.Text = $"Lef: {lastOutput[3]:0.000}"));
                }
                Invoke(new Action(() => MaxScoreLabel.Text = $"Max score: {_maxScore}"));
                Invoke(new Action(() => GenerationLabel.Text = $"Generation: {_generation}"));
                Invoke(new Action(() => AvgScoreLabel.Text = $"Avg score: {_avgScore}"));
            }

        }

        private void Redraw()
        {
            if (_sessions.Count == 0)
            {
                return;
            }

            var g = GraphicArea.CreateGraphics();

            var fieldWidth = GraphicArea.Size.Width / BoardWidth;
            var fieldHeight = GraphicArea.Size.Height / BoardHeight;

            for (var x = 0; x < BoardWidth; x++)
            {
                for (var y = 0; y < BoardHeight; y++)
                {
                    var color = GetFieldColor(_sessions[_selectedBoard].Board[x, y]);
                    var brush = new SolidBrush(color);

                    g.FillRectangle(brush, x * fieldWidth, y * fieldHeight, fieldWidth, fieldHeight);
                }
            }
        }

        private void UpdateGeneration()
        {
            foreach (var session in _sessions)
            {
                if (session.GameState == GameState.Running)
                {
                    session.NextTurn();
                }
            }

            if (_sessions.Count > 0)
            {
                _maxScore = Math.Max(_maxScore, _sessions[0].Board.Score);
            }

            if (_sessions.Count > 0 && (_sessions.TrueForAll(p => p.GameState == GameState.Done || p.Board.Turn >= 60)))
            {
                var sortedBoards = _sessions.OrderByDescending(p => p.Board.Score).ToList();

                var bestBoards = sortedBoards.Take(3).ToList();

                _avgScore = (int)_sessions.Average(p => p.Board.Score);
                _sessions.Clear();

                var networkOperations = new NetworkOperations();
                var seed = (int)DateTime.Now.Ticks;

                foreach (var board in bestBoards)
                {
                    var main = new GameSession(BoardWidth, BoardHeight, FoodInterval, FoodDensity, Neurons, Alpha, seed, board.NeuralNetwork);
                    _sessions.Add(main);

                    for (var i = 0; i < 5; i++)
                    {
                        var leftParent = bestBoards[_random.Next(bestBoards.Count)].NeuralNetwork;
                        var rightParent = bestBoards[_random.Next(bestBoards.Count)].NeuralNetwork;

                        var clonedNetwork = networkOperations.Breed(leftParent, rightParent);
                        var gameSession = new GameSession(BoardWidth, BoardHeight, FoodInterval, FoodDensity, Neurons, Alpha, seed, clonedNetwork);

                        networkOperations.Mutate(clonedNetwork);
                        _sessions.Add(gameSession);
                    }
                }

                _generation++;
            }
        }

        private Color GetFieldColor(FieldType type)
        {
            switch (type)
            {
                case FieldType.Empty: return Color.White;
                case FieldType.Head: return Color.Brown;
                case FieldType.Body: return Color.Green;
                case FieldType.Food: return Color.Blue;
                case FieldType.Wall: return Color.DarkSlateGray;
            }

            return Color.Black;
        }

        private void BoardsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var index = BoardsListBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                _selectedBoard = index;
            }
        }
    }
}
