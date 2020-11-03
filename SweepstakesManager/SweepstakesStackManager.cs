using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweepstakesManager
{
    /// <summary>
    /// <para>STACK</para>
    /// Adds a SweepStakes to the stack.
    /// Last-in-first-out (LIFO) collection
    /// </summary>
    /// <param name="sweepstakes"></param>
    public class SweepstakesStackManager : ISweepstakesManager
    {
        
        private Stack<Sweepstakes> _stack;

        public SweepstakesStackManager()
        {
            _stack = new Stack<Sweepstakes>();
        }

        /// <summary>
        /// Adds a new Sweepstakes to the Stack
        /// </summary>
        /// <param name="sweepstakes"></param>
        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            _stack.Push(sweepstakes);
        }

        /// <summary>
        /// Allows the user to call a Sweepstakes to be managed 
        /// </summary>
        /// <returns></returns>
        public Sweepstakes GetSweepstakes()
        {
            return _stack.Peek();
            
        }
    }
}
