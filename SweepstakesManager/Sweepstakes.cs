using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Util;
using Google.Apis.Util.Store;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SweepstakesManager
{
    public class Sweepstakes
    {
        /// <summary>
        /// <para>Sweepstakes Test</para>
        /// <li>test</li>
        /// <ui>test</ui>
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

        /// <summary>
        /// After contestant is created, they registered into the system
        /// The RegID for the contestant becomes their Dictionary Key
        /// </summary>
        /// <param name="contestant"></param>
        public void RegistraterContestant(Contestant contestant)
        {
            int regID = contestant.RegistrationNumber;
            _contestants.Add(regID, contestant);
        }

        /// <summary>
        /// Manually enter the contestant information
        /// </summary>
        /// <returns>A contestant object with information</returns>
        public Contestant ManuallyCreateNewContestant()
        {
            int regid = GenerateUniqueID();

            string fName = UI.CreateName("Enter First Name");
            string lName = UI.CreateName("Enter Last Name");
            string email = UI.CreateEmail("Please enter a valid email");
            Console.WriteLine($"Auto generated RegID Number is {regid}");

            Contestant contestant = new Contestant(fName, lName, email, regid);
            return contestant;
        }

        /// <summary>
        /// Auto creates the contestant for testing purposes.
        /// </summary>
        /// <returns> </returns>
        public Contestant CreateNewContestant()
        {
            int regid = GenerateUniqueID();

            Contestant contestant = new Contestant("Timmy", "Test", "wakihe4437@50000z.com", regid);

            return contestant;
        }

        /// <summary>
        /// Picks a winning contestant based on their RegID chosen at random.
        /// </summary>
        /// <returns>The winning contestant object</returns>
        public Contestant PickWinner()
        {
            return _contestants[GenerateRandomInt(_contestants.Count())]; // return contestant
        }

        /// <summary>
        /// Passes off to the EmailContestantAsync
        /// </summary>
        /// <param name="contestant"></param>
        /// <returns></returns>
        public async Task SendEmail(Contestant contestant)
        {
            await EmailContestantAsync(contestant);
        }

        /// <summary>
        /// Utilizes MailKit and Google APIs to send an email the winning contestant
        /// </summary>
        /// <param name="sc">SelectedContestant</param>
        /// <returns></returns>
        private async Task EmailContestantAsync(Contestant sc)
        {
            const string GMailAccount = "throwmeawaybreakingben@gmail.com";

            var clientSecrets = new ClientSecrets
            {
                ClientId = "oAUTH2 Numbers",
                ClientSecret = "NOPE SEKERTS"
            };

            var codeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                DataStore = new FileDataStore("CredentialCacheFolder", false),
                Scopes = new[] { "https://mail.google.com/" },
                ClientSecrets = clientSecrets
            });

            // Note: For a web app, you'll want to use AuthorizationCodeWebApp instead.
            var codeReceiver = new LocalServerCodeReceiver();
            var authCode = new AuthorizationCodeInstalledApp(codeFlow, codeReceiver);

            var credential = await authCode.AuthorizeAsync(GMailAccount, CancellationToken.None);

            if (credential.Token.IsExpired(SystemClock.Default))
                await credential.RefreshTokenAsync(CancellationToken.None);

            var oauth2 = new SaslMechanismOAuth2(credential.UserId, credential.Token.AccessToken);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("BEN BREAKING", "throwmeawaybreakingben@gmail.com"));
            message.To.Add(new MailboxAddress($"{sc.FirstName} {sc.LastName}", "wakihe4437@50000z.com"));
            message.Subject = "WINNNNERERRRR";

            message.Body = new TextPart("plain")
            {
                Text = $"Congratulations {sc.FirstName} {sc.LastName} \n" +
                        $" You have won the {_name} Sweepstakes! \n" +
                        $"Just kidding it's your son and he sent you this email from his C# .Net application. \n" +
                        $"Love ya lots and thank you for sending me to coding to school.\n" +
                        $"Forrest!"
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587);

                // use the OAuth2.0 access token obtained above

                client.Authenticate(oauth2);

                client.Send(message);
                client.Disconnect(true);
            }
        }


        /// <summary>
        /// Prints the contestant's information to the console
        /// </summary>
        /// <param name="contestant"></param>
        public void PrintContestantInfo(Contestant contestant)
        {
            Console.WriteLine($"Name:  {contestant.FirstName} {contestant.LastName}");
            Console.WriteLine($"Email: {contestant.EmailAddress}");
            Console.WriteLine($"RegID: {contestant.RegistrationNumber} \n");
        }

        /// <summary>
        /// Creates a new RegID
        /// </summary>
        /// <returns></returns>
        private int GenerateUniqueID()
        {
            _counter++;
            _RegistrationID.Add(_counter);
            return _counter;
        }

        /// <summary>
        /// Uses GUID Hash to generate a random number based on the number of contestants
        /// </summary>
        /// <param name="numberOFContestants"></param>
        /// <returns>A random number that correlates with a contestant RegID</returns>
        private int GenerateRandomInt(int numberOFContestants)
        {   // Generates a random number
            Random Random;
            Random = new Random(Guid.NewGuid().GetHashCode());
            int hash = 0;
            return hash = Random.Next(numberOFContestants - 1);
        }

    }
}
