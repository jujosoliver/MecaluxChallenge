using Autofac;
using MecaluxChallenge.DI;
using MecaluxChallenge.Text.Enums;
using MecaluxChallenge.Text.Infrastructure;

namespace MecaluxChallenge.Text.Statistics
{
    /// <summary>
    /// Class to get word count statistic
    /// </summary>
    public class WordCalculator : ICountingStatisticCalculator
    {

        #region IStatisticCalculator

        ITextCountingStatistic ICountingStatisticCalculator.GetStatistics(string queryText)
        {
            int countResult = queryText.Split(TextConstants.SPLITTER).Length;
            ITextCountingStatistic result = DIService.ContainerService.Resolve<ITextCountingStatistic>();
            result.SetStatistic(eStatistics.WordCount, countResult);
            return result;
        }

        #endregion

    }
}
