using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LinqToTwitter;
using Microsoft.Extensions.Configuration;

namespace _2kPatosBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();


            var auth = new SingleUserAuthorizer
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    ConsumerKey = configuration["consumerKey"],
                    ConsumerSecret = configuration["consumerSecret"],
                    AccessToken = configuration["accessToken"],
                    AccessTokenSecret = configuration["accessTokenSecret"]
                }
            };

            var twitterCtx = new TwitterContext(auth);

            var service = new TwitterService(twitterCtx);
            var s = service.SendDirectMessage().Result;
        }
    }

    public class TwitterService
    {
        private TwitterContext twitterCtx;

        public TwitterService(TwitterContext twitterCtx)
        {
            this.twitterCtx = twitterCtx;
        }

        public void Retweet()
        {
            twitterCtx.Streaming.Where(x=>x.Type==Stre)
        }

        public async Task<DirectMessage> SendDirectMessage()
        {
            var message = await twitterCtx.NewDirectMessageAsync(
                "jcor20", "Hola! Soy el asistente virtual de 2k patos. Esto en un mensaje de prueba enviado el " + DateTime.Now + "!'");

            if (message != null)
                Console.WriteLine(
                    "Recipient: {0}, Message: {1}, Date: {2}",
                    message.RecipientScreenName,
                    message.Text,
                    message.CreatedAt);
            return message;
        }
    }
}
