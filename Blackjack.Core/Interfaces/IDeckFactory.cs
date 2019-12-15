using System.Collections.Generic;
using Blackjack.Core.Entities;
using Blackjack.Core.Factories;

namespace Blackjack.Core.Interfaces
{
    public interface IDeckFactory
    {
        IDeck Create(int numberOfDecks = 1, bool shuffle = true);
    }
}