using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getCard
{
    public static class GetCardRandom
    {
        [FunctionName("GetCardRandom")]
        public static Card Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route ="GetCard/Random")] HttpRequest req)
        {

            string queryParameter = req.Query["WithJoker"];

            Boolean.TryParse(queryParameter, out bool withJoker);

            Random rnd = new Random();
            Card card = new Card();
            int cardFace;
            int cardValue;

            if (withJoker)
            {
                int cardNumber = rnd.Next(54);

                switch (cardNumber)
                {
                    case int i when i >= 0 && i < 13:
                        cardFace = 0;
                        cardValue = cardNumber;
                        break;
                    case int i when i >= 13 && i < 26:
                        cardFace = 1;
                        cardValue = cardNumber-13;
                        break;
                    case int i when i >= 26 && i < 39:
                        cardFace = 2;
                        cardValue = cardNumber-26;
                        break;
                    case int i when i >= 39 && i < 52:
                        cardFace = 3;
                        cardValue = cardNumber - 39;
                        break;
                    default:
                        cardFace = 4;
                        cardValue = 13;
                        break;
                }
            } else
            {
                cardFace = rnd.Next(3);
                cardValue = rnd.Next(12);
            }

            card = Card.FetchCard(cardFace, cardValue);

            return card;

        }
    }
}
