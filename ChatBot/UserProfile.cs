namespace ChatBot
{
    public class UserProfile
    {
        // Automatic properties - C# creates the backing field for us
        public string Name { get; set; }
        public int QuestionsAsked { get; set; }

        public UserProfile(string name)
        {
            Name = name;
            QuestionsAsked = 0;
        }

        public string GetPersonalisedGreeting()
        {
            return $"Welcome, {Name}! Glad you're taking cybersecurity seriously.";
        }
    }
}
