﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        {
            string userInput;

            Console.WriteLine(prompt);      // Prompt is passed and printed
            userInput = Console.ReadLine(); // Get input
            userInput = userInput.Trim();   // Format
            userInput = userInput.ToLower();// Format

            return userInput;

        }

        public static string CreateName(string prompt)
        {
            string userInput;

            Console.WriteLine(prompt);      // Prompt is passed and printed
            userInput = Console.ReadLine(); // Get input

            return userInput;

        }

        public static int IntInputValidation(string message)
        {   // Handles Main Menu user input with validation
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

        public static double DoubleInputValidation()
        {
            // Handles Main Menu user input with validation
            bool askAgain;
            double UserInput;

            do
            {
                Console.Write("Enter a dollar amount: ");
                if (double.TryParse(Console.ReadLine(), out UserInput))
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
        {   //DRAWS AI SPECIFIC MENU FOR THE COMPUTER AI
            Console.WriteLine("###### WELCOME TO ###### \n" +
                              "##### Marketing Firm ##### \n" +
                              "  [1] Register contestant\n" +
                              "  [2] Create Sweepstakes\n" +
                              "  [3] \n\n" +
                              "  [4] \n\n" + 
                              "    \n" +
                              "  [5] Exit \n");
            MenuDecorators("hashlong");
            

        }

        

        public static void DisplayRegisterContestant()
        {   //DRAWS MENU SODA SELECTION
            Console.WriteLine($"######## SODA MACHINE ######## \n" +
                              "Pick you favorite beverage \n" +
                             $"  [1] Root Beer | $0.60 \n" +
                             $"  [2] Orange Soda |$0.06 \n" +
                             $"  [3] Cola | $0.35 \n\n");
            MenuDecorators("hashlong");

        }

        public static void ExitMessageDraw()
        {
            Console.WriteLine("Created by: Forrest Morrisey // Oct 2020");
            Console.WriteLine("Thank you for supporting your local dentist!!!");
            Console.WriteLine("Winners drink water");
            Console.WriteLine("FBI ANTI-PIRACY WARNING");
            WaitForKey("", 1000);
        }

        /////////////// UI UTLILTIES ///////////////
        public static void WaitForKey(string message, int waitTime)
        {
            //Basically a CR with text output so the user knows what it's asking for
            Console.WriteLine(message);
            Thread.Sleep(waitTime);// Waits for player to read team info
            Console.ReadLine();
        }

        public static void Pause(string message, int waitTime)
        {
            //Basically a CR with text output so the user knows what it's asking for
            Console.WriteLine(message);
            Thread.Sleep(waitTime);// Waits for player to read team info
            //Great for Pseudo Loadscreens
        }

        public static void Clear()
        {
            //Clears the menu
            Console.Clear();
        }

        public static void BlinkerTrip(string text, int blinkNum, int milliseconds)
        {
            //COPIED AND MODIFIED FROM STACKOVERFLOW https://stackoverflow.com/questions/4755204/adding-line-break
            //Takes in custom text, repeats three times, blinks as much as you like, and at a set interval

            bool visible = true;
            for (int i = 0; i < blinkNum; i++)
            {
                string alert = visible ? ($"{text} {text} {text}") : "";
                visible = !visible;
                Console.Clear();
                Console.Write("{0}\n", alert);
                Thread.Sleep(milliseconds);
            }
        }


        public static void BlinkerSingle(string text, int blinkNum, int milliseconds)
        {
            //COPIED AND MODIFIED FROM STACKOVERFLOW https://stackoverflow.com/questions/4755204/adding-line-break
            //Takes in custom text, repeats three times, blinks as much as you like, and at a set interval

            bool visible = true;
            for (int i = 0; i < blinkNum; i++)
            {
                string alert = visible ? ($"{text}") : "";
                visible = !visible;
                Console.Clear();
                Console.WriteLine();
                Console.Write("{0}\n", alert);
                Thread.Sleep(milliseconds);
            }
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
                default: Console.WriteLine("/In/Valid//Menu//Decorator/"); break;

            }
        }




    }
}
