using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SweepstakesManager
{
    public class Sweepstakes
    {
        /// <summary>
        /// <para>Sweepstakes</para>
        /// 
        /// </summary>
        private Dictionary<int, Contestant> _contestants;
        private string _name;
        public string Name;

        public Sweepstakes(string name)
        {
            this._name = name;
            _contestants = new Dictionary<int, Contestant>();
        }

        public void RegistraterContestant(Contestant contestant)
        {
            // Make sure to use a unique ID for each
            int value = 0; // UNiQUEID LIST
            // Create Contestant OBJS
            //USER INPUT HERE // CALL UI
            contestant = new Contestant("", "", "@", 0001);
            // Add to Dictionary
            _contestants.Add(value, contestant);

        }

        public Contestant PickWinner()
        {
            //RandCall
            return null; // return contestant
        }

        public void PrintContestantInfo(Contestant contestant)
        {
            Console.WriteLine(contestant);
        }

    }
}
