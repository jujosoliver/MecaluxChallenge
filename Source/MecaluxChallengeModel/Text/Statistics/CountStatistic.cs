using MecaluxChallenge.Text.Enums;

namespace MecaluxChallenge.Text.Statistics
{
    /// <summary>
    /// abstraction of counting elements statistic result
    /// </summary>
    public class CountStatistic : ITextCountingStatistic
    {

        #region fields

        eStatistics statisticMode;
        int statisticCount;

        #endregion

        #region constructor

        /// <summary>
        /// default constructor
        /// </summary>
        public CountStatistic()
        {
            this.statisticMode = eStatistics.Undefined;
            this.statisticCount = 0;
        }

        /// <summary>
        /// Initalizator constructor
        /// </summary>
        /// <param name="statisticMode">Kind of statistic result</param>
        /// <param name="countOfStatistic">Count result</param>
        public CountStatistic(eStatistics statisticMode, int countOfStatistic) : this()
        {
            
            this.statisticMode = statisticMode;
            this.statisticCount = countOfStatistic;
        }

        #endregion

        #region ITextCountingStatistic

        int ITextCountingStatistic.GetCount()
        {
            return this.statisticCount;
        }

        eStatistics ITextStatistic.GetStatistic()
        {
            return this.statisticMode;
        }

        void ITextCountingStatistic.SetStatistic(eStatistics statistic, int result)
        {
            this.statisticCount = result;
            this.statisticMode = statistic;
        }

        #endregion

    }
}
