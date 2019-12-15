using System.Collections.Generic;
using Blackjack.Core.Entities;

namespace Blackjack.Core.Interfaces
{
    public interface IDeck
    {
        public IList<Card> Cards { get; set; }

        public IList<Card> TakeCards(int numberOfCards);
    }
}