using AdvQuestion5;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTest
{
    public class UnitTest
    {
        public static IEnumerable<object[]> GetEnvelopes()
        {
            yield return new object[] { new List<Rectangle> { new Rectangle(50, 50), new Rectangle(25, 50), new Rectangle(20, 18), new Rectangle(15, 5) }, 3}; 
        }

        [Theory]
        [MemberData(nameof(GetEnvelopes))]
        public void Test1(List<Rectangle> envelopes, int Target)
        {
            Assert.Equal(Program.MaxEnvelopes(envelopes), Target);
        }
    }
}
