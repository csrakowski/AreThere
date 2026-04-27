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
        public void ThereAre_Any(IEnumerable<int> elements, bool expected)
        {
            var actual = ThereAre.Any(elements);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetData_Any))]
        public void ThereAre_No(IEnumerable<int> elements, bool expected)
        {
            var actual = ThereAre.No(elements);
            Assert.NotEqual(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetData_Count))]
        public void ThereAre_AtLeast(IEnumerable<int> elements, int numberOfElements, bool expected)
        {
            var actual = ThereAre.AtLeast(numberOfElements, elements);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetData_Count))]
        public void ThereAre_NoMoreThan(IEnumerable<int> elements, int numberOfElements, bool expected)
        {
            var actual = ThereAre.NoMoreThan(numberOfElements, elements);
            Assert.NotEqual(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetData_Even))]
        public void ThereAre_EvenNumberOfElements(IEnumerable<int> elements, bool expected)
        {
            var actual = ThereAre.EvenNumberOfElements(elements);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetData_Even))]
        public void ThereAre_OddNumberOfElements(IEnumerable<int> elements, bool expected)
        {
            var actual = ThereAre.OddNumberOfElements(elements);
            Assert.NotEqual(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetData_CountExact))]
        public void ThereAre_Exactly(IEnumerable<int> elements, int numberOfElements, bool expected)
        {
            var actual = ThereAre.Exactly(numberOfElements, elements);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetData_CountExact))]
        public void ThereAre_HowMany(IEnumerable<int> elements, int expected, bool isCorrect)
        {
            var actual = ThereAre.HowMany(elements);
            if (isCorrect)
            {
                Assert.Equal(expected, actual);
            }
            else
            {
                Assert.NotEqual(expected, actual);
            }
        }

        public static TheoryData<IEnumerable<int>, bool> GetData_Any =>
            new TheoryData<IEnumerable<int>, bool>
            {
                { Enumerable.Range(1, 10), true },
                { Enumerable.Empty<int>(), false },
                { new[] { 1, 2, 3}, true },
                { Array.Empty<int>(), false },
                { new List<int>(), false }
            };

        public static TheoryData<IEnumerable<int>, int, bool> GetData_Count =>
            new TheoryData<IEnumerable<int>, int, bool>
            {
                { Enumerable.Range(1, 10), 10, true },
                { Enumerable.Range(1, 10), 11, false },
                { Enumerable.Range(1, 10), 9, true },
                { Enumerable.Empty<int>(), 0, true },
                { new[] { 1, 2, 3}, 3, true },
                { Array.Empty<int>(), 0, true },
                { new List<int>(), 0, true },
                { Enumerable.Range(1, 10), 11, false },
                { Enumerable.Empty<int>(), 1, false },
                { new[] { 1, 2, 3}, 4, false },
                { Array.Empty<int>(), 1, false },
                { new List<int>(), 1, false }
            };

        public static TheoryData<IEnumerable<int>, bool> GetData_Even =>
            new TheoryData<IEnumerable<int>, bool>
            {
                { Enumerable.Range(1, 10), true },
                { Enumerable.Range(1, 4), true },
                { Enumerable.Range(1, 5), false },
                { Enumerable.Range(1, 9), false },
                { Enumerable.Empty<int>(), true },
                { new[] { 1, 2, 3}, false },
                { Array.Empty<int>(), true },
                { new List<int>(), true }
            };

        public static TheoryData<IEnumerable<int>, int, bool> GetData_CountExact =>
            new TheoryData<IEnumerable<int>, int, bool>
            {
                { Enumerable.Range(1, 10), 10, true },
                { Enumerable.Range(1, 10), 11, false },
                { Enumerable.Range(1, 10), 9, false },
                { Enumerable.Empty<int>(), 0, true },
                { new[] { 1, 2, 3}, 3, true },
                { Array.Empty<int>(), 0, true },
                { new List<int>(), 0, true },
                { Enumerable.Range(1, 10), 11, false },
                { Enumerable.Empty<int>(), 1, false },
                { new[] { 1, 2, 3}, 4, false },
                { Array.Empty<int>(), 1, false },
                { new List<int>(), 1, false },
                { new List<int>() { 1 }, 1, true }
            };
    }
}
