// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using MecaluxChallenge.Text.Infrastructure;
using MecaluxChallenge.Text.Sort;
using NUnit.Framework;
using System;

namespace MecaluxChallengeTest.Sort
{
    [TestFixture]
    public class WordLenghtSorterTest
    {
        [TestCase("said me number 1", "1")]
        [TestCase("a mechanical problem", "a")]
        [TestCase("veryverylong word in sentence", "in")]
        public void Sort_WithSpaceDelimiterForWords_FirstWordShorter(string textQuery,string expectingWord)
        {
            //Arrange
            ITextSorter lenghtSorter = new WordLengthSorter();

            //Action
            string sorted = lenghtSorter.Sort(textQuery);
            string firstword = sorted.Split(TextConstants.SPLITTER)[0];

            //Assert
            Assert.True(firstword == expectingWord);
        }

        
        [TestCase("veryverylong word in sentence")]
        public void Sort_WithSpaceDelimiterForWords_WordLenghtIsIncremental(string textQuery)
        {
            //Arrange
            ITextSorter lenghtSorter = new WordLengthSorter();

            //Action
            string sorted = lenghtSorter.Sort(textQuery);
            string[] words = sorted.Split(TextConstants.SPLITTER);
            bool incrementalOrder = true;
            for(int i=1; i<words.Length;i++)
            {
                if (words[i - 1].Length > words[i].Length)
                    incrementalOrder = false;
            }

            //Assert
            Assert.IsTrue(incrementalOrder);
        }

        [TestCase("")]
        public void Sort_WithEmptyString_ArgumentException(string textQuery)
        {
            //Arrange
            ITextSorter lenghtSorter = new WordLengthSorter();

            //Action
            Exception ex = Assert.Catch<Exception>(() => lenghtSorter.Sort(textQuery));
 
            //Assert
            StringAssert.Contains(TextConstants.TEXT_EMPTY_ERROR,ex.Message);
        }

        [TestCase(null)]
        public void Sort_WithNullString_NullArgumentException(string textQuery)
        {
            //Arrange
            ITextSorter lenghtSorter = new WordLengthSorter();

            //Action
            Exception ex = Assert.Catch<Exception>(() => lenghtSorter.Sort(textQuery));

            //Assert
            StringAssert.Contains(TextConstants.TEXT_NULL_ERROR, ex.Message);
        }
    }
}
