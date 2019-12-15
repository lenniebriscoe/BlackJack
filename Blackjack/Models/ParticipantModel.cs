using Blackjack.Core.Entities;
using Blackjack.Core.Interfaces;

namespace Blackjack.Api.Models
{
    public class ParticipantModel
    {
        public HandModel Hand { get; set; }

        public bool Finished { get; set; }

        public string Name { get; set; }


        public ParticipantModel(IParticipant participant)
        {
            this.Hand = new HandModel(participant.Hand);
            this.Finished = participant.Finished;

            if (participant.GetType().IsAssignableFrom(typeof(Player)))
            {
                this.Name = ((Player)participant).Name;
            }
            else
            {
                this.Name = "Dealer";
            }
        }
    }
}