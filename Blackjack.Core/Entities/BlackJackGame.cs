using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Blackjack.Core.Enums;
using Blackjack.Core.Interfaces;

namespace Blackjack.Core.Entities
{
    public class BlackJackGame : IGame
    {
        private readonly IDeckFactory deckFactory;

        public List<IParticipant> Participants { get; set; } = new List<IParticipant>();

        public bool Finished => Participants.OfType<Player>().All(x => x.Finished);

        public BlackJackGame(IDeckFactory deckFactory)
        {
            this.deckFactory = deckFactory;
        }

        public void Start(string[] names)
        {
            var dealer = new Dealer();
            Participants.Clear();
            Participants.Add(dealer);
            Participants.AddRange(names.Select(x => new Player(x)));

            var players = Participants.OfType<Player>();

            dealer.Deck = deckFactory.Create();

            foreach (var player in players)
            {
                player.Hand.Cards = dealer.Deck.TakeCards(2);
            }

            dealer.Hand.Cards = dealer.Deck.TakeCards(2);
        }

        public HandResult Hit(string participantName)
        {
            var dealer = Participants.OfType<Dealer>().First();

            //TODO think about player order
            var player = Participants.OfType<Player>().FirstOrDefault(x => x.Name == participantName);

            ValidatePlayer(player);

            //TODO think about what happens if the Deck runs out of cards
            player.Hand.Add(dealer.Deck.TakeCards(1));
            
            var handTotal = player.Hand.Total;
            if (handTotal > 21)
            {
                player.Finished = true;
            }

            return new HandResult { Bust = handTotal > 21, HandTotal = handTotal, GameFinished = this.Finished };
        }

        public HandResult Stick(string participantName)
        {
            bool gameFinished = false;
            var dealer = Participants.OfType<Dealer>().First();

            //TODO think about player order
            var player = Participants.OfType<Player>().FirstOrDefault(x => x.Name == participantName);
            var playerHandTotal = player.Hand.Total;

            ValidatePlayer(player);

            player.Finished = true;

            if (Participants.OfType<Player>().All(x => x.Finished) && !dealer.Finished)
            {
                int dealerHandTotal;

                do
                {
                    dealer.Hand.Add(dealer.Deck.TakeCards(1));

                    dealerHandTotal = dealer.Hand.Total;

                } while (dealerHandTotal < 17);

                dealer.Finished = true;

                if (dealerHandTotal > 21)
                {
                    Participants.OfType<Player>().Where(x => x.Hand.Total <= 21).ToList().ForEach(x => x.Hand.Won = true);
                }
                else
                {
                    Participants.OfType<Player>().Where(x => x.Hand.Total <= 21 && x.Hand.Total > dealerHandTotal).ToList().ForEach(x => x.Hand.Won = true);
                }

                gameFinished = true;
            }
            
            return new HandResult { Bust = playerHandTotal > 21, HandTotal = playerHandTotal, GameFinished = gameFinished, Won = player.Hand.Won };
        }

        private static void ValidatePlayer(Player player)
        {
            // TODO better way of validating required
            if (player == null)
            {
                throw new ArgumentException("Player hasn't sat down at the table.");
            }

            if (player.Finished)
            {
                throw new InvalidOperationException("Player has already finished this hand.");
            }
        }
    }
}