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
    public partial class NewGame : Form
    {
        public NewGame()
        {
            InitializeComponent();
        }
        Playerstats player = new Playerstats();
        DataBaseControl dbc = new DataBaseControl();

        public void CloseForm(Form form)
        {
            form.Close();
        }

        private void NewGame_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void BtnNewPlayer_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 1:
                    player.Def = 20;
                    player.Dmg = 10;
                    player.Speed = 1;
                    player.Resistance = 0;
                    break;
                case 2:
                    player.Def = 10;
                    player.Dmg = 20;
                    player.Speed = 2;
                    player.Resistance = 10;
                    break;
                case 3:
                    player.Def = 0;
                    player.Dmg = 30;
                    player.Speed = 1;
                    player.Resistance = 20;
                    break;
            }
            player.Hp = 200;
            player.Name = tbname.Text;
            player.LocationX = 0;
            player.LocationY = 19;
            player.Exp = 0;
            player.Exptonext = 100;
            player.Dmg = 0;
            
            dbc.luohahmo(player);
            TheGame game = new TheGame(player);
            game.ShowDialog();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //päivitä labels
        }
    }
}
