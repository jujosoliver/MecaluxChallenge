namespace MecaluxChallenge.Text.Statistics
{
    /// <summary>
    /// Abstraction of a engine statistic calculator
    /// </summary>
    public interface IEngineCalculator
    {


        /// <summary>
        /// Method to add calculators to an Engine Calculator
        /// It's a extension point for apply Open-Close and DI  SOLID principles.
        /// </summary>
        /// <param name="calculator"></param>
        void RegisterStatisticCalculator(ICountingStatisticCalculator calculator);

        /// <summary>
        /// Method that fires registered calculators
        /// </summary>
        /// <param name="queryText"></param>
        /// <returns></returns>
        TextStatistics Calculate(string queryText);

      
    }
}
