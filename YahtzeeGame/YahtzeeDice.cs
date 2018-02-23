using System.Collections.Generic;

namespace YahtzeeGame {
    public class YahtzeeDice {
        private List<int> dice;
        public int RollCount { get; set; }
        private IRNG numberGenerator;

        public bool HoldDie1 { get; set; }
        public bool HoldDie2 { get; set; }
        public bool HoldDie3 { get; set; }
        public bool HoldDie4 { get; set; }
        public bool HoldDie5 { get; set; }

        public int this[int i] {
            get { return this.dice[i];  }
        }

        public YahtzeeDice() : this(new NumberGen()) {}

        public YahtzeeDice(IRNG generator) {
            numberGenerator = generator;
            RollCount = 0;
            dice = new List<int>() { 0, 0, 0, 0, 0 };
        }

        public void Roll() {
            RollCount++;
            
            if (RollCount <= 3) {
                bool[] diceToHold = new bool[] { HoldDie1, HoldDie2, HoldDie3, HoldDie4, HoldDie5 };

                for (int i = 0; i < dice.Count; i++) {
                    if (!diceToHold[i]) {
                        dice[i] = numberGenerator.Next(1, 7);
                    }
                }
            }
        }

        private int SumAllDice() {
            int sum = 0;

            foreach (int die in dice) {
                sum += die;
            }

            return sum;
        }

        public YahtzeeScorecard CalculateScores() {
            YahtzeeScorecard scorecard = new YahtzeeScorecard();
            List<int> dieRollCount = new List<int>() { 0, 0, 0, 0, 0, 0 };

            foreach (int die in dice) {
                dieRollCount[die - 1]++;
            }

            for (int i = 0; i < dieRollCount.Count; i++) {
                scorecard.ScoreSectionUpper[(YahtzeeScorecard.Upper)i] = dieRollCount[i] * (i + 1);
            }

            // Three of a Kind
            if (dieRollCount.Contains(3)) {
                scorecard.ScoreSectionLower[YahtzeeScorecard.Lower.ThreeOfAKind] = SumAllDice();
            }

            // Four of a Kind
            if (dieRollCount.Contains(4)) {
                scorecard.ScoreSectionLower[YahtzeeScorecard.Lower.ThreeOfAKind] = SumAllDice();
                scorecard.ScoreSectionLower[YahtzeeScorecard.Lower.FourOfAKind] = SumAllDice();
            }

            // Full House
            if (dieRollCount.Contains(3) && dieRollCount.Contains(2)) {
                scorecard.ScoreSectionLower[YahtzeeScorecard.Lower.FullHouse] = YahtzeeScorecard.SCORE_FULLHOUSE;
            }

            // Small Straight
            if (dice.Contains(3) && dice.Contains(4)) {
                if ((dice.Contains(1) && dice.Contains(2)) ||
                    (dice.Contains(2) && dice.Contains(5)) ||
                    (dice.Contains(5) && dice.Contains(6))) {
                    scorecard.ScoreSectionLower[YahtzeeScorecard.Lower.SmallStraight] = YahtzeeScorecard.SCORE_SMALLSTRAIGHT;
                }
            }

            // Large Straight
            if ((dice.Contains(1) && dice.Contains(2) && dice.Contains(3) && dice.Contains(4) && dice.Contains(5)) ||
                (dice.Contains(2) && dice.Contains(3) && dice.Contains(4) && dice.Contains(5) && dice.Contains(6))) {
                scorecard.ScoreSectionLower[YahtzeeScorecard.Lower.LargeStraight] = YahtzeeScorecard.SCORE_LARGESTRAIGHT;
            }

            // Yahtzee
            if (dieRollCount.Contains(5)) {
                scorecard.ScoreSectionLower[YahtzeeScorecard.Lower.ThreeOfAKind] = SumAllDice();
                scorecard.ScoreSectionLower[YahtzeeScorecard.Lower.FourOfAKind] = SumAllDice();
                scorecard.ScoreSectionLower[YahtzeeScorecard.Lower.Yahtzee] = YahtzeeScorecard.SCORE_YAHTZEE;
            }

            // Chance
            scorecard.ScoreSectionLower[YahtzeeScorecard.Lower.Chance] = SumAllDice();

            return scorecard;
        }
    }
}
