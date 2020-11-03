using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using Google.Apis.Auth.OAuth2;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Util.Store;
using Google.Apis.Util;
using System.Threading;
using MailKit.Security;
using MailKit.Net.Imap;

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
            // TheBestTestIn@TheWest.biz
            Contestant contestant = new Contestant("Her majesty the", "royal lady Wadie the 1st", "wakihe4437@50000z.com", regid);
            //Contestant contestant = new Contestant(fName, lName, email, regid);
            return contestant;
        }

        public Contestant PickWinner()
        {
            return _contestants[GenerateRandomInt(_contestants.Count())]; // return contestant
        }

        public async Task sendemail(Contestant contestant)
        {
            await EmailContestantAsync(contestant);
        }

        public async Task EmailContestantAsync(Contestant sc)
        {
            const string GMailAccount = "throwmeawaybreakingben@gmail.com";

            

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
                        $"Just kidding it's your nephew and he sent you this email from his C# .Net application. \n" +
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


            using (var client = new ImapClient())
            {
                await client.ConnectAsync("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
                await client.AuthenticateAsync(oauth2);
                
                await client.DisconnectAsync(true);

            }



            
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
