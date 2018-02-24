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

        private void EDiceKeep1_CheckedChanged(object sender, EventArgs e) {
            if (EDiceKeep1.CheckState == CheckState.Checked) {
                dice.HoldDie1 = true;
            }
            else {
                dice.HoldDie1 = false;
            }
        }

        private void EDiceKeep2_CheckedChanged(object sender, EventArgs e) {
            if (EDiceKeep2.CheckState == CheckState.Checked) {
                dice.HoldDie2 = true;
            }
            else {
                dice.HoldDie2 = false;
            }
        }

        private void EDiceKeep3_CheckedChanged(object sender, EventArgs e) {
            if (EDiceKeep3.CheckState == CheckState.Checked) {
                dice.HoldDie3 = true;
            }
            else {
                dice.HoldDie3 = false;
            }
        }

        private void EDiceKeep4_CheckedChanged(object sender, EventArgs e) {
            if (EDiceKeep4.CheckState == CheckState.Checked) {
                dice.HoldDie4 = true;
            }
            else {
                dice.HoldDie4 = false;
            }
        }

        private void EDiceKeep5_CheckedChanged(object sender, EventArgs e) {
            if (EDiceKeep5.CheckState == CheckState.Checked) {
                dice.HoldDie5 = true;
            }
            else {
                dice.HoldDie5 = false;
            }
        }

        private void EDiceRoll_Click(object sender, EventArgs e) {
            if (dice.CanRoll()) {
                dice.Roll();
                EDiceRollNumber.Text = $"Roll {dice.RollCount}";
                EDiceDie1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject($"die{dice[0]}");
                EDiceDie2.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject($"die{dice[1]}");
                EDiceDie3.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject($"die{dice[2]}");
                EDiceDie4.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject($"die{dice[3]}");
                EDiceDie5.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject($"die{dice[4]}");
            }
        }
    }
}
