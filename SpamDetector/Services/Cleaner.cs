using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpamDetector.Services
{
    public class Cleaner
    {
        public Cleaner() { }
        public string stripNonAscii(string sentence)
        {
            string result = Regex.Replace(sentence, @"[^\u0000-\u007F]+", string.Empty);
            return result;
        }

        public string normalizeAccentedChars(string sentence)
        {
            var newStringBuilder = new StringBuilder();
            newStringBuilder.Append(sentence.Normalize(NormalizationForm.FormKD)
                                            .Where(x => x < 128)
                                            .ToArray());
            return newStringBuilder.ToString();
        }
    }
}
