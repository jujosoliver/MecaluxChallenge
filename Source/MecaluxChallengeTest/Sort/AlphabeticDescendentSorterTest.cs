using MecaluxChallenge.Text.Infrastructure;
using MecaluxChallenge.Text.Sort;
using NUnit.Framework;
using System;
using System.Linq;

namespace MecaluxChallengeTest.Sort
{
    [TestFixture]
    public class AlphabeticDescendentSorterTest
    {

        [TestCase("Take a piece of advice", "a")]
        [TestCase("Take A piece of advice", "A")]
        public void Sort_WithSpaceWordDelimiter_LastWordHasLetter_A(string textQuery, string expectingWord)
        {
            //Arrange
            ITextSorter alphabeticSorter = new AlphabeticDescendentSorter();

            //Action
            string sorted = alphabeticSorter.Sort(textQuery);
            string firstword = sorted.Split(TextConstants.SPLITTER).Last();

            //Assert
            //Assert
            Assert.True(firstword == expectingWord);
        }

        [TestCase("I like movie World War Z", "Z")]
        [TestCase("I like movie World War z", "z")]
        public void Sort_WithSpaceWordDelimiter_FirstWordHasLetter_Z(string textQuery, string expectingWord)
        {
            //Arrange
            ITextSorter alphabeticSorter = new AlphabeticDescendentSorter();

            //Action
            string sorted = alphabeticSorter.Sort(textQuery);
            string firstword = sorted.Split(TextConstants.SPLITTER).First();

            //Assert
            //Assert
            Assert.True(firstword == expectingWord);
        }


        [TestCase("veryverylong word in sentence")]
        public void Sort_WithSpaceDelimiterForWords_WordAlphabeticalAscendant(string textQuery)
        {
            //Arrange
            ITextSorter alphabeticSorter = new AlphabeticDescendentSorter();


            //Action
            string sorted = alphabeticSorter.Sort(textQuery);
            string[] words = sorted.Split(TextConstants.SPLITTER);
            bool incrementalOrder = true;
            for (int i = 1; i < words.Length; i++)
            {
                if (words[i - 1][0] < words[i][0])
                    incrementalOrder = false;
            }

            //Assert
            Assert.IsTrue(incrementalOrder);
        }


        [TestCase("")]
        public void Sort_WithEmptyString_ArgumentException(string textQuery)
        {
            //Arrange
            ITextSorter alphabeticSorter = new AlphabeticDescendentSorter();

            //Action
            Exception ex = Assert.Catch<Exception>(() => alphabeticSorter.Sort(textQuery));

            //Assert
            StringAssert.Contains(TextConstants.TEXT_EMPTY_ERROR, ex.Message);
        }

        [TestCase(null)]
        public void Sort_WithNullString_NullArgumentException(string textQuery)
        {
            //Arrange
            ITextSorter alphabeticSorter = new AlphabeticDescendentSorter();

            //Action
            Exception ex = Assert.Catch<Exception>(() => alphabeticSorter.Sort(textQuery));

            //Assert
            StringAssert.Contains(TextConstants.TEXT_NULL_ERROR, ex.Message);
        }
    }
}
