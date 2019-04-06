using MecaluxChallenge.Text.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MecaluxChallenge.Text.Statistics
{
    /// <summary>
    /// Represents a collection of statistic results
    /// </summary>
    public  class TextStatistics : List<ITextCountingStatistic>
    {

        #region constructors

        /// <summary>
        /// protected default contstructor
        /// </summary>
        private TextStatistics() : base() {}
       
        /// <summary>
        /// Initializator constructor
        /// </summary>
        /// <param name="textCountStatistic">Collection of counting statistics results</param>
        public TextStatistics(IEnumerable<ITextCountingStatistic> textCountStatistic) : base(textCountStatistic) { }
        

        #endregion

        #region methods

        /// <summary>
        /// Gets resuls for printing
        /// </summary>
        /// <returns>A String with each result separated by CRLF </returns>
        public String GetPrintableRestuls()
        {
            StringBuilder printableResult = new StringBuilder();

            this.ForEach(result => printableResult.AppendLine(string.Format("Statistic {0} Result {1}", result.GetStatistic().ToString(), result.GetCount().ToString())));

            return printableResult.ToString();
        }
        
        /// <summary>
        /// Get types statistic in result collection
        /// </summary>
        /// <returns>List with non-repeated types statistic <see cref="eStatistics"/></returns>
        public List<eStatistics> GetStatisticsTypes()
        {
            return this.Select(result => result.GetStatistic()).Distinct().ToList();
        }

        /// <summary>
        /// Get all registered result of <see cref="eStatistics"/> type in collection
        /// </summary>
        /// <returns></returns>
        public List<ITextCountingStatistic> GetCountingResultByStatistic(eStatistics typeCountingStatistic)
        {
            return this.Where(result => result.GetStatistic() == typeCountingStatistic).ToList();
        }

        #endregion

    }
}
