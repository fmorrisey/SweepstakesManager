using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void CreateSweepstakes() // Load Game
        {
            //switch case to create a queue or stack
            bool askAgain = false;

            do
            {
                string SManagerType = UI.GetUserInputFor("Select Queue or Stack");
                switch (SManagerType)
                {
                    case "stack": _manager = new SweepstakesStackManager(); askAgain = false;  break;
                    case "queue": _manager = new SweepstakesQueueManager(); askAgain = false; break;
                    default: Console.WriteLine("Invalid Input"); break;
                }
            } while (askAgain == true);
        }

        

    }
}
