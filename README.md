C# Interactive ChatBot Assignment
Description
This is a console-based chatbot I built for my computer science assignment. The goal was to create a program that handles user input safely, uses external files like audio, and organizes data using classes and properties. I focused on making the code "crash-proof" and giving the terminal a bit of personality with custom visuals.

Demo
https://youtu.be/vuAyLHaciBg

System Setup (Beginner Friendly)
To get this running on your own computer, follow these steps:

Install .NET: You’ll need the .NET SDK installed. You can find it on the official Microsoft website.

Download the Code: Download this repository as a ZIP file and extract it, or use git clone if you have Git installed.

The Audio File: Make sure greeting.wav is in the same folder as the project files, otherwise the bot will skip the audio intro.

Run the Bot: * Open your terminal or Command Prompt.

Navigate to the project folder.

Type dotnet run and hit Enter.

Usage Instructions
You can copy and paste these inputs to see how the bot handles different situations:

Testing the Name Logic:

Try entering nothing and just hitting Enter.

Try typing just spaces:        

The bot should keep asking until you give it a real name.

Testing Capitalisation:

Type your name in lowercase, like: sbu

The bot should output: "Hello Sbu!"

Project Details
Current Functionalities
Plays a startup sound using SoundPlayer.

Displays a custom ASCII art header.

Validates user input so the program doesn't break on empty strings.

Stores user data in a dedicated UserProfile class.

Stage & Future Plans
Current Stage: Completed assignment version.

Future Plans: I’d like to add a feature where it remembers users between sessions by saving their data to a text file or a small database.

References & AI Chat
AI Assistance: Gemini & Claude for debugging

Code References: * String.IsNullOrWhiteSpace Method.

Microsoft Docs: SoundPlayer Class for audio playback.

Stack Overflow: https://stackoverflow.com/questions/35117195/how-to-play-wav-file-from-properties-resources-using-c-sharp
