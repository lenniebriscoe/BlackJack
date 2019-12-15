using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Blackjack.Core.Entities;
using Blackjack.Core.Interfaces;

namespace Blackjack.Api.Models
{
    public class GameModel
    {
        public IList<ParticipantModel> Participants { get; set; }

        public bool Finished { get; set; }

        public GameModel(IGame game)
        {
            this.Participants = game.Participants.Where(p => (p is Player && game.Finished == false) || game.Finished).Select(x => new ParticipantModel(x)).ToList();

            this.Finished = game.Finished;
        }
    }
}