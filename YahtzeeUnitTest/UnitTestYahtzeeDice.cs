using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YahtzeeGame;

namespace YahtzeeUnitTest {
    [TestClass]
    public class UnitTestYahtzeeDice {
        [TestMethod]
        public void Test_ScoreAces() {
            int expectedScore = 5;
            int[] numbers = new int[] { 1, 1, 1, 1, 1 };

            FakeNumberGen fakeNumberGen = new FakeNumberGen(numbers);
            YahtzeeDice dice = new YahtzeeDice(fakeNumberGen);

            dice.Roll();

            YahtzeeScorecard scores = dice.CalculateScores();

            Assert.AreEqual(expectedScore, scores.ScoreSectionUpper[YahtzeeScorecard.Upper.Ones]);
        }

        [TestMethod]
        public void Test_ScoreTwos() {
            int expectedScore = 8;
            int[] numbers = new int[] { 1, 2, 2, 2, 2 };

            FakeNumberGen fakeNumberGen = new FakeNumberGen(numbers);
            YahtzeeDice dice = new YahtzeeDice(fakeNumberGen);

            dice.Roll();

            YahtzeeScorecard scores = dice.CalculateScores();

            Assert.AreEqual(expectedScore, scores.ScoreSectionUpper[YahtzeeScorecard.Upper.Twos]);
        }

        [TestMethod]
        public void Test_ScoreThrees() {
            int expectedScore = 15;
            int[] numbers = new int[] { 3, 3, 3, 3, 3 };

            FakeNumberGen fakeNumberGen = new FakeNumberGen(numbers);
            YahtzeeDice dice = new YahtzeeDice(fakeNumberGen);

            dice.Roll();

            YahtzeeScorecard scores = dice.CalculateScores();

            Assert.AreEqual(expectedScore, scores.ScoreSectionUpper[YahtzeeScorecard.Upper.Threes]);
        }

        [TestMethod]
        public void Test_ScoreFours() {
            int expectedScore = 16;
            int[] numbers = new int[] { 4, 4, 4, 4, 2 };

            FakeNumberGen fakeNumberGen = new FakeNumberGen(numbers);
            YahtzeeDice dice = new YahtzeeDice(fakeNumberGen);

            dice.Roll();

            YahtzeeScorecard scores = dice.CalculateScores();

            Assert.AreEqual(expectedScore, scores.ScoreSectionUpper[YahtzeeScorecard.Upper.Fours]);
        }

        [TestMethod]
        public void Test_ScoreFives() {
            int expectedScore = 25;
            int[] numbers = new int[] { 5, 5, 5, 5, 5 };

            FakeNumberGen fakeNumberGen = new FakeNumberGen(numbers);
            YahtzeeDice dice = new YahtzeeDice(fakeNumberGen);

            dice.Roll();

            YahtzeeScorecard scores = dice.CalculateScores();

            Assert.AreEqual(expectedScore, scores.ScoreSectionUpper[YahtzeeScorecard.Upper.Fives]);
        }

        [TestMethod]
        public void Test_ScoreSixes() {
            int expectedScore = 30;
            int[] numbers = new int[] { 6, 6, 6, 6, 6 };

            FakeNumberGen fakeNumberGen = new FakeNumberGen(numbers);
            YahtzeeDice dice = new YahtzeeDice(fakeNumberGen);

            dice.Roll();

            YahtzeeScorecard scores = dice.CalculateScores();

            Assert.AreEqual(expectedScore, scores.ScoreSectionUpper[YahtzeeScorecard.Upper.Sixes]);
        }

        [TestMethod]
        public void Test_ScoreThreeOfAKind() {
            int expectedScore = 30;
            int[] numbers = new int[] { 6, 6, 6, 6, 6 };

            FakeNumberGen fakeNumberGen = new FakeNumberGen(numbers);
            YahtzeeDice dice = new YahtzeeDice(fakeNumberGen);

            dice.Roll();

            YahtzeeScorecard scores = dice.CalculateScores();

            Assert.AreEqual(expectedScore, scores.ScoreSectionLower[YahtzeeScorecard.Lower.ThreeOfAKind]);
        }

        [TestMethod]
        public void Test_ScoreFourOfAKind() {
            int expectedScore = 21;
            int[] numbers = new int[] { 5, 5, 5, 5, 1 };

            FakeNumberGen fakeNumberGen = new FakeNumberGen(numbers);
            YahtzeeDice dice = new YahtzeeDice(fakeNumberGen);

            dice.Roll();

            YahtzeeScorecard scores = dice.CalculateScores();

            // Dice match both three and four of a kind
            Assert.AreEqual(expectedScore, scores.ScoreSectionLower[YahtzeeScorecard.Lower.ThreeOfAKind]);
            Assert.AreEqual(expectedScore, scores.ScoreSectionLower[YahtzeeScorecard.Lower.FourOfAKind]);
        }

        [TestMethod]
        public void Test_ScoreFullHouse() {
            int expectedScore = YahtzeeScorecard.SCORE_FULLHOUSE;
            int[] numbers = new int[] { 2, 2, 5, 5, 5 };

            FakeNumberGen fakeNumberGen = new FakeNumberGen(numbers);
            YahtzeeDice dice = new YahtzeeDice(fakeNumberGen);

            dice.Roll();

            YahtzeeScorecard scores = dice.CalculateScores();
            
            Assert.AreEqual(expectedScore, scores.ScoreSectionLower[YahtzeeScorecard.Lower.FullHouse]);
        }

        [TestMethod]
        public void Test_ScoreSmallStraight() {
            int expectedScore = YahtzeeScorecard.SCORE_SMALLSTRAIGHT;
            int[] numbers = new int[] { 1, 2, 4, 3, 6 };

            FakeNumberGen fakeNumberGen = new FakeNumberGen(numbers);
            YahtzeeDice dice = new YahtzeeDice(fakeNumberGen);

            dice.Roll();

            YahtzeeScorecard scores = dice.CalculateScores();

            Assert.AreEqual(expectedScore, scores.ScoreSectionLower[YahtzeeScorecard.Lower.SmallStraight]);
        }

        [TestMethod]
        public void Test_ScoreLargeStraight() {
            int expectedScore = YahtzeeScorecard.SCORE_LARGESTRAIGHT;
            int[] numbers = new int[] { 1, 2, 4, 3, 5 };

            FakeNumberGen fakeNumberGen = new FakeNumberGen(numbers);
            YahtzeeDice dice = new YahtzeeDice(fakeNumberGen);

            dice.Roll();

            YahtzeeScorecard scores = dice.CalculateScores();

            Assert.AreEqual(expectedScore, scores.ScoreSectionLower[YahtzeeScorecard.Lower.LargeStraight]);
        }

        [TestMethod]
        public void Test_ScoreYahtzee() {
            int expectedScore = YahtzeeScorecard.SCORE_YAHTZEE;
            int[] numbers = new int[] { 6, 6, 6, 6, 5 };

            FakeNumberGen fakeNumberGen = new FakeNumberGen(numbers);
            YahtzeeDice dice = new YahtzeeDice(fakeNumberGen);

            dice.Roll();

            YahtzeeScorecard scores = dice.CalculateScores();

            Assert.AreNotEqual(expectedScore, scores.ScoreSectionLower[YahtzeeScorecard.Lower.Yahtzee]);
        }

        [TestMethod]
        public void Test_ScoreChance() {
            int expectedScore = 15;
            int[] numbers = new int[] { 1, 2, 4, 3, 5 };

            FakeNumberGen fakeNumberGen = new FakeNumberGen(numbers);
            YahtzeeDice dice = new YahtzeeDice(fakeNumberGen);

            dice.Roll();

            YahtzeeScorecard scores = dice.CalculateScores();

            Assert.AreEqual(expectedScore, scores.ScoreSectionLower[YahtzeeScorecard.Lower.Chance]);
        }
    }
}
