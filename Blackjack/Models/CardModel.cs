using Blackjack.Core.Entities;

namespace Blackjack.Models
{
    public class CardModel
    {
        public string Suit { get; set; }

        public string Face { get; set; }

        public int[] Value { get; set; }

        public CardModel(Card card)
        {
            this.Suit = card.Suit.ToString();
            this.Face = card.Face;
            this.Value = card.Value;
        }
    }
}