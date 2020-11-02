using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweepstakesManager
{
    /// <summary>
    /// <para>MAIN RUN-TIME PROGRAM</para>
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            Simulation simulation = new Simulation();
            simulation.CreateMarketingFirmWithManager();
        }
    }
}
