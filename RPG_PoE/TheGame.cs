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
using RPG_PoE.model;

namespace RPG_PoE
{
    public partial class TheGame : Form
    {
        public int arenasize = 20;
        Monster monster = new Monster();
        Gamecontroller gc;
        ImageGallery ImageGallery = new ImageGallery();
        Point point = new Point();
        List<Tile> tiles = new List<Tile>();
        int tilesize = 45;
        Size size = new Size();
        bool pause = false;
        int offsetx = 10;
        int offsety = 25;

        public TheGame(Playerstats gotplayer)
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            gc = new Gamecontroller(this);
            CreateWorld();
            gc.CalculatePlayerHp();
            gc.Player = gotplayer;
            gc.Playerhp = gc.Player.Hp;
            gc.HaeInventory();
            UpdateStyles();
            UpdateUi();
            gc.PassiveTree1 = new PassiveTree(gc);
        }

        public void SetPlayerTimer()
        {
            playertimer.Interval = gc.CalculatePlayerSpeed();
        }

        public void Setplayerinv(List<Esineet> lista, Playerstats gotplayer)
        {
            gc.Inventory = lista;
            gc.Player = gotplayer;
        }

        public void UpdateUi()
        {
            lbdef.Text = "Defence: " + Math.Round(gc.DefenceCalc());
            lbdmg.Text = "Damage: " + Math.Round(gc.CalculatePlayerDmg());
            lblvl.Text = "Level: " + (gc.Player.Lvl);
            lbname.Text = "Name: " + gc.Player.Name;
            lbspeed.Text = "Speed: " + (gc.Player.Speed + gc.Player.Boots.Speed);
            LabHp.Text = "Hp: " + Math.Round(gc.Hp);
            inventorylabel.Text ="inventory: " + gc.Inventory.Count + "/ 20";
            Lexp.Text = "EXP: " + gc.Player.Exp + " / " + gc.Player.Exptonext;
        }

        public void CreateWorld()
        {
            List<Oliot> oliot = new List<Oliot>();
            gc.Player.Towerlvl++;
            decimal level = gc.Player.Towerlvl;
            oliot = gc.CreateWorld();
            foreach (Boss boss in oliot)
            {
                gc.Bosses.Add(boss);
            }
            foreach (Monster monster in oliot)
            {
                gc.Monsters.Add(monster);
            }
            Invalidate();
            monstertimer.Start();
            bosstimer.Start();
        }

        private void playertimer_Tick(object sender, EventArgs e)
        {
            gc.Playermove = true;
            playertimer.Stop();
        }

        private void monstertimer_Tick(object sender, EventArgs e)
        {
            gc.HpRegen();
            gc.Checkhp();
            foreach (Monster monster in gc.Monsters)
            {
                if (gc.Check)
                {
                    gc.Check = false;
                    break;
                }
                else
                gc.MoveMonster(gc.Player, monster, this);
            }
            UpdateUi();
            Invalidate();
        }

        private void TheGame_Paint(object sender, PaintEventArgs e)
        {
            Pen kyna = new Pen(Color.Blue);
            size.Height = tilesize;
            size.Width = tilesize;

            for (int x = 0; x < arenasize; x++)
            {
                for (int y = 0; y < arenasize; y++)
                {
                    Pen pen = new Pen(Color.Black);
                    point = new Point(x * tilesize + offsetx, y * tilesize + offsety);
                    Rectangle rect = new Rectangle(point, size);
                    e.Graphics.DrawRectangle(pen, rect);
                    if (x == 19 && y == 0 && !gc.Switchspawn)
                    {
                        point = new Point(x * tilesize + offsetx + 1, y * tilesize + offsety + 1);
                        e.Graphics.DrawImage(ImageGallery.Stairsimg, point);
                    }
                    else if (x == 0 && y == 19 && gc.Switchspawn)
                    {
                        point = new Point(x * tilesize + offsetx + 1, y * tilesize + offsety + 1);
                        e.Graphics.DrawImage(ImageGallery.Stairsimg, point);
                    }
                }
            }          
            foreach (Tile tile in tiles) 
            {
                point = new Point(tile.X * tilesize + offsetx + 1, tile.Y * tilesize + offsety + 1);
                if (gc.Attacktimer < 4)
                {
                    e.Graphics.DrawImage(ImageGallery.Warning, point);
                }
                else
                    e.Graphics.DrawImage(ImageGallery.Explosion, point);
            }
            try
            {
                point = new Point(gc.Bosses[0].LocationX * tilesize + offsetx + 1, gc.Bosses[0].LocationY * tilesize + offsety + 1);
                e.Graphics.DrawImage(gc.Bosses[0].Bossimg, point);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            try
            {
                foreach (Monster mon in gc.Monsters)
                {
                    point = new Point(mon.LocationX * tilesize + offsetx + 1, mon.LocationY * tilesize + offsety + 1);
                    e.Graphics.DrawImage(mon.Monsterimg, point);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }            
            point = new Point(gc.Player.LocationX * tilesize + offsetx, gc.Player.LocationY * tilesize + offsety);
            e.Graphics.DrawImage(gc.Player.Playerimg, point);
        }

        private void TheGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gc.Playermove)
            {
                playertimer.Start();
                gc.MovePlayer(e);
                gc.Playermove = false;
                Invalidate();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btninventory_Click(object sender, EventArgs e)
        {
            inventoryform inventoryform = new inventoryform(gc.Inventory, gc.Player, this);
            playertimer.Stop();
            monstertimer.Stop();
            inventoryform.ShowDialog();
            monstertimer.Start();
            UpdateUi();
            SetPlayerTimer();
            playertimer.Start();
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            if (!pause)
            {
                playertimer.Stop();
                monstertimer.Stop();
                pause = true;
                gc.Playermove = false;
            }
            else
            {

                playertimer.Start();
                monstertimer.Start();
                pause = false;
                gc.Playermove = true;
            }
        }

        private void BTsave_Click(object sender, EventArgs e)
        {
            gc.PlayerSave();
        }

        private void bosstimer_Tick(object sender, EventArgs e)
        {
            tiles = gc.RndAttack(arenasize);
            if (gc.Attacktimer == 4)
            {
                foreach (Tile tile in tiles)
                {
                    if (tile.X == gc.Player.LocationX && tile.Y == gc.Player.LocationY)
                    {
                        gc.monsterattack(gc.Bosses[0], this);
                    }
                }
            }
        }

        private void btnpassive_Click(object sender, EventArgs e)
        {
            this.Hide();
            playertimer.Stop();
            monstertimer.Stop();
            gc.PassiveTree1.Setplayer(gc.Player);
            gc.PassiveTree1.ShowDialog();
            this.Show();
            playertimer.Start();
            monstertimer.Start();
        }
    }
}