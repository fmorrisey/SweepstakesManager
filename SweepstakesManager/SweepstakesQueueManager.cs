using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweepstakesManager
{
    /// <summary>
    /// <para>QUEUE</para>
    /// Adds a SweepStakes to the stack.
    /// First-in-first-out (FIFO) collection
    /// </summary>
    public class SweepstakesQueueManager : ISweepstakesManager
    {
        private Queue<Sweepstakes> _queue;

        
        public SweepstakesQueueManager()
        {
            _queue = new Queue<Sweepstakes>();
        }

        /// <summary>
        /// Adds a new Sweepstakes to the Queue
        /// </summary>
        /// <param name="sweepstakes"></param>
        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            _queue.Enqueue(sweepstakes);
        }

        /// <summary>
        /// Allows the user to call a Sweepstakes to be managed 
        /// </summary>
        /// <returns></returns>
        public Sweepstakes GetSweepstakes() // returns a sweepstakes
        {
            return _queue.Peek();
        }

        
    }
}
