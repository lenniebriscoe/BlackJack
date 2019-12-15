using System;
using System.Collections.Generic;
using System.Linq;
using Blackjack.Core.Entities;
using Blackjack.Core.Enums;

namespace Blackjack.Core.Tests.Common
{
    public class TestData
    {
        public static IEnumerable<object[]> GetTestHandsWithExpectedTotals()
        {
            yield return new object[]
            {
                new Hand()
                {
                    Cards = new List<Card>
                    {
                        new Card {CardNumber = CardNumber.Two, Suit = Suit.Clubs},
                        new Card {CardNumber = CardNumber.Two, Suit = Suit.Hearts},
                    }
                },
                4
            };

            yield return new object[]
            {
                new Hand()
                {
                    Cards = new List<Card>
                    {
                        new Card {CardNumber = CardNumber.Queen, Suit = Suit.Clubs},
                        new Card {CardNumber = CardNumber.Ace, Suit = Suit.Hearts},
                    }
                },
                21
            };

            yield return new object[]
            {
                new Hand()
                {
                    Cards = new List<Card>
                    {
                        new Card {CardNumber = CardNumber.Ace, Suit = Suit.Clubs},
                        new Card {CardNumber = CardNumber.Ace, Suit = Suit.Hearts},
                    }
                },
                12
            };

            yield return new object[]
            {
                new Hand()
                {
                    Cards = new List<Card>
                    {
                        new Card {CardNumber = CardNumber.Queen, Suit = Suit.Clubs},
                        new Card {CardNumber = CardNumber.Two, Suit = Suit.Hearts},
                        new Card {CardNumber = CardNumber.King, Suit = Suit.Hearts},
                    }
                },
                22
            };

            yield return new object[]
            {
                new Hand()
                {
                    Cards = new List<Card>
                    {
                        new Card {CardNumber = CardNumber.Ace, Suit = Suit.Clubs},
                        new Card {CardNumber = CardNumber.Ace, Suit = Suit.Hearts},
                        new Card {CardNumber = CardNumber.Ace, Suit = Suit.Diamonds},
                        new Card {CardNumber = CardNumber.Ace, Suit = Suit.Spades},
                        new Card {CardNumber = CardNumber.King, Suit = Suit.Spades},
                        new Card {CardNumber = CardNumber.Six, Suit = Suit.Spades},
                    }
                },
                20
            };
        }

        public static Deck GetDeck(int decks, bool shuffle)
        {
            var deck = new Deck();
            deck.Cards = Enumerable.Range(1, decks)
                .SelectMany(n => Enumerable.Range(1, 4)
                    .SelectMany(s => Enumerable.Range(1, 13)
                        .Select(c => new Card()
                            {
                                Suit = (Suit) s,
                                CardNumber = (CardNumber) c
                            }
                        )
                    )
                ).ToList();

            if (shuffle)
            {
                deck.Cards = deck.Cards.OrderBy(c => Guid.NewGuid()).ToList();
            }

            return deck;
        }
    }
}