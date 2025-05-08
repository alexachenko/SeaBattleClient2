using System;
using System.Drawing;
using System.Windows.Forms;

namespace SeaBattleClient2
{
    public class GameBoard
    {
        public event EventHandler<CellClickedEventArgs> OnCellClicked;

        private readonly Panel _panel;
        private readonly bool _isMyBoard;
        private readonly Button[,] _cells = new Button[10, 10];
        private readonly int[,] _state = new int[10, 10]; // 0 - empty, 1 - ship, 2 - hit, 3 - miss

        public GameBoard(Panel panel, bool isMyBoard)
        {
            _panel = panel;
            _isMyBoard = isMyBoard;
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            _panel.Controls.Clear();

            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    var cell = new Button
                    {
                        Size = new Size(23, 23),
                        Location = new Point(col * 24, row * 26),
                        Tag = new Point(row, col),
                        BackColor = Color.LightBlue
                    };

                    cell.Click += Cell_Click;
                    _panel.Controls.Add(cell);
                    _cells[row, col] = cell;
                }
            }
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var location = (Point)button.Tag;
            OnCellClicked?.Invoke(this, new CellClickedEventArgs(location.X, location.Y));
        }

        public void ToggleShip(int row, int col)
        {
            if (_isMyBoard)
            {
                _state[row, col] = _state[row, col] == 0 ? 1 : 0;
                _cells[row, col].BackColor = _state[row, col] == 1 ? Color.Gray : Color.LightBlue;
            }
        }

        public void MarkHit(int row, int col, bool isHit)
        {
            _state[row, col] = isHit ? 2 : 3;
            _cells[row, col].BackColor = isHit ? Color.Red : Color.White;
            _cells[row, col].Enabled = false;
        }

        public bool Enabled
        {
            set
            {
                foreach (Button cell in _cells)
                {
                    cell.Enabled = value;
                }
            }
        }
    }

    public class CellClickedEventArgs : EventArgs
    {
        public int Row { get; }
        public int Col { get; }

        public CellClickedEventArgs(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}