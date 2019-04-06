using Autofac;
using MecaluxChallenge.DI;
using MecaluxChallenge.Text.Enums;
using System.Linq;

namespace MecaluxChallenge.Text.Statistics
{

    /// <summary>
    /// Class to get space count statistic
    /// </summary>
    public class SpaceCalculator : ICountingStatisticCalculator
    {
        #region IStatisticCalculator
              
        ITextCountingStatistic ICountingStatisticCalculator.GetStatistics(string queryText)
        {
            int countResult = queryText.ToCharArray().Where(character => character == ' ').Count();
            ITextCountingStatistic result = DIService.ContainerService.Resolve<ITextCountingStatistic>();
            result.SetStatistic(eStatistics.SpaceCount, countResult);
            return result;
        }

        #endregion

    }
}
