using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamDetector.Services
{
    public class Tokenizer
    {
        private string[] delimiters;
        public Tokenizer()
        {
            delimiters = new string[] { " " };
        }
        public Tokenizer(string singleDelimiter)
        {
            delimiters = new string[] { singleDelimiter };
        }
        public Tokenizer(string[] multipleDelimiter)
        {
            delimiters = multipleDelimiter;
        }

        public string[] tokenize(string sentence)
        {
            return sentence.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }

        public string[] tokenizeBigram(string sentence)
        {
            string[] unigram = this.tokenize(sentence);
            string[] bigram = new string[unigram.Count() - 1];
            for(int i = 0; i < unigram.Count() - 1; i++)
            {
                bigram[i] = unigram[i] + " " + unigram[i + 1];
            }
            return bigram;
        }
    }
}
