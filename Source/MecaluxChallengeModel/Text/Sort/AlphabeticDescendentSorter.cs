using MecaluxChallenge.Text.Infrastructure;
using System.Linq;

namespace MecaluxChallenge.Text.Sort
{
    /// <summary>
    /// Text Sorter based on Alphabetic Descendent criteria
    /// </summary>
    internal class AlphabeticDescendentSorter : TextSorter
    {

        #region ITextSorter

        protected override string SortText(string textToSort)
        {
            string[] splittedText = textToSort.Split(TextConstants.SPLITTER);
            string[] splittetTextOrdered = splittedText.OrderByDescending(word => word).ToArray();
            return string.Join(TextConstants.SPLITTER.ToString(), splittetTextOrdered);
        }

        #endregion

    }
}
