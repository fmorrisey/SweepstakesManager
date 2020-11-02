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
        private int _counter;
        
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
            _counter = 0;
            _RegistrationID = new List<int>(_counter);
            
        }

        public void RegistraterContestant(Contestant contestant)
        {
            int regID = contestant.RegistrationNumber;
            _contestants.Add(regID, contestant);
        }

        public Contestant CreateNewContestant()
        {
            int regid = GenerateUniqueID();
            /*
            string fName = UI.CreateName("Enter First Name");
            string lName = UI.CreateName("Enter Last Name");
            string email = UI.CreateEmail("Please enter a valid email");
            Console.WriteLine($"Auto geneated RegID Number is {regid}");
            */

            Contestant contestant = new Contestant("Timmy", "Test", "TheBestTestIn@TheWest.biz", regid);
            //Contestant contestant = new Contestant(fName, lName, email, regid);
            return contestant;
        }

        public Contestant PickWinner()
        {
            return _contestants[GenerateRandomInt(_contestants.Count())]; // return contestant
        }

        public void PrintContestantInfo(Contestant contestant)
        {
            Console.WriteLine($"Name:  {contestant.FirstName} {contestant.LastName}");
            Console.WriteLine($"Email: {contestant.EmailAddress}");
            Console.WriteLine($"RegID: {contestant.RegistrationNumber} \n");
        }

        private int GenerateUniqueID()
        {
            _counter++;
            _RegistrationID.Add(_counter);
            return _counter;
        }

        private int GenerateRandomInt(int contestantNumber)
        {   // Generates a random number
            Random Random;
            Random = new Random(Guid.NewGuid().GetHashCode());
            int hash = 0;
            return hash = Random.Next(contestantNumber - 1);
        }

    }
}
