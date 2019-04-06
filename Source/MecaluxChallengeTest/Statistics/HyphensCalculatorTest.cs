using MecaluxChallenge.Text.Statistics;
using NUnit.Framework;

namespace MecaluxChallengeTest.Statistics
{
    [TestFixture]
    public class HyphensCalculatorTest
    {
        [TestCase("uno-dos-tres-cuatro", 3)]
        [TestCase("uno-dos-tres--cuatro", 4)]
        [TestCase("----------", 10)]
        public void GetStatistics_WithHyphensDelimiterForWords_ReturnCorrectCounting(string textQuery, int expectingWords)
        {
            //Arrange
            ICountingStatisticCalculator hyphensCalculator = new HyphensCalculator();

            //Action
            ITextCountingStatistic result = hyphensCalculator.GetStatistics(textQuery);

            //Assert
            Assert.True(result.GetCount() == expectingWords);
        }

        [TestCase("uno.dos.tres.cuatro", 0)]
        [TestCase("", 0)]
        public void GetStatistics_WithoutHyphens_ReturnCorrectCounting(string textQuery, int expectingWords)
        {
            //Arrange
            ICountingStatisticCalculator hyphensCalculator = new HyphensCalculator();

            //Action
            ITextCountingStatistic result = hyphensCalculator.GetStatistics(textQuery);

            //Assert
            Assert.True(result.GetCount() == expectingWords);
        }
    }
}
