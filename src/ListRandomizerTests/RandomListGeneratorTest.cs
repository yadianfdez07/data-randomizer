using ListRandomizer;
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
    }
}