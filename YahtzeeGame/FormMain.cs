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
        }

        private void ResetGame() {
            ResetRoll();
            scorecard = new YahtzeeScorecard();
            dice = new YahtzeeDice();
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

        private void EDiceRoll_Click(object sender, EventArgs e) {
            if (dice.CanRoll()) {
                dice.Roll();
                EDiceRollNumber.Text = $"Roll {dice.RollCount}";

                int i = 0;
                foreach (PictureBox ctrl in EDiceDieGroup.Controls) {
                    ctrl.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject($"die{dice[i++]}");
                }
            }
        }
    }
}
