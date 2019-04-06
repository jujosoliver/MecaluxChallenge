using Autofac;
using MecaluxChallenge.DI;
using MecaluxChallenge.Text;
using MecaluxChallenge.Text.Enums;
using MecaluxChallenge.Text.Sort;
using MecaluxChallenge.Text.Statistics;
using System;

namespace MecaluxChallenge
{
    class Program
    {
        private static Autofac.IContainer Container;

        static void Main(string[] args)
        {
            Container = DIService.ContainerService;

            SolutionWithFullDI();

            Console.WriteLine("********************************");
            Console.WriteLine("********************************");

            SolutionWithDI();

        }


        static void SolutionWithFullDI()
        {
            Console.WriteLine("Hello i need a text, i'm a software very curious");
            Console.WriteLine("Please give me a text and press enter");
            string textQuery = Console.ReadLine();


            ITextHandler textHandler = Container.Resolve<ITextHandler>();

            Console.WriteLine("Now i am going to sort your text: ");

            Console.WriteLine(textHandler.Sort(textQuery, DIService.ContainerService.ResolveKeyed<ITextSorter>(eSortMode.AlphabeticAsc)));
            Console.WriteLine(textHandler.Sort(textQuery, DIService.ContainerService.ResolveKeyed<ITextSorter>(eSortMode.AlphabeticDesc)));
            Console.WriteLine(textHandler.Sort(textQuery, DIService.ContainerService.ResolveKeyed<ITextSorter>(eSortMode.LenghtAsc)));

            Console.WriteLine("Now i am going to get some Statistics: ");
            TextStatistics statistics = textHandler.GetStatistics(textQuery);
            Console.WriteLine(statistics.GetPrintableRestuls());

            Console.WriteLine("Ops, it's time to go...");
            Console.ReadKey();
        }

        static void SolutionWithDI()
        {
            Console.WriteLine("Hello i need a text, i'm a software very curious");
            Console.WriteLine("Please give me a text and press enter");
            string textQuery = Console.ReadLine();


            TextHandler textHandler = Container.Resolve<TextHandler>();

            Console.WriteLine("Now i am going to sort your text: ");

            Console.WriteLine(textHandler.Sort(textQuery, eSortMode.AlphabeticAsc));
            Console.WriteLine(textHandler.Sort(textQuery, eSortMode.AlphabeticDesc));
            Console.WriteLine(textHandler.Sort(textQuery, eSortMode.LenghtAsc));

            Console.WriteLine("Now i am going to get some Statistics: ");
            TextStatistics statistics = textHandler.GetStatistics(textQuery);
            Console.WriteLine(statistics.GetPrintableRestuls());

            Console.WriteLine("Ops, it's time to go...");
            Console.ReadKey();
        }
    }
}
