using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace RPG_PoE
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        List<Playerstats> players = new List<Playerstats>();

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            NewGame newGame = new NewGame();
            this.Hide();
            newGame.ShowDialog();
            this.Show();
            comboBox1.Items.Clear();
            Menu_Load(null, null);
        }

        //LoadGame
        private void button1_Click(object sender, EventArgs e)
        {
           foreach (Playerstats player in players)
           {
               if (player.Name == comboBox1.Text)
               {
                    TheGame game = new TheGame(player);
                    this.Hide();
                    comboBox1.Text = "";
                    game.ShowDialog();
                    break;
               }
           }
            this.Show();
            comboBox1.Items.Clear();
            Menu_Load(null, null);
        }

        private void UpdateScoreLabel()
        {
            DataBaseControl control = new DataBaseControl();
            Score score = new Score();
            score = control.HaeHightscore();
            labelscore.Text = "Player: " + score.Name;
            labelscore.Visible = true;
            scorelabel2.Text = "Level: "+ score.Lvl;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            UpdateScoreLabel();
            DataBaseControl dbc = new DataBaseControl();
            players = dbc.HaeHahmot();
            foreach (Playerstats player in players)
            {
                comboBox1.Items.Add(player.Name);
            }
        }
    }
}
