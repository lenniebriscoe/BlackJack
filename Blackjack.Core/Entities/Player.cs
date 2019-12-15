using Blackjack.Core.Entities;

namespace Blackjack.Core.Entities
{
    public class Player : Participant
    {
        public string Name { get; }

        public Player(string name)
        {
            this.Name = name;
        }

    }
}