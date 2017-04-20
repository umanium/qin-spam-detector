using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SpamDetector.Services;

namespace SpamDetectorTest
{
    [TestClass]
    public class VectorizerTest
    {
        [TestMethod]
        public void TestVectorizeSingleArray()
        {
            string[] tokens = new string[] { "she", "says", "that", "she", "heard", "you", "came"};

            Dictionary<string, int> expected = new Dictionary<string, int>
            {
                { "she", 2 },
                { "says", 1 },
                { "that", 1 },
                { "heard", 1 },
                { "you", 1 },
                { "came", 1 }
            };
            CollectionAssert.AreEqual(expected, Vectorizer.countVectorizer(tokens));
        }

        [TestMethod]
        public void TestVectorizeListOfArrays()
        {
            List<string[]> tokens = new List<string[]>();
            tokens.Add(new string[] { "she", "says", "that", "she", "heard", "you", "came" });
            tokens.Add(new string[] { "she", "says", "that", "she", "heard", "you", "came" });
            tokens.Add(new string[] { "she", "says", "that", "she", "heard", "you", "came" });

            Dictionary<string, int> expected = new Dictionary<string, int>
            {
                { "she", 6 },
                { "says", 3 },
                { "that", 3 },
                { "heard", 3 },
                { "you", 3 },
                { "came", 3 }
            };
            CollectionAssert.AreEqual(expected, Vectorizer.countVectorizer(tokens));
        }
    }
}
