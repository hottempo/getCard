using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getCard
{
    public class Card
    {
        public string CardFace { get; set; }
        public string CardValue { get; set; }

        private static string[] CardFaces = { "Spar", "Hjerter", "Klør", "Ruder", "Joker" };

        private static IDictionary<int, string> CardValues = new Dictionary<int, string>()
        {
            {0, "Es" },
            {10, "Knægt" },
            {11, "Dame" },
            {12, "Konge" },
            {13, "Joker" }
        };

        public static Card FetchCard(int cardFace, int cardValue)
        {
            Card card = new Card();

            card.CardFace = CardFaces[cardFace];
            card.CardValue = (cardValue == 0 || cardValue > 9) ? CardValues[cardValue] : (cardValue + 1).ToString();

            return card;
        }
    }
}
