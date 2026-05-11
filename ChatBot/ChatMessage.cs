using System.Drawing;

namespace ChatBot
{
    public class ChatMessage
    {
        public string Speaker { get; set; }
        public string Text { get; set; }
        public Color Colour { get; set; }

        public ChatMessage(string speaker, string text, Color colour)
        {
            Speaker = speaker;
            Text = text;
            Colour = colour;
        }

        // Factory methods so we don't repeat Color values everywhere
        public static ChatMessage Bot(string text) 
            => new ChatMessage("BOT", text, Color.FromArgb(100, 220, 100));

        public static ChatMessage Empathy(string text)
            => new ChatMessage("BOT", text, Color.FromArgb(255, 200, 80));

        public static ChatMessage Memory(string text)
            => new ChatMessage("BOT", text, Color.FromArgb(80, 200, 255));

        public static ChatMessage Warning(string text)
            => new ChatMessage("BOT", text, Color.FromArgb(255, 120, 80));
    }
}
