using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    // Wrap everything inside the class
    public class MemoryStore
    {
        // Dictionary stores key-value pairs like:
        // { "favourite_topic" : "phishing" }
        private Dictionary<string, string> memory;

        // 1. ADDED: Define the missing arrays so the loops have something to search through
        private string[] interestTriggers = {
            "interested in", "worried about", "want to learn",
            "tell me about", "curious about"
        };

        private string[] knownTopics = {
            "phishing", "password", "safe browsing", "2fa",
            "malware", "vpn", "encryption", "firewall", "ransomware" 
        };

        // 2. ADDED: Constructor to initialize the dictionary
        public MemoryStore()
        {
            memory = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }

        public string TryRemember(string userInput)
        {
            string lower = userInput.ToLower();

            foreach (string trigger in interestTriggers)
            {
                if (lower.Contains(trigger))
                {
                    foreach (string topic in knownTopics)
                    {
                        if (lower.Contains(topic))
                        {
                            // Save it to memory
                            memory["favourite_topic"] = topic;
                            return $"Great! I'll remember you're interested in {topic}.";
                        }
                    }
                }
            }
            return null; // nothing was stored
        }
        public void Store(string key, string value)
        {
            // This allows outside classes to save data into the private dictionary
            memory[key] = value;
        }

        public string GetTopicCallback(string currentTopic)
        {
            if (memory.ContainsKey("favourite_topic"))
            {
                string storedTopic = memory["favourite_topic"];

                if (currentTopic.IndexOf(storedTopic, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return $"(As someone interested in {storedTopic}, " +
                           $"you might want to review the security settings " +
                           $"on your accounts.)";
                }
            }
            return null;
        }
    }
}