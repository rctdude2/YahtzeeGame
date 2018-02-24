using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YahtzeeGame {
    public partial class FormMain : Form {
        YahtzeeScorecard scorecard;
        YahtzeeDice dice;

        public FormMain() {
            InitializeComponent();
            scorecard = new YahtzeeScorecard();
            dice = new YahtzeeDice();
        }

        private void ResetRoll() {
            foreach (PictureBox ctrl in EDiceDieGroup.Controls) {
                ctrl.Image = Properties.Resources.die0;
            }
            dice.RollCount = 0;
            EDiceRollNumber.Text = $"Roll {dice.RollCount}";
            foreach (CheckBox ctrl in EDiceKeepGroup.Controls) {
                ctrl.Checked = false;
            }
            EDiceRollButton.Enabled = true;
        }

        private void ResetGame() {
            ResetRoll();
            scorecard = new YahtzeeScorecard();
            dice = new YahtzeeDice();
            EScoresTabUpper.Text = "Upper: 0";
            EScoresTabLower.Text = "Lower: 0";
            foreach (Control ctrl in EScoresTabUpper.Controls) {
                ctrl.Enabled = true;
            }
            foreach (Control ctrl in EScoresTabLower.Controls) {
                ctrl.Enabled = true;
            }
            foreach (Control ctrl in EScoresUpperGroup.Controls) {
                ctrl.Text = "0";
            }
            foreach (Control ctrl in EScoresLowerGroup.Controls) {
                ctrl.Text = "0";
            }
        }

        private void EDiceKeep1_CheckedChanged(object sender, EventArgs e) {
            dice.HoldDie1 = EDiceKeep1.CheckState == CheckState.Checked ? true : false;
        }

        private void EDiceKeep2_CheckedChanged(object sender, EventArgs e) {
            dice.HoldDie2 = EDiceKeep2.CheckState == CheckState.Checked ? true : false;
        }

        private void EDiceKeep3_CheckedChanged(object sender, EventArgs e) {
            dice.HoldDie3 = EDiceKeep3.CheckState == CheckState.Checked ? true : false;
        }

        private void EDiceKeep4_CheckedChanged(object sender, EventArgs e) {
            dice.HoldDie4 = EDiceKeep4.CheckState == CheckState.Checked ? true : false;
        }

        private void EDiceKeep5_CheckedChanged(object sender, EventArgs e) {
            dice.HoldDie5 = EDiceKeep5.CheckState == CheckState.Checked ? true : false;
        }

        private void EDiceRollButton_Click(object sender, EventArgs e) {
            if (dice.CanRoll()) {
                dice.Roll();
                YahtzeeScorecard scores = dice.CalculateScores();
                EDiceRollNumber.Text = $"Roll {dice.RollCount}";

                int i = 0;
                foreach (PictureBox ctrl in EDiceDieGroup.Controls) {
                    ctrl.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject($"die{dice[i++]}");
                }

                if (EScoresUpperAcesButton.Enabled) {
                    EScoresUpperAces.Text = scores.ScoreSectionUpper[YahtzeeScorecard.Upper.Ones].ToString();
                }
                if (EScoresUpperTwosButton.Enabled) {
                    EScoresUpperTwos.Text = scores.ScoreSectionUpper[YahtzeeScorecard.Upper.Twos].ToString();
                }
                if (EScoresUpperThreesButton.Enabled) {
                    EScoresUpperThrees.Text = scores.ScoreSectionUpper[YahtzeeScorecard.Upper.Threes].ToString();
                }
                if (EScoresUpperFoursButton.Enabled) {
                    EScoresUpperFours.Text = scores.ScoreSectionUpper[YahtzeeScorecard.Upper.Fours].ToString();
                }
                if (EScoresUpperFivesButton.Enabled) {
                    EScoresUpperFives.Text = scores.ScoreSectionUpper[YahtzeeScorecard.Upper.Fives].ToString();
                }
                if (EScoresUpperSixesButton.Enabled) {
                    EScoresUpperSixes.Text = scores.ScoreSectionUpper[YahtzeeScorecard.Upper.Sixes].ToString();
                }
                if (EScoresLowerThreeKindButton.Enabled) {
                    EScoresLowerThreeKind.Text = scores.ScoreSectionLower[YahtzeeScorecard.Lower.ThreeOfAKind].ToString();
                }
                if (EScoresLowerFourKindButton.Enabled) {
                    EScoresLowerFourKind.Text = scores.ScoreSectionLower[YahtzeeScorecard.Lower.FourOfAKind].ToString();
                }
                if (EScoresLowerFullHouseButton.Enabled) {
                    EScoresLowerFullHouse.Text = scores.ScoreSectionLower[YahtzeeScorecard.Lower.FullHouse].ToString();
                }
                if (EScoresLowerSmallStraightButton.Enabled) {
                    EScoresLowerSmallStraight.Text = scores.ScoreSectionLower[YahtzeeScorecard.Lower.SmallStraight].ToString();
                }
                if (EScoresLowerLargeStraightButton.Enabled) {
                    EScoresLowerLargeStraight.Text = scores.ScoreSectionLower[YahtzeeScorecard.Lower.LargeStraight].ToString();
                }
                if (EScoresLowerYahtzeeButton.Enabled) {
                    EScoresLowerYahtzee.Text = scores.ScoreSectionLower[YahtzeeScorecard.Lower.Yahtzee].ToString();
                }
                if (EScoresLowerChanceButton.Enabled) {
                    EScoresLowerChance.Text = scores.ScoreSectionLower[YahtzeeScorecard.Lower.Chance].ToString();
                }

                if (!dice.CanRoll()) {
                    EDiceRollButton.Enabled = false;
                }
            }
        }

        private void EScoresUpperAcesButton_Click(object sender, EventArgs e) {
            scorecard.ScoreSectionUpper[YahtzeeScorecard.Upper.Ones] = dice.CalculateScores().ScoreSectionUpper[YahtzeeScorecard.Upper.Ones];
            EScoresTabUpper.Text = $"Upper: {scorecard.ScoreTotalUpper}";
            EScoresUpperAcesButton.Enabled = false;
            ResetRoll();
        }

        private void EScoresUpperTwosButton_Click(object sender, EventArgs e) {
            scorecard.ScoreSectionUpper[YahtzeeScorecard.Upper.Twos] = dice.CalculateScores().ScoreSectionUpper[YahtzeeScorecard.Upper.Twos];
            EScoresTabUpper.Text = $"Upper: {scorecard.ScoreTotalUpper}";
            EScoresUpperTwosButton.Enabled = false;
            ResetRoll();
        }

        private void EScoresUpperThreesButton_Click(object sender, EventArgs e) {
            scorecard.ScoreSectionUpper[YahtzeeScorecard.Upper.Threes] = dice.CalculateScores().ScoreSectionUpper[YahtzeeScorecard.Upper.Threes];
            EScoresTabUpper.Text = $"Upper: {scorecard.ScoreTotalUpper}";
            EScoresUpperThreesButton.Enabled = false;
            ResetRoll();
        }

        private void EScoresUpperFoursButton_Click(object sender, EventArgs e) {
            scorecard.ScoreSectionUpper[YahtzeeScorecard.Upper.Fours] = dice.CalculateScores().ScoreSectionUpper[YahtzeeScorecard.Upper.Fours];
            EScoresTabUpper.Text = $"Upper: {scorecard.ScoreTotalUpper}";
            EScoresUpperFoursButton.Enabled = false;
            ResetRoll();
        }

        private void EScoresUpperFivesButton_Click(object sender, EventArgs e) {
            scorecard.ScoreSectionUpper[YahtzeeScorecard.Upper.Fives] = dice.CalculateScores().ScoreSectionUpper[YahtzeeScorecard.Upper.Fives];
            EScoresTabUpper.Text = $"Upper: {scorecard.ScoreTotalUpper}";
            EScoresUpperFivesButton.Enabled = false;
            ResetRoll();
        }

        private void EScoresUpperSixesButton_Click(object sender, EventArgs e) {
            scorecard.ScoreSectionUpper[YahtzeeScorecard.Upper.Sixes] = dice.CalculateScores().ScoreSectionUpper[YahtzeeScorecard.Upper.Sixes];
            EScoresTabUpper.Text = $"Upper: {scorecard.ScoreTotalUpper}";
            EScoresUpperSixesButton.Enabled = false;
            ResetRoll();
        }

        private void EScoresUpperThreeKindButton_Click(object sender, EventArgs e) {
            scorecard.ScoreSectionLower[YahtzeeScorecard.Lower.ThreeOfAKind] = dice.CalculateScores().ScoreSectionLower[YahtzeeScorecard.Lower.ThreeOfAKind];
            EScoresTabLower.Text = $"Lower: {scorecard.ScoreTotalLower}";
            EScoresLowerThreeKindButton.Enabled = false;
            ResetRoll();
        }

        private void EScoresLowerFourKindButton_Click(object sender, EventArgs e) {
            scorecard.ScoreSectionLower[YahtzeeScorecard.Lower.FourOfAKind] = dice.CalculateScores().ScoreSectionLower[YahtzeeScorecard.Lower.FourOfAKind];
            EScoresTabLower.Text = $"Lower: {scorecard.ScoreTotalLower}";
            EScoresLowerFourKindButton.Enabled = false;
            ResetRoll();
        }

        private void EScoresLowerFullHouseButton_Click(object sender, EventArgs e) {
            scorecard.ScoreSectionLower[YahtzeeScorecard.Lower.FullHouse] = dice.CalculateScores().ScoreSectionLower[YahtzeeScorecard.Lower.FullHouse];
            EScoresTabLower.Text = $"Lower: {scorecard.ScoreTotalLower}";
            EScoresLowerFullHouseButton.Enabled = false;
            ResetRoll();
        }

        private void EScoresLowerSmallStraightButton_Click(object sender, EventArgs e) {
            scorecard.ScoreSectionLower[YahtzeeScorecard.Lower.SmallStraight] = dice.CalculateScores().ScoreSectionLower[YahtzeeScorecard.Lower.SmallStraight];
            EScoresTabLower.Text = $"Lower: {scorecard.ScoreTotalLower}";
            EScoresLowerSmallStraightButton.Enabled = false;
            ResetRoll();
        }

        private void EScoresLowerLargeStraightButton_Click(object sender, EventArgs e) {
            scorecard.ScoreSectionLower[YahtzeeScorecard.Lower.LargeStraight] = dice.CalculateScores().ScoreSectionLower[YahtzeeScorecard.Lower.LargeStraight];
            EScoresTabLower.Text = $"Lower: {scorecard.ScoreTotalLower}";
            EScoresLowerLargeStraightButton.Enabled = false;
            ResetRoll();
        }

        private void EScoresLowerYahtzeeButton_Click(object sender, EventArgs e) {
            scorecard.ScoreSectionLower[YahtzeeScorecard.Lower.Yahtzee] = dice.CalculateScores().ScoreSectionLower[YahtzeeScorecard.Lower.Yahtzee];
            EScoresTabLower.Text = $"Lower: {scorecard.ScoreTotalLower}";
            EScoresLowerYahtzeeButton.Enabled = false;
            ResetRoll();
        }

        private void EScoresLowerChanceButton_Click(object sender, EventArgs e) {
            scorecard.ScoreSectionLower[YahtzeeScorecard.Lower.Chance] = dice.CalculateScores().ScoreSectionLower[YahtzeeScorecard.Lower.Chance];
            EScoresTabLower.Text = $"Lower: {scorecard.ScoreTotalLower}";
            EScoresLowerChanceButton.Enabled = false;
            ResetRoll();
        }

        private void EMainMenuItemsFileExit_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Are you sure you want to quit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes) {
                Application.Exit();
            }
        }

        private void EMainMenuItemsGameNewGame_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Are you sure you want to start a new game?", "New Game", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes) {
                ResetGame();
            }
        }
    }
}
