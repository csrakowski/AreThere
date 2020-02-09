using System;
using System.Collections.Generic;
using System.Linq;
using CSRakowski.AreThere;
using Xunit;

namespace CSRakowski.AreThere.Tests
{
    public class AreThereTests
    {
        [Theory]
        [MemberData(nameof(GetData_Any))]
        public void ThereAre_Any<T>(IEnumerable<T> elements, bool expected)
        {
            var actual = ThereAre.Any(elements);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetData_Any))]
        public void ThereAre_No<T>(IEnumerable<T> elements, bool expected)
        {
            var actual = ThereAre.No(elements);
            Assert.NotEqual(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetData_Count))]
        public void ThereAre_AtLeast<T>(IEnumerable<T> elements, int numberOfElements, bool expected)
        {
            var actual = ThereAre.AtLeast(numberOfElements, elements);
            Assert.Equal(expected, actual);
        }


        public static IEnumerable<object[]> GetData_Any =>
            new List<object[]>
            {
                new object[] { Enumerable.Range(1, 10), true },
                new object[] { Enumerable.Empty<int>(), false },
                new object[] { new[] { 1, 2, 3}, true },
                new object[] { Array.Empty<int>(), false },
                new object[] { new List<int>(), false }
            };

        public static IEnumerable<object[]> GetData_Count =>
            new List<object[]>
            {
                new object[] { Enumerable.Range(1, 10), 10, true },
                new object[] { Enumerable.Empty<int>(), 0, true },
                new object[] { new[] { 1, 2, 3}, 3, true },
                new object[] { Array.Empty<int>(), 0, true },
                new object[] { new List<int>(), 0, true },
                new object[] { Enumerable.Range(1, 10), 11, false },
                new object[] { Enumerable.Empty<int>(), 1, false },
                new object[] { new[] { 1, 2, 3}, 4, false },
                new object[] { Array.Empty<int>(), 1, false },
                new object[] { new List<int>(), 1, false }
            };
    }
}
