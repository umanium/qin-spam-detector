using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpamDetector.Services;

namespace SpamDetectorTest
{
    [TestClass]
    public class CleanerTest
    {
        [TestMethod]
        public void TestCleanerNormalizeAccentedWords()
        {
            Cleaner cleaner = new Cleaner();
            string accented = "das Mädchen küssen üben dünn die Prüfung für hálo";

            string expected = "das Madchen kussen uben dunn die Prufung fur halo";
            Assert.AreEqual(expected, cleaner.normalizeAccentedChars(accented));
        }

        [TestMethod]
        public void TestCleanerStripNonAscii()
        {
            Cleaner cleaner = new Cleaner();
            string nonAscii = "søme string";

            string expected = "sme string";
            Assert.AreEqual(expected, cleaner.stripNonAscii(nonAscii));
        }
    }
}
