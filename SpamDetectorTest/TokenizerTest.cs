using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpamDetector.Services;

namespace SpamDetectorTest
{
    [TestClass]
    public class TokenizerTest
    {
        [TestMethod]
        public void TestTokenizeEmptyString()
        {
            Console.WriteLine("It will return empty array");
            Tokenizer tokenizer = new Tokenizer();
            string[] result = new string[] { };
            result = tokenizer.tokenize("");

            string[] expected = new string[] { };
            CollectionAssert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestTokenizerDefault()
        {
            Console.WriteLine("It will tokenize only using blank space as delimiter");
            Tokenizer tokenizer = new Tokenizer();
            string[] result = new string[] { };
            result = tokenizer.tokenize("Hello, World");

            string[] expected = new string[] { "Hello,", "World"};    
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestTokenizerWithSingleDelimiter()
        {
            Console.WriteLine("It will tokenize using a single delimiter");
            Tokenizer tokenizer = new Tokenizer(",");
            string[] result = new string[] { };
            result = tokenizer.tokenize("Hello, World");

            string[] expected = new string[] { "Hello", " World" };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestTokenizerWithMultipleDelimiter()
        {
            Console.WriteLine("It will tokenize using multiple delimiter");
            Tokenizer tokenizer = new Tokenizer(new string[] { " ", "," });
            string[] result = new string[] { };
            result = tokenizer.tokenize("Hello, World");

            string[] expected = new string[] { "Hello", "World" };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestTokenizerBigram()
        {
            Console.WriteLine("It will tokenize strings into bigrams");
            Tokenizer tokenizer = new Tokenizer();
            string[] result = new string[] { };
            result = tokenizer.tokenizeNgram("Hello darkness my old friend", 2);

            string[] expected = new string[] { "Hello darkness", "Hello", "darkness", "darkness my", "my", "my old", "old", "old friend", "friend"};
            CollectionAssert.AreEquivalent(expected, result);
        }

        [TestMethod]
        public void TestTokenizerTrigram()
        {
            Console.WriteLine("It will tokenize strings into trigrams");
            Tokenizer tokenizer = new Tokenizer();
            string[] result = new string[] { };
            result = tokenizer.tokenizeNgram("Hello darkness my old friend", 3);

            string[] expected = new string[] { "Hello darkness", "Hello", "darkness", "darkness my", "my", "my old", "old", "old friend", "friend", "Hello darkness my", "darkness my old", "my old friend" };
            CollectionAssert.AreEquivalent(expected, result);
        }

        [TestMethod]
        public void TestTokenizerSbph2()
        {
            Console.WriteLine("It will tokenize strings into sbph tokens with n=2");
            Tokenizer tokenizer = new Tokenizer();
            string[] result = new string[] { };
            result = tokenizer.tokenizeSbph("Hello darkness my old friend", 2);

            string[] expected = new string[] { "Hello darkness", "Hello", "darkness", "darkness my", "my", "my old", "old", "old friend", "friend" };
            CollectionAssert.AreEquivalent(expected, result);
        }

        [TestMethod]
        public void TestTokenizerSbph3()
        {
            Console.WriteLine("It will tokenize strings into sbph tokens with n=3");
            Tokenizer tokenizer = new Tokenizer();
            string[] result = new string[] { };
            result = tokenizer.tokenizeSbph("Hello darkness my old friend", 3);

            string[] expected = new string[] {
                "Hello darkness", "Hello", "darkness", "darkness my",
                "my", "my old", "old", "old friend", "friend",
                "Hello my", "darkness old", "my friend", "Hello darkness my",
                "darkness my old", "my old friend"
            };
            CollectionAssert.AreEquivalent(expected, result);
        }

        [TestMethod]
        public void TestTokenizerStopWords()
        {
            Console.WriteLine("It will strip stop words from tokenized words");
            Tokenizer tokenizer = new Tokenizer();
            string[] tokenized = new string[] { "Hello", "the", "prisoner", "of", "Azkaban" };
            string[] stopWords = new string[] { "the", "and", "of" };
            string[] result = tokenizer.removeStopWords(tokenized, stopWords);

            string[] expected = new string[] { "Hello", "prisoner", "Azkaban" };
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
