using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG_PoE
{
    public partial class PassiveTree : Form
    {
        Playerstats player = new Playerstats();
        Gamecontroller gc;
        public PassiveTree(Gamecontroller gc)
        {
            InitializeComponent();
            this.gc = gc;
            SetAllLabels();
            OpenAlreadyAllocated();
        }

        private void OpenAlreadyAllocated()
        {
            //attack group
            Button bt = new Button();
            if (gc.Player.Dmg1 == 5)
            {
                bt.Tag = 1;
                Setbuttonsinattack(bt.Tag);
            }
            if (gc.Player.Dmg2 == 5)
            {
                bt.Tag = 2;
                Setbuttonsinattack(bt.Tag);
            }
            if (gc.Player.Dmglesslife == 5)
            {
                bt.Tag = 3;
                Setbuttonsinattack(bt.Tag);
            }
            if (gc.Player.Lifesteal1 == 5)
            {
                bt.Tag = 1;
                Setbuttonsinattack(bt.Tag);
            }
            if (gc.Player.Lifesteal2 == 5)
            {
                bt.Tag = 2;
                Setbuttonsinattack(bt.Tag);
            }
            //defencegroup
            if (gc.Player.Bigdef == 5)
            {
                bt.Tag = 3;
                Setbuttonsindefence(bt.Tag);
            }
            if (gc.Player.Def1 == 5)
            {
                bt.Tag = 1;
                Setbuttonsindefence(bt.Tag);
            }
            if (gc.Player.Def2 == 5)
            {
                bt.Tag = 2;
                Setbuttonsindefence(bt.Tag);
            }
            if (gc.Player.Life1 == 5)
            {
                bt.Tag = 1;
                Setbuttonsindefence(bt.Tag);
            }
            if (gc.Player.Life2 == 5)
            {
                bt.Tag = 2;
                Setbuttonsindefence(bt.Tag);
            }
            if (gc.Player.Lifereg1 == 5)
            {
                bt.Tag = 1;
                Setbuttonsindefence(bt.Tag);
            }
            if (gc.Player.Lifereg2 == 5)
            {
                bt.Tag = 2;
                Setbuttonsindefence(bt.Tag);
            }
        }

        public void Setplayer(Playerstats player)
        {
            this.player = player;
        }

        private void Setbuttonsindefence(object x)
        {
            string y = Add1totag(x);
            foreach (Control control in defencegroup.Controls)
            {
                if ((string)control.Tag == y && control is Button)
                {
                    control.Enabled = true;
                }
            }
        }

        private string Add1totag(object x)
        {
            try
            {
                string y = (string)x;
                int n;
                int.TryParse(y, out n);
                n++;
                return n.ToString();
            }
            catch
            {
                int n = (int)x;
                n++;
                return n.ToString();
            }
        }

        private void Setbuttonsinattack(object x)
        {
            string y = Add1totag(x);
            foreach (Control control in Attacksgroup.Controls)
            {
                if ((string)control.Tag == y && control is Button)
                {
                    control.Enabled = true;
                }
            }
        }

        private void PassiveTree_Load(object sender, EventArgs e)
        {
            SetAllLabels();
        }

        private void SetAllLabels()
        {
            labelpassive.Text = "PassivePoints left: " + gc.Passivepoints;
            labeldmg1.Text = player.Dmg1 + " / 5";
            labeldmg2.Text = player.Dmg2 + " / 5";
            if (player.Doublearmor)
            {
                labeldoublearmor.Text = 1 + " / 1";
            }
            else
            {
                labeldoublearmor.Text = 0 + " / 1";
            }
            if (player.Dualstrike)
            {
                dualtrikelabel.Text = 1 + " / 1";
            }
            else
                dualtrikelabel.Text = 0 + " / 1";
            dmglesslifelabel.Text = player.Dmglesslife + " / 5";
            lifesteal1.Text = player.Lifesteal1 + " / 5";
            lifesteal2.Text = player.Lifesteal2 + " / 5";
            def1.Text = player.Def1 + " / 5";
            def2.Text = player.Def2 + " / 5";
            def3.Text = player.Bigdef + " / 5";
            lifelabel1.Text = player.Life1 + " / 5";
            lifelabel2.Text = player.Life2 + " / 5";
            lifereglabel1.Text = player.Lifereg1 + " / 5";
            lifereglabel2.Text = player.Lifereg2 + " / 5";
            Invalidate();
        }

        private bool CheckPassivepointamount()
        {
            if (gc.Passivepoints > 0)
            {
                gc.Passivepoints--;
                return true;
            }
            return false;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn = sender as Button;
        }

        private void btndmg1_Click(object sender, EventArgs e)
        {
            if (CheckPassivepointamount())
                if (player.Dmg1 < 5)
                {
                    player.Dmg += 0.03m;
                    player.Dmg1++;
                    if (player.Dmg1 == 5)
                    {
                        Button btn = sender as Button;
                        Setbuttonsinattack(btn.Tag);
                    }
                }
            SetAllLabels();
        }

        private void btndmg2_Click(object sender, EventArgs e)
        {
            if (player.Dmg2 < 5)
            {
                player.Dmg += 0.05m;
                player.Dmg2++;
                if (player.Dmg2 == 5)
                {
                    Button btn = sender as Button;
                    Setbuttonsinattack(btn.Tag);
                }
            }
            SetAllLabels();
        }

        private void btnlifesteal1_Click(object sender, EventArgs e)
        {
            if (CheckPassivepointamount())
                if (player.Lifesteal1 < 5)
                {
                    player.Lifeleech += 0.02m;
                    player.Lifesteal1++;
                    if (player.Lifesteal1 == 5)
                    {
                        Button btn = sender as Button;
                        Setbuttonsinattack(btn.Tag);
                    }
                }
            SetAllLabels();
        }

        private void btnlifesteal2_Click(object sender, EventArgs e)
        {
            if (CheckPassivepointamount())
                if (player.Lifesteal2 < 5)
                {
                    player.Lifeleech += 0.05m;
                    player.Lifesteal2++;
                    if (player.Dmg2 == 5)
                    {
                        Button btn = sender as Button;
                        Setbuttonsinattack(btn.Tag);
                    }
                }
            SetAllLabels();
        }

        private void btndamlife_Click(object sender, EventArgs e)
        {
            if (CheckPassivepointamount())
                if (player.Dmglesslife < 5)
                {
                    player.Dmg += 0.2m;
                    player.Lesslife -= 0.05m;
                    player.Dmglesslife++;
                    if (player.Dmglesslife == 5)
                    {
                        Button btn = sender as Button;
                        Setbuttonsinattack(btn.Tag);
                    }
                }
            SetAllLabels();
        }

        private void btndualstrike_Click(object sender, EventArgs e)
        {
            if (CheckPassivepointamount())
                if (!player.Dualstrike)
                {
                    player.Dualstrike = true;
                    SetAllLabels();
                }
        }

        private void btndef1_Click(object sender, EventArgs e)
        {
            if (CheckPassivepointamount())
                if (player.Def1 < 5)
                {
                    player.Def1++;
                    player.Def += 0.02m;
                    if (player.Def1 == 5)
                    {
                        Button btn = sender as Button;
                        Setbuttonsindefence(btn.Tag);
                    }
                }
            SetAllLabels();
        }

        private void btnlife1_Click(object sender, EventArgs e)
        {
            if (CheckPassivepointamount())
                if (player.Life1 < 5)
                {
                    player.Life1++;
                    player.Inchp += 0.02m;
                    if (player.Life1 == 5)
                    {
                        Button btn = sender as Button;
                        Setbuttonsindefence(btn.Tag);
                    }
                }
            SetAllLabels();
        }

        private void btnregen1_Click(object sender, EventArgs e)
        {
            if (CheckPassivepointamount())
                if (player.Lifereg1 < 5)
                {
                    player.Lifereg1++;
                    player.Hpregen += 0.002m;
                    if (player.Lifereg1 == 5)
                    {
                        Button btn = sender as Button;
                        Setbuttonsindefence(btn.Tag);
                    }
                }
            SetAllLabels();
        }

        private void btnregen2_Click(object sender, EventArgs e)
        {
            if (CheckPassivepointamount())
                if (player.Lifereg2 < 5)
                {
                    player.Lifereg2++;
                    player.Hpregen += 0.005m;
                    if (player.Lifereg2 == 5)
                    {
                        Button btn = sender as Button;
                        Setbuttonsindefence(btn.Tag);
                    }
                }
            SetAllLabels();
        }

        private void btnlife2_Click(object sender, EventArgs e)
        {
            if (CheckPassivepointamount())
                if (player.Life2 < 5)
                {
                    player.Life2++;
                    player.Inchp += 0.05m;
                    if (player.Life2 == 5)
                    {
                        Button btn = sender as Button;
                        Setbuttonsindefence(btn.Tag);
                    }
                }
            SetAllLabels();
        }

        private void btndef2_Click(object sender, EventArgs e)
        {
            if (CheckPassivepointamount())
                if (player.Def2 < 5)
                {
                    player.Def2++;
                    player.Def += 0.05m;
                    if (player.Def2 == 5)
                    {
                        Button btn = sender as Button;
                        Setbuttonsindefence(btn.Tag);
                    }
                }
            SetAllLabels();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckPassivepointamount())
                if (player.Bigdef < 5)
                {
                    player.Bigdef++;
                    player.Def += 0.1m;
                    if (player.Bigdef == 5)
                    {
                        Button btn = sender as Button;
                        Setbuttonsindefence(btn.Tag);
                    }
                }
            SetAllLabels();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            gc.Player = player;
        }

        private void btndefdouble_Click(object sender, EventArgs e)
        {
            if (CheckPassivepointamount())
                if (!player.Doublearmor)
                {
                    player.Doublearmor = true;
                    SetAllLabels();
                }
        }
    }
}