using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
        public Simulation()
        {

        }
        
        public void Run()
        {
            CreateMarketingFirmWithManager();
            
            marketingFirm.CreateSweepstakes();

            marketingFirm.ManageSweepstakes();

            marketingFirm.CreateSweepstakes();

            marketingFirm.ManageSweepstakes();



        }

        /// <summary>
        /// Creates the marketing firm and sets the stack/queue type
        /// </summary>
        public void CreateMarketingFirmWithManager()
        {
            
            string SManagerType;

            bool askAgain = false;
            do
            {
                switch (SManagerType = UI.GetUserInputFor("Select Queue or Stack"))
                {
                    case "stack": 
                        marketingFirm = new MarketingFirm(new SweepstakesStackManager()); 
                        askAgain = false; break;

                    case "queue": 
                        marketingFirm = new MarketingFirm(new SweepstakesQueueManager()); 
                        askAgain = false; break;

                    default: Console.WriteLine("Invalid Input"); askAgain = true; break;
                }
            } while (askAgain == true);

        }

        /// <summary>
        /// IMPLEMENTATION FOR UI
        /// </summary>
        /// <para>RETURN LATER</para>
        /*
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
