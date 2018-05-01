using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using AForge.Neuro;
using NeuralSnake.AI;

namespace NeuralSnake
{
    public partial class MainWindow : Form
    {
        private List<Board> _boards;
        private System.Timers.Timer _turnTimer;

        private int _selectedBoard;

        public MainWindow()
        {
            InitializeComponent();

            _boards = new List<Board>();

            _turnTimer = new System.Timers.Timer(200);
            _turnTimer.Elapsed += TurnTimer_Elapsed;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                _boards.Add(new Board(25, 20, 10, 1));
                Invoke(new Action(() => BoardsListBox.Items.Add("")));
            }

            _turnTimer.Start();
        }

        private void TurnTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            for(int i=0; i<_boards.Count; i++)
            {
                if (_boards[i].GameState == GameState.Waiting || _boards[i].GameState == GameState.Running)
                {
                    _boards[i].NextTurn();
                }

                var item = $"{_boards[i].GameState}, {_boards[i].Score}";
                Invoke(new Action(() => BoardsListBox.Items[i] = item));
            }

            var lastInput = _boards[_selectedBoard].LastInput;
            var lastOutput = _boards[_selectedBoard].LastOutput;

            Invoke(new Action(() => InputTopLabel.Text =        $"Top: {lastInput[0]}"));
            Invoke(new Action(() => InputRightLabel.Text =      $"Rig: {lastInput[1]}"));
            Invoke(new Action(() => InputBottomLabel.Text =     $"Bot: {lastInput[2]}"));
            Invoke(new Action(() => InputLeftLabel.Text =       $"Lef: {lastInput[3]}"));

            Invoke(new Action(() => OutputTopLabel.Text =       $"Top: {lastOutput[0]:0.000}"));
            Invoke(new Action(() => OutputRightLabel.Text =     $"Rig: {lastOutput[1]:0.000}"));
            Invoke(new Action(() => OutputBottomLabel.Text =    $"Bot: {lastOutput[2]:0.000}"));
            Invoke(new Action(() => OutputLeftLabel.Text =      $"Lef: {lastOutput[3]:0.000}"));

            Redraw();
        }

        private void Redraw()
        {
            var g = GraphicArea.CreateGraphics();

            var fieldWidth = GraphicArea.Size.Width / _boards[_selectedBoard].Width;
            var fieldHeight = GraphicArea.Size.Height / _boards[_selectedBoard].Height;

            for (var x = 0; x < _boards[_selectedBoard].Width; x++)
            {
                for (var y = 0; y < _boards[_selectedBoard].Height; y++)
                {
                    var color = GetFieldColor(_boards[_selectedBoard][x, y]);
                    var brush = new SolidBrush(color);

                    g.FillRectangle(brush, x * fieldWidth, y * fieldHeight, fieldWidth, fieldHeight);
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
