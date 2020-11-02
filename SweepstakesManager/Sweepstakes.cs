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
        private List<int> _RegistrationID;
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Sweepstakes(string name)
        {
            this._name = name;
            _contestants = new Dictionary<int, Contestant>();
            _RegistrationID = new List<int>();
        }

        public void RegistraterContestant(Contestant contestant)
        {
            // Make sure to use a unique ID for each
            // Create a unique ID LIST
            int regID = GenerateUniqueID();
            // Create Contestant OBJS
            //USER INPUT HERE // CALL UI
            contestant = new Contestant("Timmy", "Test", "TheBestTestIn@TheWest.biz",regID);
            // Add to Dictionary
            _contestants.Add(regID, contestant);

        }

        public int GenerateUniqueID()
        {
            for (int i = 0; i < _RegistrationID.Count; i++)
            {
                if (_RegistrationID.Contains(_RegistrationID[i]) == false) //Does not contain
                {
                    _RegistrationID.Add(_RegistrationID[i]);    // add new Id
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
