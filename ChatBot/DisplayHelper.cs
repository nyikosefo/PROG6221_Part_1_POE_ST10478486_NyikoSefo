using System;
using System.Threading;

namespace ChatBot
{
    public static class DisplayHelper
    {
        public static void PrintDivider(ConsoleColor color = ConsoleColor.DarkCyan)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("══════════════════════════════════════════");
            Console.ResetColor();
        }

        public static void TypeText(string text, ConsoleColor color = ConsoleColor.White,
                                    int delayMs = 25)
        { 
            Console.ForegroundColor = color;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        public static void PrintColored(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        // NEW for Part 2 — returns ASCII art as a string so the
        // GUI's RichTextBox can display it (instead of printing to console)
        public static string GetAsciiArt()
        {
            return @"
 =======================================================           
  _____       _                 ____        _   
 / ____|     | |               |  _ \      | |  
| |    _   _ | |__    ___  _ __| |_) | ___ | |_ 
| |   | | | || '_ \  / _ \| '__|  _ < / _ \| __|
| |___| |_| || |_) ||  __/| |  | |_) | (_) | |_ 
 \_____\__, ||_.__/  \___||_|  |____/ \___/ \__|
        __/ |                                   
       |___/
   Your Digital Safety Companion
  
=========================================================
";
        }

        public static void ShowHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(GetAsciiArt());
            Console.ResetColor();
            PrintDivider();
        }

        public static void ShowSpeakerLabel(string label, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write($"  [ {label} ]  ");
            Console.ResetColor();
        }
    }
}