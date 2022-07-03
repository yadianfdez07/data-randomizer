using ListRandomizer;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ListRandomizerTests
{
    public class RandomListGeneratorTest
    {
        [Fact]
        public void ShouldGenerateRandomListOfIntegersOfRandomLength()
        {
            // arrange

            // act
            var result = RandomListGenerator.GetRandomIntList();

            // assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void ShouldReturnRandomListOfIntEveryTime()
        {
            // arrange
            var resultingLists = new List<List<int>>();
            var iterations = 5;

            // act
            for (int i = 0; i < iterations; i++)
            {
                resultingLists.Add(RandomListGenerator.GetRandomIntList());
            }

            // assert
            Assert.False(ContainsEqualList(resultingLists));
            Assert.NotEqual(resultingLists[0], resultingLists[1]);
            Assert.NotEqual(resultingLists[0], resultingLists[2]);
            Assert.NotEqual(resultingLists[0], resultingLists[3]);
            Assert.NotEqual(resultingLists[0], resultingLists[4]);
        }

        private bool ContainsEqualList(List<List<int>> listsToCompare)
        {

            foreach (var list in listsToCompare)
            {
                var otherLists = listsToCompare.Where(l => !list.Equals(l)).Select(l => l.ToList()).ToList();

                foreach (var otherList in otherLists)
                {
                    foreach (var item in list)
                    {
                        foreach (var target in otherList)
                        {
                            if (item == target)
                            {
                                return true;
                            }
                        }
                    }

                }
            }

            return false;
        }
    }
}