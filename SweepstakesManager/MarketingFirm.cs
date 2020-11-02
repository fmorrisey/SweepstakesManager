using System;

namespace SweepstakesManager
{
    /// <summary>
    /// <para>Marketing Firm</para>
    /// Creates and manages the Sweepstakes
    /// </summary>
    public class MarketingFirm
    {
        private ISweepstakesManager _manager;
        Sweepstakes sweepstakes;

        public MarketingFirm(ISweepstakesManager manager)
        {
            this._manager = manager;

        }

        /// <summary>
        /// Switch case to create a queue or stack manager
        /// </summary>
        public void CreateSweepstakes() // Load Game
        {
            string sweepStakesName = UI.CreateName("Create a name!");
            sweepstakes = new Sweepstakes(sweepStakesName);
            _manager.InsertSweepstakes(sweepstakes);
        }

        public void ManageSweepstakes() //Testing AREA
        {
            Contestant selectedContestant;
            // Dumps a bunch of contestant into the sweepstakes for testing
            int poolSize = 100000;
            for (int i = 0; i < poolSize; i++)
            {
                sweepstakes.RegistraterContestant(sweepstakes.CreateNewContestant());
            }

            for (int i = 0; i < 3; i++)
            {
                selectedContestant = sweepstakes.PickWinner();
                sweepstakes.PrintContestantInfo(selectedContestant);
            }
            

            
        }


    }
}
