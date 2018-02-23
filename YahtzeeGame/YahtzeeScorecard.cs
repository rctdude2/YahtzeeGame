using System.Collections.Generic;

namespace YahtzeeGame {
    public class YahtzeeScorecard {
        public static readonly int SCORE_FULLHOUSE = 25;
        public static readonly int SCORE_SMALLSTRAIGHT = 30;
        public static readonly int SCORE_LARGESTRAIGHT = 40;
        public static readonly int SCORE_YAHTZEE = 50;
        public static readonly int SCORE_BONUS_UPPER = 35;
        public static readonly int SCORE_BONUS_UPPER_MIN = 63;

        public enum Upper {
            Ones, Twos, Threes, Fours, Fives, Sixes
        }

        public enum Lower {
            ThreeOfAKind, FourOfAKind, FullHouse, SmallStraight, LargeStraight, Yahtzee, Chance
        }

        public Dictionary<Upper, int> ScoreSectionUpper = new Dictionary<Upper, int>() {
            { Upper.Ones, 0 },
            { Upper.Twos, 0 },
            { Upper.Threes, 0 },
            { Upper.Fours, 0 },
            { Upper.Fives, 0 },
            { Upper.Sixes, 0 }
        };

        public Dictionary<Lower, int> ScoreSectionLower = new Dictionary<Lower, int>() {
            { Lower.ThreeOfAKind, 0 },
            { Lower.FourOfAKind, 0 },
            { Lower.FullHouse, 0 },
            { Lower.SmallStraight, 0 },
            { Lower.LargeStraight, 0 },
            { Lower.Yahtzee, 0 },
            { Lower.Chance, 0 }
        };

        public int ScoreTotalUpper {
            get {
                int sum = 0;
                foreach (KeyValuePair<Upper, int> i in ScoreSectionUpper) {
                    sum += i.Value;
                }
                return sum + ScoreBonusUpper;
            }
        }
        public int ScoreTotalLower {
            get {
                int sum = 0;
                foreach (KeyValuePair<Lower, int> i in ScoreSectionLower) {
                    sum += i.Value;
                }
                return sum;
            }
        }
        public int ScoreGrandTotal => ScoreTotalUpper + ScoreTotalLower;
        public int ScoreBonusUpper {
            get {
                int sum = 0;
                foreach (KeyValuePair<Upper, int> i in ScoreSectionUpper) {
                    sum += i.Value;
                }
                return sum >= SCORE_BONUS_UPPER_MIN ? SCORE_BONUS_UPPER : 0;
            }
        }
    }
}
