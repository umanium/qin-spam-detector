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

        public string[] tokenizeNgram(string sentence, int n)
        {
            string[] unigram = this.tokenize(sentence);
            List<string> ngramList = new List<string>();
            for(int i = 0; i < unigram.Count(); i++)
            {
                ngramList.Add(unigram[i]);
                for(int j = 1; j < n; j++)
                {
                    if(i + j < unigram.Count())
                    {
                        string newgram = unigram[i];
                        for(int k = 0; k < j; k++)
                        {
                            newgram += " " + unigram[i + (k + 1)];
                        }
                        ngramList.Add(newgram);
                    }
                }
            }
            return ngramList.ToArray();
        }

        public string[] tokenizeSbph(string sentence, int n)
        {
            List<string> tokenList = new List<string>();

            return tokenList.ToArray();
        }

        public string[] removeStopWords(string[] wordList, string[] stopWords)
        {
            List<string> result = new List<string>();
            for(int i = 0; i < wordList.Count(); i++)
            {
                if(!Array.Exists(stopWords, word => word == wordList[i]))
                {
                    result.Add(wordList[i]);
                }
            }

            return result.ToArray();
        }
    }
}
