using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattleClient2
{
    public partial class Form1 : Form
    {
        private GameClient _gameClient;
        private GameBoard _myBoard;
        private GameBoard _enemyBoard;

        // Объявляем массивы меток в основном классе формы
        private Label[] lblMyLetters = new Label[10];
        private Label[] lblMyNumbers = new Label[10];
        private Label[] lblEnemyLetters = new Label[10];
        private Label[] lblEnemyNumbers = new Label[10];

        // Координаты полей
        private const int fieldTop = 70;
        private const int fieldLeft = 60;

        public Form1()
        {
            InitializeComponent();
            InitializeGameBoards();
            InitializeFieldLabels();
        }

        private void InitializeGameBoards()
        {
            _myBoard = new GameBoard(pnlMyField, true);
            _enemyBoard = new GameBoard(pnlEnemyField, false);

            _myBoard.OnCellClicked += MyBoard_CellClicked;
            _enemyBoard.OnCellClicked += EnemyBoard_CellClicked;
        }

        private void InitializeFieldLabels()
        {
            // Буквы для своего поля (A-J)
            for (int i = 0; i < 10; i++)
            {
                lblMyLetters[i] = new Label
                {
                    Text = ((char)('A' + i)).ToString(),
                    Location = new Point(51 + i * 24, fieldTop - 30),
                    Size = new Size(15, 15),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 8, FontStyle.Bold)
                };
                this.Controls.Add(lblMyLetters[i]);
            }

            // Цифры для своего поля (1-10)
            for (int i = 0; i < 10; i++)
            {
                lblMyNumbers[i] = new Label
                {
                    Text = (i + 1).ToString(),
                    Location = new Point(fieldLeft - 40, 59 + i * 26),
                    Size = new Size(23, 20),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 9, FontStyle.Bold)
                };
                this.Controls.Add(lblMyNumbers[i]);
            }

            // Буквы для поля противника (A-J)
            for (int i = 0; i < 10; i++)
            {
                lblEnemyLetters[i] = new Label
                {
                    Text = ((char)('A' + i)).ToString(),
                    Location = new Point(351 + i * 24, fieldTop - 30),
                    Size = new Size(15, 15),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 8, FontStyle.Bold)
                };
                this.Controls.Add(lblEnemyLetters[i]);
            }

            // Цифры для поля противника (1-10)
            for (int i = 0; i < 10; i++)
            {
                lblEnemyNumbers[i] = new Label
                {
                    Text = (i + 1).ToString(),
                    Location = new Point(320, 59 + i * 26),
                    Size = new Size(23, 20),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 9, FontStyle.Bold)
                };
                this.Controls.Add(lblEnemyNumbers[i]);
            }
        }

        private void MyBoard_CellClicked(object sender, CellClickedEventArgs e)
        {
            // Обработка клика по своему полю (для расстановки кораблей)
            if (_gameClient?.GameState == GameState.Preparing)
            {
                _myBoard.ToggleShip(e.Row, e.Col);
            }
        }

        private void EnemyBoard_CellClicked(object sender, CellClickedEventArgs e)
        {
            // Обработка клика по полю противника (для атаки)
            if (_gameClient?.GameState == GameState.Battle && _gameClient.IsMyTurn)
            {
                _gameClient.SendAttack(e.Row, e.Col);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (_gameClient == null || !_gameClient.IsConnected)
            {
                _gameClient = new GameClient(txtServerIP.Text, txtPlayerName.Text);
                _gameClient.OnConnected += GameClient_OnConnected;
                _gameClient.OnDisconnected += GameClient_OnDisconnected;
                _gameClient.OnMessageReceived += GameClient_OnMessageReceived;
                _gameClient.OnGameStarted += GameClient_OnGameStarted;

                _gameClient.Connect();
            }
        }

        private void GameClient_OnConnected(object sender, EventArgs e)
        {
            Invoke((Action)(() =>
            {
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                btnRefreshPlayers.Enabled = true;
                UpdateStatus("Connected to server");
            }));
        }

        private void GameClient_OnDisconnected(object sender, EventArgs e)
        {
            Invoke((Action)(() =>
            {
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
                btnRefreshPlayers.Enabled = false;
                UpdateStatus("Disconnected from server");
            }));
        }

        private void GameClient_OnMessageReceived(object sender, string message)
        {
            Invoke((Action)(() =>
            {
                txtChat.AppendText(message + Environment.NewLine);
            }));
        }

        private void GameClient_OnGameStarted(object sender, GameStartedEventArgs e)
        {
            Invoke((Action)(() =>
            {
                UpdateStatus(e.IsObserver ? $"Observing {e.Player1} vs {e.Player2}" :
                    $"Playing vs {e.OpponentName}. {(e.IsMyTurn ? "Your turn" : "Opponent's turn")}");

                if (!e.IsObserver)
                {
                    _enemyBoard.Enabled = e.IsMyTurn;
                }
            }));
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _gameClient?.Disconnect();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMessage.Text) && _gameClient != null)
            {
                _gameClient.SendMessage(txtMessage.Text);
                txtMessage.Clear();
            }
        }

        private void btnRefreshPlayers_Click(object sender, EventArgs e)
        {
            _gameClient?.RequestPlayersList();
        }

        private void UpdateStatus(string status)
        {
            lblStatus.Text = status;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _gameClient?.Disconnect();
        }
    }
}
