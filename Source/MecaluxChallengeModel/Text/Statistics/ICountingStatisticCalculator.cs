namespace MecaluxChallenge.Text.Statistics
{
    /// <summary>
    /// Count Statistics Calculator abstraction
    /// </summary>
    public interface ICountingStatisticCalculator
    {
        /// <summary>
        /// method that fires calcul.
        /// </summary>
        /// <param name="queryText">text under calcul</param>
        /// <returns>calcul result <see cref="ITextCountingStatistic"/></returns>
        ITextCountingStatistic GetStatistics(string queryText);
    }
}
