using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweepstakesManager
{
    /// <summary>
    /// <para>QUEUE</para>
    /// </summary>
    public class SweepstakesQueueManager : ISweepstakesManager
    {
        private Queue<Sweepstakes> _queue;

        /// <summary>
        /// Adds a SweepStakes to the queue.
        /// </summary>
        /// <param name="sweepstakes"></param>
        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            _queue.Enqueue(sweepstakes);
        }

        public Sweepstakes GetSweepstakes() // returns a sweepstakes
        {
            //_queue.Dequeue(null);
            return null;
        }

        
    }
}
