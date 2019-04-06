using System.Linq;
using MecaluxChallenge.Text.Infrastructure;

namespace MecaluxChallenge.Text.Sort
{
    /// <summary>
    /// Text Sorter based on Alphabetic Ascendent criteria
    /// </summary>
    internal class AlphabeticAscendentSorter : TextSorter
    {

        #region ITextSorter
              
        protected override string SortText(string textToSort)
        {
            string[] splittedText = textToSort.Split(TextConstants.SPLITTER);
            string[] splittetTextOrdered = splittedText.OrderBy(word => word).ToArray();
            return string.Join(TextConstants.SPLITTER.ToString(), splittetTextOrdered);
        }

        #endregion
    }
}
