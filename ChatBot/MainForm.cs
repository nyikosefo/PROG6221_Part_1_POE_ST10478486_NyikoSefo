using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ChatBot
{
    public partial class MainForm : Form
    {
        // Delegate declaration (required by assignment)
        public delegate void AppendMessageDelegate(string speaker,
                                                   string message,
                                                   Color colour);
        private AppendMessageDelegate appendMessage;

        private ChatBotEngine engine;

        public MainForm()
        {
            InitializeComponent();  // This calls the Designer.cs setup
            engine = new ChatBotEngine();
            appendMessage = new AppendMessageDelegate(AppendMessage);

            // FIX 1: Removed 'this.Load += MainForm_Load;' to stop double-loading
        }

        // Notice the 'async' keyword added here!
        private async void MainForm_Load(object sender, EventArgs e)
        {
            // Start the audio playing in the background
            VoiceGreeting.PlayGreeting();

            AppendRaw(">>> SYSTEM BOOT SUCCESSFUL\n\n", Color.Cyan);
            AppendRaw(DisplayHelper.GetAsciiArt() + "\n", Color.FromArgb(0, 200, 200));

            // Await the new typing method! 
            // The '45' is the millisecond delay per letter. 
            await TypeMessageAsync("BOT",
                "Hello! Welcome to the CyberSecurity Awareness Bot. I'm here to help you stay safe online.",
                Color.FromArgb(100, 220, 100), 60);

            await TypeMessageAsync("BOT",
                "Before we begin — what's your name?",
                Color.FromArgb(100, 220, 100), 45);

            engine.State = ConversationState.WaitingForName;
            inputBox.Focus();
        }
        private void sendButton_Click(object sender, EventArgs e)
        {
            ProcessInput();
        }

        private void inputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ProcessInput();
            }
        }

        private void ProcessInput()
        {
            string userInput = inputBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(userInput)) return;

            appendMessage(engine.UserName ?? "YOU", userInput,
                Color.FromArgb(150, 180, 255));
            inputBox.Clear();

            statusLabel.Text = "CyberBot is typing...";
            Application.DoEvents();
            Thread.Sleep(600);
            statusLabel.Text = "";

            var messages = engine.ProcessInput(userInput);

            foreach (var msg in messages)
            {
                appendMessage(msg.Speaker, msg.Text, msg.Colour);
            }

            if (engine.State == ConversationState.Exiting)
            {
                Thread.Sleep(1500);
                this.Close();
            }
        }

        private void AppendMessage(string speaker, string message, Color colour)
        {
            chatDisplay.SelectionStart = chatDisplay.TextLength;
            chatDisplay.SelectionLength = 0;

            chatDisplay.SelectionColor = Color.FromArgb(180, 180, 180);
            chatDisplay.AppendText($"\n  [ {speaker} ]\n");

            chatDisplay.SelectionColor = colour;
            chatDisplay.AppendText($"  {message}\n");

            chatDisplay.SelectionColor = Color.FromArgb(40, 40, 60);
            chatDisplay.AppendText("  ──────────────────────────────────────────\n");

            chatDisplay.ScrollToCaret();
        }
        private async Task TypeMessageAsync(string speaker, string message, Color colour, int speedMs)
        {
            chatDisplay.SelectionStart = chatDisplay.TextLength;
            chatDisplay.SelectionLength = 0;

            chatDisplay.SelectionColor = Color.FromArgb(180, 180, 180);
            chatDisplay.AppendText($"\n  [ {speaker} ]\n  ");

            chatDisplay.SelectionColor = colour;

            // The Typewriter Loop!
            foreach (char c in message)
            {
                chatDisplay.AppendText(c.ToString());
                chatDisplay.ScrollToCaret();
                await Task.Delay(speedMs); // Pauses briefly for each letter
            }

            chatDisplay.AppendText("\n");
            chatDisplay.SelectionColor = Color.FromArgb(40, 40, 60);
            chatDisplay.AppendText("  ──────────────────────────────────────────\n");
            chatDisplay.ScrollToCaret();
        }
        private void AppendRaw(string text, Color colour)
        {
            chatDisplay.SelectionStart = chatDisplay.TextLength;
            chatDisplay.SelectionColor = colour;
            chatDisplay.AppendText(text);
            chatDisplay.ScrollToCaret();
        }

        private void chatDisplay_TextChanged(object sender, EventArgs e)
        {

        }
    }
}