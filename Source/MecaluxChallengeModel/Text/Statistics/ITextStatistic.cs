using MecaluxChallenge.Text.Enums;

namespace MecaluxChallenge.Text.Statistics
{
    /// <summary>
    /// abstraction that represents a statistic result.
    /// </summary>
    public interface ITextStatistic
    {
        eStatistics GetStatistic();
    }
}
