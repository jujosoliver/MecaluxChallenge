using MecaluxChallenge.DI;
using MecaluxChallenge.Text.Enums;
using MecaluxChallenge.Text.Sort;
using MecaluxChallenge.Text.Statistics;
using Autofac;
using MecaluxChallenge.Text.Infrastructure;

namespace MecaluxChallenge.Text
{
    /// <summary>
    /// Simple class to cover two challenged methods
    /// </summary>
    public class TextHandler
    {

        #region methods

        /// <summary>
        /// Method to sort a Text
        /// </summary>
        /// <param name="textToSort">piece of text</param>
        /// <param name="sortMode">sort criteria <see cref="eSortMode"/></param>
        /// <returns>Piece of text sorted</returns>
        public string Sort(string textToSort ,eSortMode sortMode)
        {            
            ITextSorter sorter = DIService.ContainerService.ResolveKeyed<ITextSorter>(sortMode);
            return sorter.Sort(textToSort);
        }


        /// <summary>
        /// Get text statistics
        /// </summary>
        /// <param name="textToQuery">text where calculate statistics</param>
        /// <returns>TextStatistic object  with calculated statistics</returns>
        public TextStatistics GetStatistics(string textToQuery)
        {
            IEngineCalculator currentEngine = DIService.ContainerService.ResolveNamed<IEngineCalculator>(TextConstants.DEFAULT_ENGINE);
            currentEngine.RegisterStatisticCalculator(DIService.ContainerService.ResolveKeyed<ICountingStatisticCalculator>(eStatistics.WordCount));
            currentEngine.RegisterStatisticCalculator(DIService.ContainerService.ResolveKeyed<ICountingStatisticCalculator>(eStatistics.HyphensCount));
            currentEngine.RegisterStatisticCalculator(DIService.ContainerService.ResolveKeyed<ICountingStatisticCalculator>(eStatistics.SpaceCount));

            return currentEngine.Calculate(textToQuery);
        }

        #endregion
    }
}
