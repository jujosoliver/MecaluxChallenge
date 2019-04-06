using Autofac;
using MecaluxChallenge.Text;
using MecaluxChallenge.Text.Enums;
using MecaluxChallenge.Text.Infrastructure;
using MecaluxChallenge.Text.Sort;
using MecaluxChallenge.Text.Statistics;
using System.Collections.Generic;

namespace MecaluxChallenge.DI
{
    public class DIService
    {
        #region fields

        private static DIService instanceService;

        private IContainer container;

        #endregion

        #region "constructors"

        private DIService() {}        

        #endregion

        #region properties

        public static  IContainer ContainerService
        {
            get
            {
                if(DIService.instanceService == null)
                {
                    instanceService = new DIService();
                    instanceService.RegisterTypes();
                    
                }
                return instanceService.container;
            }
        }

        #endregion

        #region methods

        protected virtual void RegisterTypes()
        {
            ContainerBuilder builder = new ContainerBuilder();
            

            builder.RegisterType<WordLengthSorter>().Keyed<ITextSorter>(eSortMode.LenghtAsc);
            builder.RegisterType<AlphabeticAscendentSorter>().Keyed<ITextSorter>(eSortMode.AlphabeticAsc);
            builder.RegisterType<AlphabeticDescendentSorter>().Keyed<ITextSorter>(eSortMode.AlphabeticDesc);


            List<NamedParameter> calculatorsEngine = new List<NamedParameter>();

            calculatorsEngine.Add(new NamedParameter("wordcalculator", new WordCalculator()));
            calculatorsEngine.Add(new NamedParameter("spacecalculator", new SpaceCalculator()));
            calculatorsEngine.Add(new NamedParameter("hyphenscalculator", new HyphensCalculator()));
            builder.RegisterType<EngineCalculator>().As<IEngineCalculator>().WithParameters(calculatorsEngine);

            builder.RegisterType<EngineCalculator>().Named<IEngineCalculator>(TextConstants.DEFAULT_ENGINE);


            builder.RegisterType<WordCalculator>().Keyed<ICountingStatisticCalculator>(eStatistics.WordCount);
            builder.RegisterType<SpaceCalculator>().Keyed<ICountingStatisticCalculator>(eStatistics.SpaceCount);
            builder.RegisterType<HyphensCalculator>().Keyed<ICountingStatisticCalculator>(eStatistics.HyphensCount);

            builder.RegisterType<CountStatistic>().As<ITextCountingStatistic>();

            builder.RegisterType<TextHandler>().As<TextHandler>();
            builder.RegisterType<TextHandlerDI>().As<ITextHandler>();
            this.container = builder.Build();
        }

        #endregion
    }
}
