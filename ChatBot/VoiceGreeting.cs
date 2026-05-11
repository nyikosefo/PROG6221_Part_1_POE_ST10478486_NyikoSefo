using System;
using System.Media;
using System.IO; // <-- You must add this to use 'Path'

namespace ChatBot
{
    public static class VoiceGreeting
    {
        // This builds a path that looks inside an "Audio" folder next to your .exe file
        private static readonly string AudioFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Audio", "Greeting.wav");

        public static void PlayGreeting()
        {
            try
            {
                // It's good practice to check if the file exists before trying to play it
                if (File.Exists(AudioFilePath))
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(AudioFilePath);
                    player.Play();
                }
            }
            catch (Exception)
            {
                // Fails quietly if the audio system is broken or file is unreadable
            }
        }
    }
}