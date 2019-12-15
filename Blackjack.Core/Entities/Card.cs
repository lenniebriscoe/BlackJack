using System;
using Blackjack.Core.Enums;

namespace Blackjack.Core.Entities
{
    public class Card
    {
        public Suit Suit { get; set; }

        public string Face => CardNumber.ToString();

        public CardNumber CardNumber { get; set; }

        public int[] Value
        {
            get
            {
                switch (CardNumber)
                {
                    case CardNumber.Ace:
                        return new int[]{1, 11};
                    case CardNumber.Jack:
                    case CardNumber.Queen:
                    case CardNumber.King:
                        return new int[] {10};
                    default:
                        return new int[]{(int)CardNumber};
                }
            }
        }
    }
}