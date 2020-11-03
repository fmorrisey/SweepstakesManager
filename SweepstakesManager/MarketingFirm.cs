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

        /// <summary>
        /// Dependency injection in the method signature ensures  that either a Stack or Queue
        /// is used when the Marketing firm is created. This allows the program to be expanded
        /// to other data types or structures easily without an entire rewrite. It also the user
        /// to have a choice in how the multiple various sweepstakes will be managed.
        /// </summary>
        /// <param name="manager"></param>
        public MarketingFirm(ISweepstakesManager manager)
        {
            this._manager = manager;
        }

        /// <summary>
        /// Creates a new Sweepstakes that will added to the Stack/Queue
        /// </summary>
        public void CreateSweepstakes()
        {
            string sweepStakesName = UI.CreateName("Name Your Sweepstakes!");
            sweepstakes = new Sweepstakes(sweepStakesName);
            _manager.InsertSweepstakes(sweepstakes);
        }


        public void ManageSweepstakes()
        {
            Contestant selectedContestant;

            // Dumps a bunch of contestants into the sweepstakes for testing
            int poolSize = 100000;
            for (int i = 0; i < poolSize; i++)
            {
                sweepstakes.RegistraterContestant(sweepstakes.CreateNewContestant());
            }

            // Picks a winning contestant
            selectedContestant = sweepstakes.PickWinner();
            sweepstakes.PrintContestantInfo(selectedContestant);

            // Sends an email to the winning contestant
            sweepstakes.SendEmail(selectedContestant);


        }


    }
}
