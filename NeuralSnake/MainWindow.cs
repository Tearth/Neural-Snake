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
        private const int BoardWidth = 25;
        private const int BoardHeight = 20;
        private const int FoodInterval = 10;
        private const int FoodDensity = 2;
        private const int Neurons = 10;
        private const float Alpha = 0.5f;

        private List<GameSession> _sessions;
        private System.Timers.Timer _turnTimer;

        private int _selectedBoard;

        public MainWindow()
        {
            InitializeComponent();

            _sessions = new List<GameSession>();

            _turnTimer = new System.Timers.Timer(100);
            _turnTimer.Elapsed += TurnTimer_Elapsed;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < 20; i++)
            {
                _sessions.Add(new GameSession(BoardWidth, BoardHeight, FoodInterval, FoodDensity, Neurons, Alpha));
                Invoke(new Action(() => BoardsListBox.Items.Add("")));
            }

            _turnTimer.Start();
        }

        private void TurnTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                UpdateUI();
                Redraw();

                UpdateGeneration();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void UpdateUI()
        {
            for(var i=0; i<_sessions.Count; i++)
            {
                if (_sessions[i].GameState == GameState.Running)
                {
                    _sessions[i].NextTurn();
                }

                var item = $"{_sessions[i].GameState}, {_sessions[i].Board.Score}";
                Invoke(new Action(() => BoardsListBox.Items[i] = item));
            }

            var lastInput = _sessions[_selectedBoard].NeuralNetwork.LastInput;
            var lastOutput = _sessions[_selectedBoard].NeuralNetwork.LastOutput;

            if (lastInput != null)
            {
                Invoke(new Action(() => InputTopLabel.Text = $"Top: {lastInput[0]}"));
                Invoke(new Action(() => InputRightLabel.Text = $"Rig: {lastInput[1]}"));
                Invoke(new Action(() => InputBottomLabel.Text = $"Bot: {lastInput[2]}"));
                Invoke(new Action(() => InputLeftLabel.Text = $"Lef: {lastInput[3]}"));
            }

            if (lastOutput != null)
            {
                Invoke(new Action(() => OutputTopLabel.Text = $"Top: {lastOutput[0]:0.000}"));
                Invoke(new Action(() => OutputRightLabel.Text = $"Rig: {lastOutput[1]:0.000}"));
                Invoke(new Action(() => OutputBottomLabel.Text = $"Bot: {lastOutput[2]:0.000}"));
                Invoke(new Action(() => OutputLeftLabel.Text = $"Lef: {lastOutput[3]:0.000}"));
            }
        }

        private void Redraw()
        {
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
            if (_sessions.TrueForAll(p => p.GameState == GameState.Done || p.Board.Turn >= 60))
            {
                var sortedBoards = _sessions.OrderByDescending(p => p.Board.Score);
                var bestBoards = sortedBoards.Take(5).ToList();

                _sessions.Clear();

                foreach (var board in bestBoards)
                {
                    for (var i = 0; i < 4; i++)
                    {
                       // var clonedBoard = board.Clone();
                       // _boards.Add(clonedBoard);
                    }
                }
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
