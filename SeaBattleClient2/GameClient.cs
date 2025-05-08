using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SeaBattleClient2
{
    public class GameClient
    {
        public event EventHandler OnConnected;
        public event EventHandler OnDisconnected;
        public event EventHandler<string> OnMessageReceived;
        public event EventHandler<GameStartedEventArgs> OnGameStarted;

        private TcpClient _client;
        private NetworkStream _stream;
        private readonly string _serverIp;
        private readonly string _playerName;
        private Thread _receiveThread;

        public bool IsConnected { get; private set; }
        public GameState GameState { get; private set; } = GameState.Disconnected;
        public bool IsMyTurn { get; private set; }
        public string OpponentName { get; private set; }

        public GameClient(string serverIp, string playerName)
        {
            _serverIp = serverIp;
            _playerName = playerName;
        }

        public void Connect()
        {
            try
            {
                _client = new TcpClient();
                _client.Connect(_serverIp, 8888);
                _stream = _client.GetStream();

                Send($"SET_NAME:{_playerName}");

                IsConnected = true;
                GameState = GameState.Connected;

                _receiveThread = new Thread(ReceiveMessages);
                _receiveThread.IsBackground = true;
                _receiveThread.Start();

                OnConnected?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                OnMessageReceived?.Invoke(this, $"Connection error: {ex.Message}");
                Disconnect();
            }
        }

        public void Disconnect()
        {
            try
            {
                IsConnected = false;
                GameState = GameState.Disconnected;

                _stream?.Close();
                _client?.Close();
                _receiveThread?.Abort();

                OnDisconnected?.Invoke(this, EventArgs.Empty);
            }
            catch { /* Ignore */ }
        }

        public void RequestPlayersList()
        {
            Send("LIST_PLAYERS");
        }

        public void SendAttack(int row, int col)
        {
            Send($"ATTACK:{row},{col}");
            IsMyTurn = false;
        }

        public void SendMessage(string message)
        {
            Send($"CHAT:{message}");
        }

        private void Send(string message)
        {
            if (IsConnected)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                _stream.Write(buffer, 0, buffer.Length);
            }
        }

        private void ReceiveMessages()
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            try
            {
                while ((bytesRead = _stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    ProcessMessage(message);
                }
            }
            catch
            {
                Disconnect();
            }
        }

        private void ProcessMessage(string message)
        {
            string[] parts = message.Split(':');
            string command = parts[0];

            switch (command)
            {
                case "CHAT":
                    OnMessageReceived?.Invoke(this, $"{parts[1]}: {parts[2]}");
                    break;

                case "GAME_START":
                    GameState = GameState.Battle;
                    OpponentName = parts[2];
                    IsMyTurn = parts[1].Contains("Player 2");
                    OnGameStarted?.Invoke(this, new GameStartedEventArgs(OpponentName, IsMyTurn, false));
                    break;

                case "ATTACK_RESULT":
                    bool isHit = bool.Parse(parts[1]);
                    int row = int.Parse(parts[2]);
                    int col = int.Parse(parts[3]);
                    // Обновить доску
                    OnMessageReceived?.Invoke(this, isHit ? "Hit!" : "Miss!");
                    break;

                case "YOUR_TURN":
                    IsMyTurn = true;
                    OnMessageReceived?.Invoke(this, "Your turn!");
                    break;

                    // Другие команды...
            }
        }
    }

    public enum GameState
    {
        Disconnected,
        Connected,
        Preparing,
        Battle,
        GameOver
    }

    public class GameStartedEventArgs : EventArgs
    {
        public string OpponentName { get; }
        public bool IsMyTurn { get; }
        public bool IsObserver { get; }
        public string Player1 { get; }
        public string Player2 { get; }

        public GameStartedEventArgs(string opponentName, bool isMyTurn, bool isObserver,
                                  string player1 = null, string player2 = null)
        {
            OpponentName = opponentName;
            IsMyTurn = isMyTurn;
            IsObserver = isObserver;
            Player1 = player1;
            Player2 = player2;
        }
    }
}