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
        private Board _board;
        private System.Timers.Timer _turnTimer;

        public MainWindow()
        {
            InitializeComponent();

            _board = new Board(25, 15, 10, 1);

            _turnTimer = new System.Timers.Timer(200);
            _turnTimer.Elapsed += TurnTimer_Elapsed;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            _turnTimer.Start();
        }

        private void TurnTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            
                var test = new ActivationNetwork(new SigmoidFunction(), 3, 4);
                var w = test.Compute(new[] { -1.0d, -1.0d, 1.0d }).ToList();

                var max = w.Max();
                var i = w.IndexOf(max);

                _board.Direction = (Direction)i + 1;

            _board.NextTurn();
            Redraw();
        }

        private void Redraw()
        {
            var g = GraphicArea.CreateGraphics();

            var fieldWidth = GraphicArea.Size.Width / _board.Width;
            var fieldHeight = GraphicArea.Size.Height / _board.Height;

            for (var x = 0; x < _board.Width; x++)
            {
                for (var y = 0; y < _board.Height; y++)
                {
                    var color = GetFieldColor(_board[x, y]);
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
    }
}
