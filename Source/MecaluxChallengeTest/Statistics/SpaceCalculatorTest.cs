using MecaluxChallenge.Text.Statistics;
using NUnit.Framework;

namespace MecaluxChallengeTest.Statistics
{
    [TestFixture]
    public class SpaceCalculatorTest
    {
        [TestCase("uno dos tres cuatro", 3)]  
        [TestCase("uno dos tres  cuatro", 4)]
        [TestCase("          ", 10)]
        public void GetStatistics_WithSpacesDelimiterForWords_ReturnCorrectCounting(string textQuery, int expectingWords)
        {
            //Arrange
            ICountingStatisticCalculator spaceCalculator = new SpaceCalculator();

            //Action
            ITextCountingStatistic result = spaceCalculator.GetStatistics(textQuery);

            //Assert
            Assert.True(result.GetCount() == expectingWords);
        }

        [TestCase("uno.dos.tres.cuatro", 0)]
        [TestCase("", 0)]
        public void GetStatistics_WithoutSpaces_ReturnCorrectCounting(string textQuery, int expectingWords)
        {
            //Arrange
            ICountingStatisticCalculator spaceCalculator = new SpaceCalculator();

            //Action
            ITextCountingStatistic result = spaceCalculator.GetStatistics(textQuery);

            //Assert
            Assert.True(result.GetCount() == expectingWords);
        }

    }
}
