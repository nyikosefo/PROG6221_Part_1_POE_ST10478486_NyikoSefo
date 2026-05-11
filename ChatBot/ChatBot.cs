using System;
using System.Threading;

namespace ChatBot
{
    public class ChatBot
    {
        private ResponseEngine engine;
        private UserProfile user;

        public ChatBot()
        {
            engine = new ResponseEngine();
        }

       
        public void StartProgram()
{
    // 1. Clear the console to create a "fresh start" feel
    Console.Clear();

    // 2. Play the audio 
    VoiceGreeting.PlayGreeting();

    // 3. SHOW THE ASCII ART HERE
    DisplayHelper.ShowHeader(); 

    // 4. Add some "system loading" flavor ;)
    DisplayHelper.PrintDivider(ConsoleColor.DarkGray);
    DisplayHelper.TypeText(">>> SYSTEM BOOT SUCCESSFUL", ConsoleColor.Cyan, 50);
    
    Console.WriteLine();
    DisplayHelper.TypeText("Press any key to enter the secure terminal...", ConsoleColor.White);
    
    
    Console.ReadKey(true);
    
    // 6. Proceed to the introduction and name prompt
    Start();
}

        public void Start()
{
    // 1. Bot introduces itself first
    DisplayHelper.ShowSpeakerLabel("BOT", ConsoleColor.Green);
    DisplayHelper.TypeText("Hello! Welcome to the CyberSecurity Assistant. I'm here to help you stay safe online.", ConsoleColor.Green);
    
    // 2. Ask for the name
    string userName = AskForName();
    user = new UserProfile(userName);

    // 3. Greet the user personally and explain how it works
    DisplayHelper.ShowSpeakerLabel("BOT", ConsoleColor.Green);
    DisplayHelper.TypeText($"It's great to meet you, {user.Name}!", ConsoleColor.Green);
    
    DisplayHelper.PrintDivider(ConsoleColor.DarkGray);
    
    // 4. Instructions
    DisplayHelper.TypeText("HOW I WORK :", ConsoleColor.Cyan, 30);
    DisplayHelper.TypeText("* You can ask me about passwords, phishing, or safe browsing.", ConsoleColor.Gray, 20);
    DisplayHelper.TypeText("* To leave this conversation at any time, just type 'exit', 'quit', or 'bye'.", ConsoleColor.White, 20);
    
    DisplayHelper.PrintDivider(ConsoleColor.DarkGray);

    RunConversationLoop();
}

private string AskForName()
{
    string name = "";
    while (true)
    {
        
        DisplayHelper.ShowSpeakerLabel("BOT", ConsoleColor.Green);
        DisplayHelper.TypeText("Before we begin, may I ask what your name is?", ConsoleColor.Green);

        Console.Write("  [ YOU ]  ");
        name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            DisplayHelper.TypeText("Please enter a name so I know who I'm talking to.", ConsoleColor.Red, 20);
        }
        else
        {
            name = name.Trim();
            name = char.ToUpper(name[0]) + name.Substring(1);
            break;
        }
    }
    return name;
}

        private void RunConversationLoop()
{
    bool isRunning = true;
    while (isRunning)
    {
        // 1. Get User Input
        Console.Write($"\n  [ {user.Name} ]  ");
        string userInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(userInput))
        {
            DisplayHelper.TypeText("I didn't get that, could you rephrase?", ConsoleColor.Red, 20);
            continue;
        }

        if (engine.IsExitCommand(userInput))
        {
            DisplayHelper.TypeText($"Goodbye, {user.Name}! Stay safe online!", ConsoleColor.Green);
            isRunning = false;
            break;
        }

        // 2. Get and Display Bot Response
        // FIX: Provide the required out parameter. Use discard if the matched topic is not needed.
        string response = engine.GetResponse(userInput, out _);
        user.QuestionsAsked++;

        if (response != null)
        {
            DisplayHelper.ShowSpeakerLabel("BOT", ConsoleColor.Green);
            DisplayHelper.TypeText(response, ConsoleColor.Green, 18);
        }
        else
        {
            DisplayHelper.ShowSpeakerLabel("BOT", ConsoleColor.DarkYellow);
            DisplayHelper.TypeText("I didn't quite understand. Try asking about passwords, phishing, or safe browsing.", ConsoleColor.DarkYellow, 20);
        }

       
        DisplayHelper.PrintDivider(ConsoleColor.DarkGray);
    }
}

    }
}