using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Blackjack.Core.Interfaces
{
    public interface IGame
    {
        List<IParticipant> Participants { get; set; }
        
        public bool Finished { get; }

        void Start(string[] participants);
    }
}