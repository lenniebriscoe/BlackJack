using System;
using System.Linq;
using Blackjack.Core.Entities;
using Blackjack.Core.Enums;
using Blackjack.Core.Interfaces;

namespace Blackjack.Core.Factories
{
    public class DeckFactory : IDeckFactory
    {

        public DeckFactory()
        {
        }

        public IDeck Create(int numberOfDecks = 1, bool shuffle = true)
        {
            var cards = Enumerable.Range(1, numberOfDecks)
                .SelectMany(n => Enumerable.Range(1, 4)
                    .SelectMany(s => Enumerable.Range(1, 13)
                        .Select(c => new Card()
                        {
                            Suit = (Suit)s,
                            CardNumber = (CardNumber)c
                        }
                        )
                    )
                )
                .ToList();


            if (shuffle)
            {
                cards = cards.OrderBy(c => Guid.NewGuid()).ToList();
            }

            return new Deck { Cards = cards };
        }
    }
}
