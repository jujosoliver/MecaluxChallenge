namespace MecaluxChallenge.Text.Sort
{
    /// <summary>
    /// Abstraction of object to sort text
    /// </summary>
    public interface ITextSorter
    {
        /// <summary>
        /// Sorts a text
        /// </summary>
        /// <param name="textToSort">string that represents TextToSort</param>
        /// <returns>string that represents sorted text</returns>
        string Sort(string textToSort); 
    }
}
