using MecaluxChallenge.Text.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MecaluxChallenge.Text.Statistics
{
    /// <summary>
    /// abstraction of engine for calculate statistics. 
    /// Model a collection of calculators which execute sequentially.
    /// Base implementation of IEngineCalculator
    /// </summary>
    public class EngineCalculator : IEngineCalculator
    {
        #region field

        private readonly List<ICountingStatisticCalculator> statisticCalculators;

        #endregion

        #region constructors

        /// <summary>
        /// default constructor
        /// </summary>
        public EngineCalculator()
        {
            this.statisticCalculators = new List<ICountingStatisticCalculator>();
        }

        /// <summary>
        /// parametrized constructor with a default statistic calculator
        /// </summary>
        /// <param name="wordcalculator"></param>
        public EngineCalculator(ICountingStatisticCalculator wordcalculator, ICountingStatisticCalculator spacecalculator, ICountingStatisticCalculator hyphenscalculator) : this()
        {
            this.statisticCalculators.Add(wordcalculator);
            this.statisticCalculators.Add(spacecalculator);
            this.statisticCalculators.Add(hyphenscalculator);
        }

        #endregion
       
        #region IEngineCalculator

        void IEngineCalculator.RegisterStatisticCalculator(ICountingStatisticCalculator calculator)
        {
            if (calculator == null) throw new ArgumentNullException(TextConstants.TEXT_NULL_ERROR);

            this.statisticCalculators.Add(calculator);
        }

        TextStatistics IEngineCalculator.Calculate(string queryText)
        {

            return new TextStatistics(this.statisticCalculators.Select(calculator => calculator.GetStatistics(queryText)).ToArray());
        }
    
        #endregion


    }
}
