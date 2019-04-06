using MecaluxChallenge.Text.Enums;
using MecaluxChallenge.Text.Sort;
using System;

namespace MecaluxChallenge.Text.Infrastructure
{
    /// <summary>
    /// Factory's ITextSorter instances. Implements Singleton Pattern
    /// </summary>
    public class TextSorterFactory
    {

        #region fields
        static private TextSorterFactory factoryInstance;
        #endregion

        #region constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        private TextSorterFactory()
        {

        }

        #endregion

        #region properties

        private static TextSorterFactory FactoryInstance
        {
            get
            {
                if(TextSorterFactory.factoryInstance == null)
                {
                    TextSorterFactory.factoryInstance = new TextSorterFactory();
                }
                return TextSorterFactory.factoryInstance;
            }
        }

        #endregion

        #region factory method

        /// <summary>
        /// factory method that creates a ITextSorter instance
        /// </summary>
        /// <param name="sortMode">Sorter criteria</param>
        /// <returns></returns>
        public static ITextSorter CreateTextSorter(eSortMode sortMode)
        {

            return TextSorterFactory.FactoryInstance.InstanceCreateTextSorter(sortMode);
            
        }

        private ITextSorter InstanceCreateTextSorter(eSortMode sortMode)
        {

            ITextSorter newInstance = null;
            switch (sortMode)
            {
                case eSortMode.AlphabeticAsc:
                    newInstance = new AlphabeticAscendentSorter();
                    break;

                case eSortMode.AlphabeticDesc:
                    newInstance = new AlphabeticDescendentSorter();
                    break;

                case eSortMode.LenghtAsc:
                    newInstance = new WordLengthSorter();
                    break;

                default:
                    throw new NotImplementedException(TextConstants.SORTER_CRITERIA_NOTIMPLEMENTED);
            }

            return newInstance;
        }

        #endregion

    }
}
