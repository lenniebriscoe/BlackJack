using System.Linq;
using Blackjack.Api.Models;
using Blackjack.Core.Entities;
using Blackjack.Core.Interfaces;
using Blackjack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Blackjack.Api.Controllers
{
    [ApiController]
    [Route("[controller")]
    public class ParticipantsController : ControllerBase
    {
        private readonly ILogger<BlackJackController> _logger;
        private readonly IGame game;

        public ParticipantsController(ILogger<BlackJackController> logger, IGame game)
        {
            _logger = logger;
            this.game = game;
        }

        /// <summary>
        /// Returns the participants hand if a name supplied
        /// </summary>
        /// <param name="participantName">The name of the participant's hand to return</param>
        /// <returns>The details of the hand and whether it has won after the game has finished</returns>
        [HttpGet]
        [Route("/{participantName}/hand")]
        public IActionResult GetHand(string participantName)
        {
            if (string.IsNullOrEmpty(participantName))
            {
                return BadRequest($"A Participant name is required.");
            }

            IParticipant participant = game.Participants.OfType<Player>().FirstOrDefault(x => x.Name == participantName);
            
            
            if (participant == null)
            {
                return NotFound($"Participant called {participantName} is not at the table.");
            }

            var handModel = new HandModel(participant.Hand);

            return Ok(handModel);
        }

        /// <summary>
        /// Get the dealers hand
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/dealer/hand")]
        public IActionResult GetDealersHand()
        {
            IParticipant participant = game.Participants.OfType<Dealer>().First();

            var handModel = new HandModel(participant.Hand);

            return Ok(handModel);
        }
    }
}