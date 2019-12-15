using System.Linq;
using Blackjack.Core.Entities;
using Blackjack.Core.Interfaces;
using Blackjack.Core.Tests.Common;
using FluentAssertions;
using Moq;
using Xunit;

namespace Blackjack.Core.Tests.Entities
{
    public class BlackJackGameShould
    {
        private BlackJackGame sut;
        private Mock<IDeckFactory> mockDeckFactory;

        public BlackJackGameShould()
        {
            mockDeckFactory = new Mock<IDeckFactory>();

            sut = new BlackJackGame(mockDeckFactory.Object);

            mockDeckFactory.Setup(x => x.Create(1, true)).Returns(TestData.GetDeck(1, false));

            sut.Start(new[] { "Anthony" });
        }

        [Fact]
        public void StartWithDealerAndOnePlayerWithTwoCardsEach()
        {
            sut.Participants.Count.Should().Be(2);
            sut.Participants.OfType<Dealer>().Count().Should().Be(1);
            sut.Participants.OfType<Player>().Count().Should().Be(1);

            sut.Participants.OfType<Dealer>().First().Hand.Cards.Count.Should().Be(2);
            sut.Participants.OfType<Player>().First().Hand.Cards.Count.Should().Be(2);
        }

    }
}