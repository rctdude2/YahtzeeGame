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
        }

        private void ResetGame() {
            ResetRoll();
            scorecard = new YahtzeeScorecard();
            dice = new YahtzeeDice();
            EScoresTabUpper.Text = "Upper: 0";
            EScoresTabLower.Text = "Lower: 0";
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
    }
}
