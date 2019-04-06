using MecaluxChallenge.Text.Infrastructure;
using System;

namespace MecaluxChallenge.Text.Sort
{
    /// <summary>
    /// abstract TextSorter class to encapsulate common pre-conditions
    /// </summary>
    public abstract class TextSorter : ITextSorter
    {

        #region methods

        abstract protected string SortText(string textToSort);

        #endregion  

        #region ITextSorter

        string ITextSorter.Sort(string textToSort)
        {
            if (textToSort == null) throw new ArgumentNullException(TextConstants.TEXT_NULL_ERROR);
            if (textToSort == string.Empty) throw new ArgumentException(TextConstants.TEXT_EMPTY_ERROR);

            return this.SortText(textToSort);
        }

        #endregion
    }
}
