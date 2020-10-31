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
        private List<int> _uniqueID;
        private string _name;
        public string Name;

        public Sweepstakes(string name)
        {
            this._name = name;
            _contestants = new Dictionary<int, Contestant>();
            _uniqueID = new List<int>();
        }

        public void RegistraterContestant(Contestant contestant)
        {
            // Make sure to use a unique ID for each
            // Create a unique ID LIST
            int uniqueID = GenerateUniqueID();
            // Create Contestant OBJS
            //USER INPUT HERE // CALL UI
            contestant = new Contestant("Timmy", "Test", "TheBestTestIn@TheWest.biz",uniqueID);
            // Add to Dictionary
            _contestants.Add(uniqueID, contestant);

        }

        public int GenerateUniqueID()
        {
            for (int i = 0; i < _uniqueID.Count; i++)
            {
                if (_uniqueID.Contains(_uniqueID[i]) == false) //Does not contain
                {
                    _uniqueID.Add(_uniqueID[i]);    // add new Id
                    return i;                       // return that int
                }
            }
            return default;
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
