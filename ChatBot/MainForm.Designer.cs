namespace ChatBot
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            headerPanel = new Panel();
            titleLabel = new Label();
            inputPanel = new Panel();
            inputBox = new TextBox();
            sendButton = new Button();
            statusLabel = new Label();
            chatDisplay = new RichTextBox();
            headerPanel.SuspendLayout();
            inputPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(30, 30, 50);
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(804, 70);
            headerPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Dock = DockStyle.Left;
            titleLabel.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.FromArgb(100, 200, 255);
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(611, 32);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "🛡️  CyberBot — Cybersecurity Awareness Assistant";
            // 
            // inputPanel
            // 
            inputPanel.BackColor = Color.FromArgb(30, 30, 50);
            inputPanel.Controls.Add(inputBox);
            inputPanel.Controls.Add(sendButton);
            inputPanel.Dock = DockStyle.Bottom;
            inputPanel.Location = new Point(0, 521);
            inputPanel.Name = "inputPanel";
            inputPanel.Padding = new Padding(10);
            inputPanel.Size = new Size(804, 60);
            inputPanel.TabIndex = 1;
            // 
            // inputBox
            // 
            inputBox.BackColor = Color.FromArgb(45, 45, 70);
            inputBox.Dock = DockStyle.Fill;
            inputBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputBox.ForeColor = Color.White;
            inputBox.Location = new Point(10, 10);
            inputBox.Name = "inputBox";
            inputBox.PlaceholderText = "Type your question here and press Enter...";
            inputBox.Size = new Size(694, 27);
            inputBox.TabIndex = 1;
            inputBox.KeyDown += inputBox_KeyDown;
            // 
            // sendButton
            // 
            sendButton.BackColor = Color.FromArgb(0, 120, 200);
            sendButton.Cursor = Cursors.Hand;
            sendButton.Dock = DockStyle.Right;
            sendButton.FlatStyle = FlatStyle.Flat;
            sendButton.ForeColor = Color.White;
            sendButton.Location = new Point(704, 10);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(90, 40);
            sendButton.TabIndex = 0;
            sendButton.Text = "Send";
            sendButton.UseVisualStyleBackColor = false;
            sendButton.Click += sendButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Dock = DockStyle.Bottom;
            statusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            statusLabel.ForeColor = Color.FromArgb(100, 200, 100);
            statusLabel.Location = new Point(0, 506);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(0, 15);
            statusLabel.TabIndex = 2;
            // 
            // chatDisplay
            // 
            chatDisplay.BackColor = Color.FromArgb(18, 18, 30);
            chatDisplay.BorderStyle = BorderStyle.None;
            chatDisplay.Dock = DockStyle.Fill;
            chatDisplay.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chatDisplay.ForeColor = Color.White;
            chatDisplay.Location = new Point(0, 70);
            chatDisplay.Name = "chatDisplay";
            chatDisplay.ReadOnly = true;
            chatDisplay.ScrollBars = RichTextBoxScrollBars.Vertical;
            chatDisplay.Size = new Size(804, 436);
            chatDisplay.TabIndex = 3;
            chatDisplay.Text = "";
            chatDisplay.TextChanged += chatDisplay_TextChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 30);
            ClientSize = new Size(804, 581);
            Controls.Add(chatDisplay);
            Controls.Add(statusLabel);
            Controls.Add(inputPanel);
            Controls.Add(headerPanel);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimumSize = new Size(600, 450);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CyberBot — Cybersecurity Awareness Assistant";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            inputPanel.ResumeLayout(false);
            inputPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel headerPanel;
        private Label titleLabel;
        private Panel inputPanel;
        private Button sendButton;
        private TextBox inputBox;
        private Label statusLabel;
        private RichTextBox chatDisplay;
    }
}