using MecaluxChallenge.Text.Enums;

namespace MecaluxChallenge.Text.Statistics
{
    /// <summary>
    /// Abstraction result statistic of type count.
    /// </summary>
    public interface ITextCountingStatistic : ITextStatistic
    {
        /// <summary>
        /// Get result of counting statistics
        /// </summary>
        /// <returns>integer that represents result of counting </returns>
        int GetCount();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statistic"></param>
        /// <param name="result"></param>
        void SetStatistic(eStatistics statistic, int result);
    }
}
