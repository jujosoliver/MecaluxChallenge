using MecaluxChallenge.Text.Statistics;
using NUnit.Framework;

namespace MecaluxChallengeTest.Statistics
{
    [TestFixture]
    public class WordCalculatorTest
    {
        
        [TestCase("", 0)]
        [TestCase("unodostrescuatro", 1)]
        [TestCase("unodos-tres cuatro", 2)]
        public void GetStatistics_WithSpaceDelimiterForWords_ReturnCorrectCounting(string textQuery, int expectingWords)
        {
            //Arrange
            ICountingStatisticCalculator wordCalculator = new WordCalculator();

            //Action
            ITextCountingStatistic result = wordCalculator.GetStatistics(textQuery);
            
            //Assert
            Assert.True(result.GetCount() == expectingWords);    
        }

        [TestCase("uno-dos-tres-cuatro", 4)]
        [TestCase("uno.dos.tres.cuatro", 4)]
        [TestCase("uno dos,tres cuatro", 4)]
        public void GetStatistics_WithNonSpaceDelimiter_ReturnIncorrectCounting(string textQuery, int expectingWords)
        {
            //Arrange
            ICountingStatisticCalculator wordCalculator = new WordCalculator();

            //Action
            ITextCountingStatistic result = wordCalculator.GetStatistics(textQuery);

            //Assert
            Assert.False(result.GetCount() == expectingWords);
        }

    }
}
