using System.Linq;
using Blackjack.Core.Entities;
using Blackjack.Core.Interfaces;

namespace Blackjack.Core.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IDeckFactory deckFactory;

        public GameFactory(IDeckFactory deckFactory)
        {
            this.deckFactory = deckFactory;
        }

        public IGame Create()
        {
            return new BlackJackGame(deckFactory);
        }
    }
}