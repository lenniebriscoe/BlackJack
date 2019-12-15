using System.Collections.Generic;
using System.Linq;
using Blackjack.Core.Entities;
using Blackjack.Models;

namespace Blackjack.Api.Models
{
    public class HandModel
    {
        public HandModel(Hand hand)
        {
            this.Cards = hand.Cards.Select(x => new CardModel(x)).ToList();
            this.Won = hand.Won;
            this.Total = hand.Total;
        }

        public IList<CardModel> Cards { get; set; }

        public bool Won { get; set; }

        public int Total { get; set; }
    }
}