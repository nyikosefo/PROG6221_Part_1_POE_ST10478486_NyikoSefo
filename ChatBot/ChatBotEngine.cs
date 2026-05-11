using System;
using System.Collections.Generic;

namespace ChatBot
{
    public enum ConversationState
    {
        WaitingForName, // <-- ADD THIS
        Active,
        Exiting
    }
    // This class contains all the bot logic, fully separated from the GUI.
    public class ChatBotEngine
    {
        // 1. Core components for the engine
        private ResponseEngine responseEngine;
        private MemoryStore memory;
        private string lastTopic = null;

        // 2. Public properties the GUI can access/set
        public string UserName { get; set; } = "User";
        public ConversationState State { get; set; } = ConversationState.Active;

        // 3. Constructor to initialize the components
        public ChatBotEngine()
        {
            responseEngine = new ResponseEngine();
            memory = new MemoryStore();
        }


        // ProcessInput() — the generic collection in action
        public List<ChatMessage> ProcessInput(string userInput)
        {
            List<ChatMessage> responses = new List<ChatMessage>();

            // FIX 3: Capture the name if the bot is in the WaitingForName state
            if (State == ConversationState.WaitingForName)
            {
                string name = userInput.Trim();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    // Capitalize the first letter
                    UserName = char.ToUpper(name[0]) + (name.Length > 1 ? name.Substring(1) : "");
                }

                State = ConversationState.Active; // Switch back to normal chat mode

                responses.Add(ChatMessage.Bot($"It's great to meet you, {UserName}!"));
                responses.Add(ChatMessage.Bot("HOW I WORK:\n* Ask me about passwords, phishing, or safe browsing.\n* Type 'exit' to leave."));
                return responses;
            }

            // Step 1: Exit check
            if (responseEngine.IsExitCommand(userInput))
            {
                responses.Add(ChatMessage.Bot($"Goodbye, {UserName}!"));
                State = ConversationState.Exiting;
                return responses;
            }

            // Step 2: Memory
            string memMsg = memory.TryRemember(userInput);
            if (memMsg != null)
                responses.Add(ChatMessage.Memory(memMsg));

            // Step 3: Sentiment
            Sentiment s = SentimentDetector.Detect(userInput);
            string empathy = SentimentDetector.GetEmpathyResponse(s);
            if (!string.IsNullOrEmpty(empathy))
                responses.Add(ChatMessage.Empathy(empathy));

            // Step 4: Follow-up
            if (IsFollowUp(userInput) && lastTopic != null)
            {
                string fu = responseEngine.GetResponse(lastTopic, out _);
                responses.Add(ChatMessage.Bot($"More on {lastTopic}:\n{fu}"));
                return responses;
            }

            // Step 5: Keyword match
            string response = responseEngine.GetResponse(userInput, out string topic);
            if (response != null)
            {
                lastTopic = topic;
                responses.Add(ChatMessage.Bot(response));
                string cb = memory.GetTopicCallback(topic);
                if (cb != null) responses.Add(ChatMessage.Memory(cb));
            }
            else
            {
                responses.Add(ChatMessage.Warning(
                    "I'm not sure I understand. Type 'list' for topics."));
            }

            return responses;
        }

        // Helper method required for Step 4
        private bool IsFollowUp(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;

            string lower = input.ToLower().Trim();
            return lower.Contains("tell me more") ||
                   lower.Contains("more about that") ||
                   lower.Contains("elaborate") ||
                   lower.Contains("explain more") ||
                   lower.Contains("what else");
        }
    }
}