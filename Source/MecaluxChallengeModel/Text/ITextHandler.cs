using MecaluxChallenge.Text.Sort;
using MecaluxChallenge.Text.Statistics;

namespace MecaluxChallenge.Text
{
    public interface ITextHandler
    {
        /// <summary>
        /// Method to sort a Text
        /// </summary>
        /// <param name="textToSort">piece of text</param>
        /// <param name="sorter">sorter of text</param>
        /// <returns>Piece of text sorted</returns>
        string Sort(string textToSort, ITextSorter sorter);

        /// <summary>
        /// Get text statistics
        /// </summary>
        /// <param name="textToQuery">text where calculate statistics</param>
        /// <returns>TextStatistic object  with calculated statistics</returns>
        TextStatistics GetStatistics(string textToQuery);

    }
}
