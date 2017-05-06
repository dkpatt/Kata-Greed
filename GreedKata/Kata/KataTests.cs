using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata
{
    [TestClass]
    public class KataTests
    {
        private Greed greed;

        [TestInitialize]
        public void Setup()
        {
            this.greed = new Greed();
        }

        [TestMethod]
        public void Given_SingleOne()
        {
            var diceValues = new int[] { 1 };

            int score = this.greed.Score(diceValues);

            Assert.AreEqual(100, score);
        }
    }
}
