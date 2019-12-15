using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Blackjack.Core.Entities;
using Blackjack.Core.Enums;
using Blackjack.Core.Tests.Common;
using FluentAssertions;
using Xunit;

namespace Blackjack.Core.Tests.Entities
{
    public class HandTests
    {
        [Theory]
        [MemberData(nameof(TestData.GetTestHandsWithExpectedTotals), MemberType = typeof(TestData))]
        public void ShouldTotalToCorrectAmount(Hand hand, int expectedTotal)
        {
            hand.Total.Should().Be(expectedTotal);
        }
    }
}
