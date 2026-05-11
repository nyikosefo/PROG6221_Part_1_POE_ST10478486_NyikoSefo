using System;
using System.Collections.Generic;

namespace ChatBot
{
    public class ResponseEngine
    {
        // 1. Declare the missing fields so the method can see them
        private Dictionary<string, string> responses;
        private Dictionary<string, List<string>> randomResponses;
        private Random random = new Random();

        public ResponseEngine()
        {
            // Initialize your existing single-response dictionary
            responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "how are you", "I'm running smoothly! All my defensive protocols are online." },
                { "tell me about cybersecurity", "Cybersecurity is the practice of protecting systems from digital attacks." },
                { "password", "Strong passwords are your first line of defence. Use 12+ characters!" },
                { "phishing", "Phishing is when criminals trick you via email. Never click unexpected links!" },
                // ... (your other existing responses)
            };

            // 2. Initialize the randomResponses dictionary
            // This fixes the error where the loop couldn't find "randomResponses"
            randomResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
            {
                { "hello", new List<string> { "Hi there!", "Hello! How can I help?", "Greetings, user." } },
                { "hey", new List<string> { "Hey! Ready to talk security?", "Hello!" } }
            };
        }

        // 3. Add '?' to string and out string to allow NULL returns
        public string? GetResponse(string userInput, out string? matchedTopic)
        {
            matchedTopic = null; // This is now okay because of the '?'

            // Check random responses first
            foreach (var entry in randomResponses)
            {
                if (userInput.IndexOf(entry.Key, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    matchedTopic = entry.Key;
                    int index = random.Next(0, entry.Value.Count);
                    return entry.Value[index];
                }
            }

            // Fall back to single responses
            foreach (var entry in responses)
            {
                if (userInput.IndexOf(entry.Key, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    matchedTopic = entry.Key;
                    return entry.Value;
                }
            }

            return null; // This is now okay because of the '?'
        }
        public bool IsExitCommand(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;

            string lower = input.ToLower().Trim();
            return lower == "exit" || lower == "quit" || lower == "bye";
        } 
    }
}