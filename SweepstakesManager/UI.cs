using System;

namespace SweepstakesManager
{
    /// <summary>
    /// <para>User Interface Objects</para>
    /// Static class to handle user input and displaying information
    /// </summary>
    public static class UI
    {
        /////////////// INPUT VALIDATION ///////////////
        public static string GetUserInputFor(string prompt)
        {   // User input validation for a menu options with a string return
            string userInput;
            bool askAgain;

            do
            {
                Console.WriteLine(prompt);      // Prompt is passed and printed
                userInput = Console.ReadLine(); // Get input
                if (userInput.Contains(""))
                {
                    Console.WriteLine("Nothing was entered");
                    askAgain = true;
                }
                else
                {
                    userInput = userInput.Trim();   // Format
                    userInput = userInput.ToLower();// Format

                    return userInput;
                }

            } while (askAgain == true);
            return userInput;

        }

        public static string CreateName(string prompt)
        {   // User input validation for creating a name string
            string userInput;
            bool askAgain;

            do
            {
                Console.WriteLine(prompt);      // Prompt is passed and printed
                userInput = Console.ReadLine(); // Get input
                if (userInput.Contains(""))
                {
                    Console.WriteLine("Nothing was entered");
                    askAgain = true;
                }
                else
                {
                    userInput = userInput.Trim();   // Format
                    return userInput;
                }

            } while (askAgain == true);
            return userInput;
        }

        public static string CreateEmail(string prompt)
        {   // Handles user input validation for emails
            // Will not return email address unless it contains an @ and a period

            string userInput;
            bool askAgain;

            Console.WriteLine(prompt);      // Prompt is passed and printed
            do
            {
                userInput = Console.ReadLine(); // Get input
                if (userInput.Contains("@") && userInput.Contains("."))
                {
                    return userInput;
                }
                else if (userInput.Contains(""))
                {
                    Console.WriteLine("You did not enter anything");
                    askAgain = true;
                }
                else
                {
                    Console.WriteLine("Not a valid email!");
                    askAgain = true;
                }

            } while (askAgain == true);

            return userInput;

        }


        public static int IntInputValidation(string message)
        {   // Handles user input with validation for integers
            bool askAgain;
            int UserInput;

            do
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out UserInput))
                { return UserInput; }
                else
                {
                    Console.WriteLine("Incorrect Input");
                    askAgain = true;
                }
            } while (askAgain == true);

            return UserInput;

        }

        /////////////// UI DISPLAY / DRAW ///////////////
        public static void DisplayMainMenu()
        {   //DRAWS A MENU FOR THE MAIN MENU
            Console.WriteLine("############## WELCOME TO ############ \n" +
                              "##### Sweepstakes Marketing Firm ##### \n" +
                              "  [1] Create New Sweepstakes\n" +
                              "  [2] Select Existing SweepStakes\n" +
                              "  [3] Exit\n\n" +
                              "  [4] \n\n" +
                              "    \n" +
                              "  [5] Exit \n");
            MenuDecorators("hashlong");

        }

        public static void DisplayContestantManager()
        {   //DRAWS A MENU TO MANAGE CONTESTANTS
            Console.WriteLine("######### Sweepstakes ######## \n" +
                              "##### Contestant Manager ##### \n" +
                              "  [1] Find contestant\n" +
                              "  [2] Register contestant\n" +
                              "  [3] Pick a sweepstakes winner\n\n" +
                              "  [4] Winning Contestants\n\n" +
                              "    \n" +
                              "  [5] Exit \n");
            MenuDecorators("hashlong");

        }

        /////////////// MENU EXTRAS ///////////////
        public static void MenuDecorators(string Decoration)
        { // call using the options to decorate the menues!
            string parameterconvert = Decoration.ToLower();
            switch (parameterconvert)
            {
                case "star": Console.WriteLine("***************"); break;
                case "starlong": Console.WriteLine("*****************************************"); break;
                case "dash": Console.WriteLine("---------------"); break;
                case "plus": Console.WriteLine("+++++++++++++++"); break;
                case "equal": Console.WriteLine("==============="); break;
                case "slashrt": Console.WriteLine("////////////////////////////////"); break;
                case "slashlf": Console.WriteLine("////////////////////////////////"); break;
                case "pipe": Console.WriteLine("|||||||||||||||||||"); break;
                case "hash": Console.WriteLine("###################"); break;
                case "hashlong": Console.WriteLine("########################"); break;
                case "div": Console.Write(" || "); break;
                default: Console.WriteLine("//Invalid//Menu//Decorator//"); break;

            }
        }
    }
}
