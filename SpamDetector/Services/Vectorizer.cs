using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamDetector.Services
{
    public static class Vectorizer
    {
        public static Dictionary<string, int> countVectorizer(string[] tokens)
        {
            Dictionary<string, int> vectors = new Dictionary<string, int>();
            for(int i = 0; i < tokens.Count(); i++)
            {
                if(vectors.ContainsKey(tokens[i]))
                {
                    vectors[tokens[i]] += 1;
                }
                else
                {
                    vectors.Add(tokens[i], 1);
                }
            }

            return vectors;
        }

        public static Dictionary<string, int> countVectorizer(List<string[]> tokens)
        {
            List<string> flatTokens = new List<string>();
            Dictionary<string, int> vectors = new Dictionary<string, int>();
            for (int i = 0; i < tokens.Count(); i++)
            {

                flatTokens.AddRange(tokens[i]);
            }
            vectors = countVectorizer(flatTokens.ToArray());

            return vectors;
        }
    }
}
