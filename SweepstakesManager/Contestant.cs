namespace SweepstakesManager
{
    /// <summary>
    /// <para>Contestant</para>
    /// The object model of each contestant in their respective sweepstakes
    /// </summary>
    public class Contestant
    {
        public string FirstName;
        public string LastName;
        public string EmailAddress;
        public int RegistrationNumber;

        public Contestant(string firstName, string lastName, string emailAddress, int registrationNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailAddress = emailAddress;
            this.RegistrationNumber = registrationNumber;
        }


    }
}
