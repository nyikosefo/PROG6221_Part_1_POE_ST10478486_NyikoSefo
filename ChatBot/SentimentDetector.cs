using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    // The enum can live right inside the namespace
    public enum Sentiment
    {
        Neutral,
        Worried,
        Curious,
        Frustrated,
        Positive 
    }

    // Wrap the dictionary and methods inside the class
    public class SentimentDetector
    {
        private static readonly Dictionary<Sentiment, List<string>> sentimentKeywords
        = new Dictionary<Sentiment, List<string>>
        {
            {
                Sentiment.Worried, new List<string>
                {
                    "worried", "scared", "afraid", "nervous", "anxious",
                    "concern", "unsafe", "at risk", "stressed", "not sure"
                }
            },
            {
                Sentiment.Frustrated, new List<string>
                {
                    "frustrated", "confused", "lost", "don't understand",
                    "makes no sense", "complicated", "stuck"
                }
            },
            {
                Sentiment.Curious, new List<string>
                {
                    "curious", "interested", "wondering", "how does",
                    "tell me more", "explain", "what is", "teach me"
                }
            },
            {
                Sentiment.Positive, new List<string>
                {
                    "great", "thanks", "thank you", "helpful", "amazing"
                }
            }
        };

        public static Sentiment Detect(string input)
        {
            string lower = input.ToLower();
            foreach (var kvp in sentimentKeywords)
            {
                foreach (string keyword in kvp.Value)
                {
                    if (lower.Contains(keyword))
                        return kvp.Key; // stop as soon as we find a match
                }
            }
            return Sentiment.Neutral;
        }

        // Added the missing GetEmpathyResponse method required by the Conversation Loop
        public static string GetEmpathyResponse(Sentiment s)
        {
            switch (s)
            {
                case Sentiment.Worried:
                    return "It is completely normal to feel concerned about your digital safety. Let's walk through this together.";
                case Sentiment.Frustrated:
                    return "I know cybersecurity can feel overwhelming and confusing at times. I'll try to break it down simply.";
                case Sentiment.Curious:
                    return "It's fantastic that you want to learn more! Let's dive into the details.";
                case Sentiment.Positive:
                    return "I'm so glad I could help!";
                case Sentiment.Neutral:
                default:
                    // Return an empty string or null for Neutral so it doesn't print anything extra
                    return string.Empty;
            }
        }
    }
}