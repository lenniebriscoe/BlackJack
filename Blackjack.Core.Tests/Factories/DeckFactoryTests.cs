using Blackjack.Core.Enums;
using Blackjack.Core.Factories;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using Xunit;

namespace Blackjack.Core.Tests.Factories
{
    public class DeckFactoryTests
    {
        private DeckFactory sut;

        [Fact]
        public void ShouldCreate52CardsWhenOneDeckRequested()
        {
            sut = new DeckFactory();

            var result = sut.Create(1, false);

            result.Cards.Count.Should().Be(52);

            for (int suit = 1; suit < 5; suit++)
            {
                for (int value = 1; value < 14; value++)
                {
                    result.Cards[(13 * (suit - 1)) + value - 1].Suit.Should().Be((Suit)suit);
                    result.Cards[(13 * (suit - 1)) + value - 1].CardNumber.Should().Be((CardNumber)value);
                }

            }
        }

        [Fact]
        public void ShouldCreate104CardsWhenTwoDeckRequested()
        {
            sut = new DeckFactory();

            var result = sut.Create(2, false);

            result.Cards.Count.Should().Be(104);
        }
    }
}