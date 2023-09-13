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
            Random rnd = new Random();
            int cardFace = rnd.Next(3);
            int cardValue = rnd.Next(12);

            Card card = Card.FetchCard(cardFace, cardValue);

            return card;

        }
    }
}
