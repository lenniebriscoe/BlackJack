using System.Collections.Generic;
using Blackjack.Core.Entities;

namespace Blackjack.Core.Interfaces
{
    public interface IParticipant
    {
        Hand Hand { get; set; }

        bool Finished { get; set; }
    }
}