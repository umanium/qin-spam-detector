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
            result = tokenizer.tokenizeBigram("Hello darkness my old friend");

            string[] expected = new string[] { "Hello darkness", "darkness my", "my old", "old friend" };
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
