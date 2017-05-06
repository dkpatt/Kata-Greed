using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        [DataRow("1", 100, DisplayName = "Values {1}")]
        [DataRow("5", 50, DisplayName = "Values {5}")]
        [DataRow("1,1,1", 1000, DisplayName = "Values {1,1,1}")]
        [DataRow("2,2,2", 200, DisplayName = "Values {2,2,2}")]

        public void Given_ValidRoll(string arrayOfDice, int expectedScore)
        {
            List<int> diceValues = arrayOfDice.Split(',').Select(d => int.Parse(d)).ToList();
        
            int score = this.greed.Score(diceValues);

            Assert.AreEqual(expectedScore, score);
        }

        [TestMethod]
        public void Given_InalidRoll_Null()
        {
            int score = this.greed.Score(null);

            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void Given_InalidRoll_Empty()
        {
            List<int> diceValues = new List<int>();

            int score = this.greed.Score(diceValues);

            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void Given_InalidRoll_MoreThan6Dice()
        {
            List<int> diceValues = new List<int>();
            diceValues.Add(1);
            diceValues.Add(1);
            diceValues.Add(1);
            diceValues.Add(1);
            diceValues.Add(1);
            diceValues.Add(1);
            diceValues.Add(1);

            int score = this.greed.Score(diceValues);

            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void Given_InalidRoll_ValueLessThan1()
        {
            List<int> diceValues = new List<int>();
            diceValues.Add(0);

            int score = this.greed.Score(diceValues);

            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void Given_InalidRoll_ValueMoreThan6()
        {
            List<int> diceValues = new List<int>();
            diceValues.Add(23);

            int score = this.greed.Score(diceValues);

            Assert.AreEqual(0, score);
        }

    }
}
