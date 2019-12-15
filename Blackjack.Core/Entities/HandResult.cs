using System.Reflection.Metadata;

namespace Blackjack.Core.Entities
{
    public class HandResult
    {
        public bool Bust { get; set; }

        public int HandTotal { get; set; }

        public bool GameFinished { get; set; }

        public bool Won { get; set; }
    }
}