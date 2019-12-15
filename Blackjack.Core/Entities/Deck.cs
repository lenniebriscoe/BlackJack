using System.Collections.Generic;
using System.Linq;
using Blackjack.Core.Interfaces;

namespace Blackjack.Core.Entities
{
    public class Deck : IDeck
    {
        public IList<Card> Cards { get; set; }

        public IList<Card> TakeCards(int numberOfCards)
        {
            var cardsToReturn = Cards.Take(numberOfCards).ToList();

            Cards = Cards.Skip(numberOfCards).ToList();

            return cardsToReturn;
        }
    }
}