using MecaluxChallenge.Text.Infrastructure;
using System.Linq;

namespace MecaluxChallenge.Text.Sort
{
    /// <summary>
    /// Text Sorter based on Word Lenght Ascendent criteria
    /// </summary>
    public class WordLengthSorter : TextSorter
    {

        #region ITextSorter

        protected override string SortText(string textToSort)
        {
            string[] splittedText = textToSort.Split(TextConstants.SPLITTER);
            string[] splittetTextOrdered = splittedText.OrderBy(word => word.Length).ToArray();
            return string.Join(TextConstants.SPLITTER.ToString(), splittetTextOrdered);
        }

        #endregion

    }
}
