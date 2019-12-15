using System.Collections.Generic;
using Blackjack.Core.Interfaces;

namespace Blackjack.Core.Entities
{
    public class Dealer : Participant
    {
        public IDeck Deck { get; set; }

    }
}