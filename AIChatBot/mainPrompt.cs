using System;
using System.Collections.Generic;

namespace AIChatBot
{//start of namespace

    internal class mainPrompt
    {//start of class

        public mainPrompt()
        {//start of constructor

            //display welcome message
            AddBotTypingEffect(
                "******************************************************************************************\n" +
                " Welcome to The Cyber Security AI \n" +
                "******************************************************************************************",
                ConsoleColor.DarkCyan
            );

            //declaring variables for user name and question
            string userName;
            string userQuestion = string.Empty;

            //declaring lists for bot responses and ignored words
            List<string> botResponses = new List<string>();
            List<string> ignoredWords = new List<string>();

            //calling methods to store responses and ignored words
            StoreBotResponses(botResponses);
            StoreIgnoredWords(ignoredWords);

            //prompting the user to enter their name
            do
            {
                AddBotTypingEffect("AI BOT - Please enter your name:", ConsoleColor.Cyan);
                Console.ForegroundColor = ConsoleColor.Yellow;
                userName = Console.ReadLine();

            } while (!ValidateUserName(userName)); //re-prompt if name is invalid

            Console.ResetColor();

            //greeting the user
            AddBotTypingEffect("AI BOT - Nice to meet you " + userName, ConsoleColor.Cyan);
            AddBotTypingEffect(
                "AI BOT - Please enter a cybersecurity question or type (exit / bye / stop) to exit.",
                ConsoleColor.Cyan
            );

            //main chatbot loop
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(userName + " - ");
                userQuestion = Console.ReadLine();

                //check if user wants to exit
                if (CheckExitCommand(userQuestion, userName))
                {
                    break;
                }
                //validate the user question
                else if (ValidateUserQuestion(userQuestion))
                {
                    //process the question and search for a response
                    ProcessQuestion(botResponses, ignoredWords, userQuestion);
                }

            } while (true); //loop runs until exit word is entered

        }//end of constructor


        //method to store bot responses
        public void StoreBotResponses(List<string> responses)
        {//start of StoreBotResponses
            //I separated the reponses based on different categories
            //core cybersecurity terms
            responses.Add("Cybersecurity. Protecting computers and networks from bad actors.");
            responses.Add("Passwords. Keep them strong and never share them.");
            responses.Add("VPN. Helps keep your internet connection private.");
            responses.Add("Firewall. Blocks unwanted access to your system.");
            responses.Add("Phishing. Tricking users into giving sensitive information.");
            responses.Add("Malware. Software designed to harm systems or steal data.");
            responses.Add("Two factor authentication. Adds an extra layer of security.");
            responses.Add("Hacking. Can be ethical or malicious.");
            responses.Add("Ransomware. Locks files and demands payment.");
            responses.Add("Encryption. Converts data into unreadable code.");
            responses.Add("Spyware. Secretly monitors user activity.");
            responses.Add("Social engineering. Manipulating people to reveal information.");
            responses.Add("DDoS attack. Overwhelming a service to make it unavailable.");
            responses.Add("Patch management. Keeping software updated.");
            responses.Add("Data breach. Unauthorized access to sensitive data.");

            //basic online safety
            responses.Add("Online safety. Protecting yourself while using the internet.");
            responses.Add("Public wifi. Avoid logging into sensitive accounts on public networks.");
            responses.Add("Scam. A trick designed to steal money or information.");
            responses.Add("Email safety. Do not open links from unknown senders.");
            responses.Add("Suspicious links. Links that may lead to fake or harmful websites.");

            //user accounts and access
            responses.Add("Login. Process of accessing an account securely.");
            responses.Add("Authentication. Verifying a user's identity.");
            responses.Add("Authorization. Deciding what a user is allowed to access.");
            responses.Add("Account security. Protecting your accounts from unauthorized access.");
            responses.Add("Brute force. Trying many passwords until the correct one is found.");

            //devices and software
            responses.Add("Antivirus. Software that detects and removes viruses.");
            responses.Add("Software update. Fixes bugs and security vulnerabilities.");
            responses.Add("Operating system. Core software that runs a device.");
            responses.Add("Backup. A copy of important data stored safely.");
            responses.Add("USB safety. Unknown USB devices may contain malware.");

            //social media and privacy
            responses.Add("Privacy. Controlling who can see your personal information.");
            responses.Add("Social media. Be careful what personal details you share online.");
            responses.Add("Location sharing. Disable it unless necessary.");
            responses.Add("Permissions. Only allow apps access they really need.");

        }//end of StoreBotResponses


        //method to store ignored words
        public void StoreIgnoredWords(List<string> ignored)
        {//start of StoreIgnoredWords

            ignored.Add("tell");
            ignored.Add("what");
            ignored.Add("is");
            ignored.Add("me");
            ignored.Add("does");
            ignored.Add("why");
            ignored.Add("how");
            ignored.Add("a");
            ignored.Add("an");
            ignored.Add("the");
            ignored.Add("do");
            ignored.Add("can");
            ignored.Add("about");
            ignored.Add("for");
            ignored.Add("of");
            ignored.Add("please");
            ignored.Add("in");
            ignored.Add("to");
            ignored.Add("work");

        }//end of StoreIgnoredWords


        //method to validate user name
        private bool ValidateUserName(string name)
        {//start of ValidateUserName

            if (string.IsNullOrWhiteSpace(name))
            {
                AddBotTypingEffect(
                    "AI BOT - Please enter a valid name. Name cannot be empty.",
                    ConsoleColor.Red
                );
                return false;
            }

            return true;

        }//end of ValidateUserName


        //method to validate user question
        private bool ValidateUserQuestion(string question)
        {//start of ValidateUserQuestion

            if (string.IsNullOrWhiteSpace(question) || question.Length < 3)
            {
                AddBotTypingEffect(
                    "AI BOT - Please enter a valid cybersecurity question.",
                    ConsoleColor.Red
                );
                return false;
            }

            return true;

        }//end of ValidateUserQuestion


        //method to process and search for matching responses
        private void ProcessQuestion(List<string> responses, List<string> ignoredWords, string question)
        {//start of ProcessQuestion

            string[] splitWords = question.ToLower().Split(' ');
            List<string> filteredWords = new List<string>();

            //filtering ignored words
            foreach (string word in splitWords)
            {
                if (!ignoredWords.Contains(word))
                {
                    filteredWords.Add(word);
                }
            }

            bool responseFound = false;

            //loop through responses
            foreach (string response in responses)
            {
                string[] parts = response.Split('.');

                if (parts.Length < 2)
                {
                    continue;
                }

                string keyword = parts[0].ToLower();
                string description = parts[1];

                foreach (string word in filteredWords)
                {
                    if (keyword.Contains(word))
                    {
                        AddBotTypingEffect("AI BOT - " + description, ConsoleColor.Cyan);
                        AddBotTypingEffect(
                            "AI BOT - Let me know if you need more help or type (exit / stop).",
                            ConsoleColor.Cyan
                        );
                        responseFound = true;
                        break;
                    }
                }

                if (responseFound)
                {
                    break;
                }
            }

            //if no response was found
            if (!responseFound)
            {
                AddBotTypingEffect(
                    "AI BOT - Sorry, I could not understand your question. Please try again.",
                    ConsoleColor.Red
                );
            }

        }//end of ProcessQuestion


        //method to check exit words
        public bool CheckExitCommand(string input, string userName)
        {//start of CheckExitCommand

            string lowerInput = input.ToLower();
            string[] exitWords = { "exit", "stop", "bye", "goodbye" };

            foreach (string word in exitWords)
            {
                if (lowerInput.Contains(word))
                {
                    AddBotTypingEffect(
                        "AI BOT - Goodbye " + userName + ". Stay safe online!",
                        ConsoleColor.Cyan
                    );
                    return true;
                }
            }

            return false;

        }//end of CheckExitCommand


        //method to create typing effect for the bot
        public void AddBotTypingEffect(string botMessage, ConsoleColor textColor, int textSpeed = 25)
        {//start of AddBotTypingEffect

            Console.ForegroundColor = textColor;

            foreach (char character in botMessage)
            {
                Console.Write(character);
                System.Threading.Thread.Sleep(textSpeed);
            }

            Console.WriteLine();
            Console.ResetColor();

        }//end of AddBotTypingEffect


    }//end of class

}//end of namespace