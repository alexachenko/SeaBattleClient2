namespace SeaBattleClient2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMyField = new System.Windows.Forms.Panel();
            this.pnlEnemyField = new System.Windows.Forms.Panel();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lstPlayers = new System.Windows.Forms.ListBox();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnRefreshPlayers = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnSurrender = new System.Windows.Forms.Button();
            this.btnOfferDraw = new System.Windows.Forms.Button();
            this.btnObserve = new System.Windows.Forms.Button();
            this.lblMyField = new System.Windows.Forms.Label();
            this.lblEnemyField = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlMyField
            // 
            this.pnlMyField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMyField.Location = new System.Drawing.Point(60, 70);
            this.pnlMyField.Name = "pnlMyField";
            this.pnlMyField.Size = new System.Drawing.Size(322, 320);
            this.pnlMyField.TabIndex = 0;
            // 
            // pnlEnemyField
            // 
            this.pnlEnemyField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEnemyField.Location = new System.Drawing.Point(460, 70);
            this.pnlEnemyField.Name = "pnlEnemyField";
            this.pnlEnemyField.Size = new System.Drawing.Size(322, 320);
            this.pnlEnemyField.TabIndex = 1;
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(800, 70);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.ReadOnly = true;
            this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChat.Size = new System.Drawing.Size(330, 300);
            this.txtChat.TabIndex = 2;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(800, 375);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(220, 22);
            this.txtMessage.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(1025, 375);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(105, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Отправить";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // lstPlayers
            // 
            this.lstPlayers.FormattingEnabled = true;
            this.lstPlayers.ItemHeight = 16;
            this.lstPlayers.Location = new System.Drawing.Point(800, 401);
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstPlayers.Size = new System.Drawing.Size(330, 148);
            this.lstPlayers.TabIndex = 5;
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(50, 20);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(100, 22);
            this.txtPlayerName.TabIndex = 6;
            this.txtPlayerName.Text = "Player2";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(160, 20);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(100, 22);
            this.txtServerIP.TabIndex = 7;
            this.txtServerIP.Text = "127.0.0.1";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(266, 20);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(128, 23);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Подключиться";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(400, 20);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(115, 23);
            this.btnDisconnect.TabIndex = 9;
            this.btnDisconnect.Text = "Отключиться";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            // 
            // btnRefreshPlayers
            // 
            this.btnRefreshPlayers.Enabled = false;
            this.btnRefreshPlayers.Location = new System.Drawing.Point(1025, 401);
            this.btnRefreshPlayers.Name = "btnRefreshPlayers";
            this.btnRefreshPlayers.Size = new System.Drawing.Size(105, 23);
            this.btnRefreshPlayers.TabIndex = 10;
            this.btnRefreshPlayers.Text = "Обновить";
            this.btnRefreshPlayers.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(63, 427);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(109, 16);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Не подключено";
            // 
            // btnSurrender
            // 
            this.btnSurrender.Enabled = false;
            this.btnSurrender.Location = new System.Drawing.Point(66, 457);
            this.btnSurrender.Name = "btnSurrender";
            this.btnSurrender.Size = new System.Drawing.Size(79, 23);
            this.btnSurrender.TabIndex = 12;
            this.btnSurrender.Text = "Сдаться";
            this.btnSurrender.UseVisualStyleBackColor = true;
            // 
            // btnOfferDraw
            // 
            this.btnOfferDraw.Enabled = false;
            this.btnOfferDraw.Location = new System.Drawing.Point(151, 457);
            this.btnOfferDraw.Name = "btnOfferDraw";
            this.btnOfferDraw.Size = new System.Drawing.Size(194, 23);
            this.btnOfferDraw.TabIndex = 13;
            this.btnOfferDraw.Text = "Предложить ничью";
            this.btnOfferDraw.UseVisualStyleBackColor = true;
            // 
            // btnObserve
            // 
            this.btnObserve.Enabled = false;
            this.btnObserve.Location = new System.Drawing.Point(1025, 431);
            this.btnObserve.Name = "btnObserve";
            this.btnObserve.Size = new System.Drawing.Size(105, 23);
            this.btnObserve.TabIndex = 14;
            this.btnObserve.Text = "Наблюдать";
            this.btnObserve.UseVisualStyleBackColor = true;
            // 
            // lblMyField
            // 
            this.lblMyField.AutoSize = true;
            this.lblMyField.Location = new System.Drawing.Point(175, 395);
            this.lblMyField.Name = "lblMyField";
            this.lblMyField.Size = new System.Drawing.Size(76, 16);
            this.lblMyField.TabIndex = 15;
            this.lblMyField.Text = "Ваше поле";
            // 
            // lblEnemyField
            // 
            this.lblEnemyField.AutoSize = true;
            this.lblEnemyField.Location = new System.Drawing.Point(565, 395);
            this.lblEnemyField.Name = "lblEnemyField";
            this.lblEnemyField.Size = new System.Drawing.Size(114, 16);
            this.lblEnemyField.TabIndex = 16;
            this.lblEnemyField.Text = "Поле соперника";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 603);
            this.Controls.Add(this.lblEnemyField);
            this.Controls.Add(this.lblMyField);
            this.Controls.Add(this.btnObserve);
            this.Controls.Add(this.btnOfferDraw);
            this.Controls.Add(this.btnSurrender);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRefreshPlayers);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtServerIP);
            this.Controls.Add(this.txtPlayerName);
            this.Controls.Add(this.lstPlayers);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.pnlEnemyField);
            this.Controls.Add(this.pnlMyField);
            this.Name = "Form1";
            this.Text = "Морской бой";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMyField;
        private System.Windows.Forms.Panel pnlEnemyField;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox lstPlayers;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnRefreshPlayers;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnSurrender;
        private System.Windows.Forms.Button btnOfferDraw;
        private System.Windows.Forms.Button btnObserve;
        private System.Windows.Forms.Label lblMyField;
        private System.Windows.Forms.Label lblEnemyField;
    }
}

