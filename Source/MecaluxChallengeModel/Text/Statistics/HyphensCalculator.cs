using Autofac;
using MecaluxChallenge.DI;
using MecaluxChallenge.Text.Enums;
using System.Linq;

namespace MecaluxChallenge.Text.Statistics
{
    /// <summary>
    /// Class to get hyphens count statistic
    /// </summary>
    public class HyphensCalculator : ICountingStatisticCalculator
    {

        #region IStatisticCalculator
            
        ITextCountingStatistic ICountingStatisticCalculator.GetStatistics(string queryText)
        {
            int countResult= queryText.ToCharArray().Where(character => character == '-').Count();
            ITextCountingStatistic result = DIService.ContainerService.Resolve<ITextCountingStatistic>();
            result.SetStatistic(eStatistics.HyphensCount, countResult);

            return result;
        }

        #endregion

    }
}
