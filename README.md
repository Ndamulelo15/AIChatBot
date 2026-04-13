# AIChatBot
Welcome to the AI Cyber Security ChatBot! This bot is designed to help users learn and engage with topics related to cybersecurity. It provides relevant responses to user queries in real-time and educates users about various cybersecurity topics like malware, encryption, phishing, and more.

Features
User Interaction: The bot interacts with the user in real-time, providing responses based on the user's questions about cybersecurity.
Typing Effect: The bot has a simulated typing effect, making the interaction more engaging and lifelike.
Image Display: The bot displays a logo image in an ASCII art format.
Voice: The bot can play a voice message when required.
Exit Command: Users can type "exit", "stop", "bye", or "goodbye" to end the conversation.


How It Works

Main Functionality

Greeting: Upon launch, the bot greets the user and asks for their name.
User Input: The bot accepts questions related to cybersecurity. It filters out irrelevant words and looks for keywords in the question to match appropriate responses.
Bot Response: The bot will provide information on topics like firewalls, passwords, VPNs, phishing, malware, and other cybersecurity concepts.
Exit Command: The user can exit the conversation by typing exit words such as "exit", "stop", "bye", or "goodbye".
Interactive Feedback: The bot provides helpful responses and engages in a friendly manner.


Methods and Components
mainPrompt Class:
Displays a welcome message and interacts with the user.
Validates user input (name and question).
Searches for matching responses to user questions about cybersecurity.

Handles exit commands.
logo_image Class:
Loads and resizes the logo image (cyberLogo.jpg).
Converts the image into ASCII characters and displays it on the console.
voice Class:
Plays an audio file (AIVoice.wav) to enhance the interaction.


Supporting Methods:
AddBotTypingEffect: Simulates typing effect for the bot's responses.
StoreBotResponses: Stores predefined cybersecurity responses.
StoreIgnoredWords: Stores a list of common words that should be ignored during query processing.
ProcessQuestion: Filters the user’s input and matches keywords to bot responses.
ValidateUserName: Ensures that the user enters a valid name.
ValidateUserQuestion: Ensures the user enters a valid question.


How to Use
Run the Program:
Start the bot by running the application in your IDE.
The bot will greet you and ask for your name.
Ask Cybersecurity Questions:
Type your questions about cybersecurity and the bot will respond based on predefined responses.
Exit:
Type "exit", "stop", "bye", or "goodbye" to end the conversation.

Image 1:
This is the welcoming Message from the bot.
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/2e9d4843-1719-4572-bba3-1a0e3c5512c9" />

Image 2:
This IMage shows the response between the user and the bot.
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/44d982d8-76ff-415d-96f7-b2200e0a3620" />

