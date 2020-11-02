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

        
        public SweepstakesQueueManager()
        {
            _queue = new Queue<Sweepstakes>();
        }
        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            _queue.Enqueue(sweepstakes);
        }

        public Sweepstakes GetSweepstakes() // returns a sweepstakes
        {
            return _queue.Peek();
        }

        
    }
}
