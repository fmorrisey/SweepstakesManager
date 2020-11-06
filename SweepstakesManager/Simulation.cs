using System;

namespace SweepstakesManager
{
    /// <summary>
    /// <para>SIMULATION</para>
    /// Initializes the marketing firm software
    /// Sweepstakes Management System
    /// </summary>
    public class Simulation
    {
        MarketingFirm marketingFirm;

        public void Run()
        {
            ISweepstakesManager manager= CreateMarketingFirmWithManager();   // Creates a Stack or Queue
            
            MarketingFirm marketingFirm = new MarketingFirm(manager);

            marketingFirm.CreateSweepstakes();  // Creates the individual contest

            marketingFirm.ManageSweepstakes();  // Manage the contest / sweepstakes

            Console.ReadLine();
        }

        /// <summary>
        /// Creates the marketing firm and sets the stack/queue type
        /// taking advantage of dependency injection and the factory design pattern
        /// </summary>

        /* This uses dependency injection of the ISweepstakes interface
         * in conjunction with a Factory Design Pattern allowing for
         * future possibility to extend functionality for other data management
         * implementations such as Lists or other data structures. */

        public ISweepstakesManager CreateMarketingFirmWithManager()
        {

            string SManagerType;

            bool askAgain = false;
            do
            {
                switch (SManagerType = UI.GetUserInputFor("Select Queue or Stack"))
                {
                    case "stack":
                        return new SweepstakesStackManager();
                        

                    case "queue":
                        return new SweepstakesQueueManager();
                        
                    /* ------------------------------------------------------------------------
                     * Because of DI and the Factory Design Pattern, adding additional functionally is as easy 
                     * as adding another case statement and a new class that interfaces with ISweepstakesManager.
                     * 
                     * case "Heap":
                            marketingFirm = new MarketingFirm(new Sweepstakes_Heap_Manager());
                            askAgain = false; break;
                    * ------------------------------------------------------------------------ */

                    default: Console.WriteLine("Invalid Input"); askAgain = true; break;
                }

            } while (askAgain == true);
            return CreateMarketingFirmWithManager();
        }



        /// <summary>
        /// IMPLEMENTATION FOR UI
        /// </summary>
        /// <para>RETURN LATER</para>
        /* This is for future implementation of UI for the marketing firm user

        public void LogicMainMenu()
        {
            UI.DisplayMainMenu();
            int options = UI.IntInputValidation("Pick a selection");

            switch (options)
            {
                case 1: ISweepstakesManager(marketingFirm)
                case 2: ; break;
                default: break;
            }
        }
        */
    }
}
