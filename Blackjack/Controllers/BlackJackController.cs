using System;
using System.Linq;
using Blackjack.Api.Models;
using Blackjack.Core.Entities;
using Blackjack.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Blackjack.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlackJackController : ControllerBase
    {
        private readonly ILogger<BlackJackController> _logger;
        private readonly IGame game;

        public BlackJackController(ILogger<BlackJackController> logger, IGame game)
        {
            _logger = logger;
            this.game = game;
        }

        /// <summary>
        /// Starts a Blackjack Game with a list of participants
        /// </summary>
        /// <param name="participants">String Array of participant names</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult StartGame(string[] participants)
        {
            if (participants.Length == 0)
            {
                return BadRequest("A game needs participants");
            }

            game.Start(participants);

            return Ok(true);
        }

        /// <summary>
        /// Get the current result of the game. All players hands are open. The dealers hand is open after the game has finished.
        /// </summary>
        /// <returns>Game result</returns>
        [HttpGet]
        public IActionResult GetGameResult()
        {
            if (game.Participants.Count == 0)
            {
                return BadRequest("Game not started yet");
            }

            return Ok(new GameModel(game));
        }

        /// <summary>
        /// Perform an action to update the game. Stick or Hit
        /// </summary>
        /// <param name="participantName">The participant to perform the action</param>
        /// <param name="action">The action to perform: Stick or Hit</param>
        /// <returns>A hand result</returns>
        [HttpPut]
        public IActionResult StickOrTwist(string participantName, BlackJackAction action)
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

            HandResult result;
            switch (action)
            {
                case BlackJackAction.Stick:
                    result = ((BlackJackGame)game).Stick(participantName);
                    break;
                case BlackJackAction.Hit:
                    result = ((BlackJackGame)game).Hit(participantName);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }

            return Ok(result);
        }
    }
}
