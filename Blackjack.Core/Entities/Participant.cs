using System.Collections.Generic;
using System.Linq;
using Blackjack.Core.Interfaces;

namespace Blackjack.Core.Entities
{
    public abstract class Participant : IParticipant
    {
        public Hand Hand { get; set; } = new Hand();

        public bool Finished { get; set; }
    }
}