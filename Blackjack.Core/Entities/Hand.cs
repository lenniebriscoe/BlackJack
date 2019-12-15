using System;
using System.Collections.Generic;
using System.Linq;
using Blackjack.Core.Enums;

namespace Blackjack.Core.Entities
{
    public class Hand
    {
        public IList<Card> Cards { get; set; }

        public int Total
        {
            get
            {
                var numberOfAces = Cards.Count(x => x.CardNumber == CardNumber.Ace);
                var maxHandValue = Cards.Sum(y => y.Value.Max());
                var handTotal = maxHandValue;
                
                while (handTotal > 21 && (numberOfAces-- > 0))
                    handTotal -= 10;

                return handTotal;
            }
        }

        public bool Won { get; set; }

        internal void Add(IList<Card> cards)
        {
            ((List<Card>)Cards).AddRange(cards);
        }
    }
}