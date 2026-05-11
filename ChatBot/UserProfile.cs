namespace ChatBot
{
    public class UserProfile
    {
        public string Name { get; set; }
        public int QuestionsAsked { get; set; }
        public string FavouriteTopic { get; set; }

        // MemoryStore is now part of the user profile
        public MemoryStore Memory { get; private set; }

        public UserProfile(string name)
        {
            Name = name;
            QuestionsAsked = 0;
            FavouriteTopic = null;
            Memory = new MemoryStore(); 
            Memory.Store("name", name);
        }

        public string GetPersonalisedGreeting()
        {
            return $"It's great to meet you, {Name}! " +
                   $"I'm glad you're taking cybersecurity seriously.";
        }
    }
}