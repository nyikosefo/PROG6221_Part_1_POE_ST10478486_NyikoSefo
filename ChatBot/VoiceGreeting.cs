using System;
using System.Media;


namespace ChatBot
{
    public static class VoiceGreeting
    {
        private static readonly string AudioFilePath = @"C:\Users\mahun\OneDrive\Documents\Code\CybersecurityBot\Audio\Greeting.wav";

        public static void PlayGreeting()
        {
            try
            {
                using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(AudioFilePath))
                {
                    player.PlaySync();
                }
            }
            catch (Exception)
            {
                DisplayHelper.TypeText("[Voice greeting unavailable]",
                    ConsoleColor.DarkGray);
            }
        }
    }
}
