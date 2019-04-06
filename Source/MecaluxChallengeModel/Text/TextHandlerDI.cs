using MecaluxChallenge.Text.Sort;
using MecaluxChallenge.Text.Statistics;

namespace MecaluxChallenge.Text
{
    /// <summary>
    /// Simple class to cover two challenged methods with DI
    /// </summary>
    public class TextHandlerDI : ITextHandler
    {

        #region "fields"
                
        IEngineCalculator engine;

        #endregion


        #region "constructors"

        public TextHandlerDI(IEngineCalculator currentEnginer)
        {
            this.engine = currentEnginer;
        }

        #endregion


        #region "ITextHandler"
        /// <summary>
        /// Method to sort a Text
        /// </summary>
        /// <param name="textToSort">piece of text</param>
        /// <param name="sorter">sorter of text</param>
        /// <returns>Piece of text sorted</returns>
        public string Sort(string textToSort, ITextSorter sorter)
        {           
            return sorter.Sort(textToSort);
        }


        /// <summary>
        /// Get text statistics
        /// </summary>
        /// <param name="textToQuery">text where calculate statistics</param>
        /// <returns>TextStatistic object  with calculated statistics</returns>
        public TextStatistics GetStatistics(string textToQuery)
        {
            return engine.Calculate(textToQuery);
        }

        #endregion
       
    }
}
