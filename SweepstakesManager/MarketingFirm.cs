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
            Sweepstakes sweepstakes = new Sweepstakes(sweepStakesName);
            _manager.InsertSweepstakes(sweepstakes);
        }




    }
}
