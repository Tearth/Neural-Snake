using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuralSnake.AI;

namespace NeuralSnake
{
    public partial class GameWindow : Form
    {
        private Board _board;
        private List<Panel> _panels;

        public GameWindow(int size)
        {
            InitializeComponent();

            _board = new Board(size);
            _panels = new List<Panel>();

            Redraw();
        }

        private void Redraw()
        {
            var board = _board.GetAll();

            var fieldSize = GameAreaPanel.Size.Width / _board.Size;
            var yOffset = Size.Height - (fieldSize * _board.Size);

            foreach (var panel in _panels)
            {
                GameAreaPanel.Controls.Remove(panel);
            }

            _panels.Clear();

            for (var x = 0; x < _board.Size; x++)
            {
                for (var y = 0; y < _board.Size; y++)
                {
                    var panel = new Panel
                    {
                        BackColor = GetFieldColor(_board[x, y]),
                        Size = new Size(fieldSize, fieldSize),
                        Location = new Point(x * fieldSize, y * fieldSize),
                        Margin = new Padding(0, 0, 0, 0)
                    };

                    _panels.Add(panel);
                    GameAreaPanel.Controls.Add(panel);
                }
            }
        }

        private Color GetFieldColor(FieldType type)
        {
            switch (type)
            {
                case FieldType.Empty: return Color.Transparent;
                case FieldType.Head: return Color.Green;
                case FieldType.Body: return Color.White;
                case FieldType.Food: return Color.Yellow;
                case FieldType.Wall: return Color.Violet;
            }

            return Color.Black;
        }
    }
}
