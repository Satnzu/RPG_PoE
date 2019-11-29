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
    public partial class inventoryform : Form
    {
        Playerstats player = new Playerstats();
        List<Esineet> newinventory = new List<Esineet>();
        TheGame game;
        public inventoryform(List<Esineet> inventory, Playerstats playerstats, TheGame theGame)
        {
            InitializeComponent();
            player = playerstats;
            game = theGame;
            newinventory = inventory;
            Itemsorting();
        }

        Esineet viimeksivalittu = new Esineet();

        private void Itemsorting()
        {
            int ring = 1;
            int weapon = 1;
            int body = 1;
            int belt = 1;
            int boots = 1;
            int gloves = 1;
            int helmet = 1;
            foreach(Esineet esine in newinventory)
            {
                if (esine is Ring)
                {
                    esine.Nam = "ring_" + ring;
                    CBrings.Items.Add(esine);
                    ring++;
                }
                else if (esine is weapon)
                {
                    esine.Nam = "weapon_" + weapon;
                    CBweapons.Items.Add(esine);
                    weapon++;
                }
                else if (esine is Body)
                {
                    esine.Nam = "bodyarmor_" + body;
                    CBbody.Items.Add(esine);
                    body++;
                }
                else if (esine is Belt)
                {
                    esine.Nam = "belt_" + belt;
                    CBbelts.Items.Add(esine);
                    belt++;
                }
                else if (esine is Boots)
                {
                    esine.Nam = "boots_" + boots;
                    CBboots.Items.Add(esine);
                    boots++;
                }
                else if (esine is Gloves)
                {
                    esine.Nam = "gloves_" + gloves;
                    CBgloves.Items.Add(esine);
                    gloves++;
                }
                else if (esine is Helmet)
                {
                    esine.Nam = "helmet_" + helmet;
                    CBhelmet.Items.Add(esine);
                    helmet++;
                }
            }
        }

        private void ClearAllComboboxes()
        {
            CBbelts.SelectedItem = null;
            CBbody.SelectedItem = null;
            CBboots.SelectedItem = null;
            CBgloves.SelectedItem = null;
            CBhelmet.SelectedItem = null;
            CBrings.SelectedItem = null;
            CBweapons.SelectedItem = null;
        }

        private void CBweapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBweapons.SelectedItem != null)
            {
                TBitem.Clear();
                TBequiped.Clear();
                weapon ase = (weapon)CBweapons.SelectedItem;
                viimeksivalittu = ase;
                Naytaweapon(ase, CBweapons);
            }
        }

        private void CBhelmet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBhelmet.SelectedItem != null)
            {
                TBitem.Clear();
                TBequiped.Clear();
                Helmet helmet = (Helmet)CBhelmet.SelectedItem;
                viimeksivalittu = helmet;
                Naytahelmet(helmet, CBhelmet);
            }
        }

        private void CBbody_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBbody.SelectedItem != null)
            {
                TBitem.Clear();
                TBequiped.Clear();
                Body armor = (Body)CBbody.SelectedItem;
                viimeksivalittu = armor;
                Naytabodyarmor(armor, CBbody);
            }
        }

        private void CBrings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBrings.SelectedItem != null)
            {
                TBitem.Clear();
                TBequiped.Clear();
                Ring ring = (Ring)CBrings.SelectedItem;
                viimeksivalittu = ring;
                Naytaringi(ring, CBrings);
            }
        }

        private void CBgloves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBgloves.SelectedItem != null)
            {
                TBitem.Clear();
                TBequiped.Clear();
                Gloves glove = (Gloves)CBgloves.SelectedItem;
                viimeksivalittu = glove;
                Naytaglovet(glove, CBgloves);
            }
        }

        private void CBbelts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBbelts.SelectedItem != null)
            {
                TBitem.Clear();
                TBequiped.Clear();
                Belt belt = (Belt)CBbelts.SelectedItem;
                viimeksivalittu = belt;
                Naytabeltti(belt, CBbelts);
            }
        }

        private void CBboots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBboots.SelectedItem != null)
            {
                TBitem.Clear();
                TBequiped.Clear();
                Boots boots = (Boots)CBboots.SelectedItem;
                viimeksivalittu = boots;
                Naytabootsit(boots, CBboots);
            }
        }
        
        private void Naytaweapon(weapon ase, ComboBox sender)
        {
            //näytetään valittu esine
            if (ase.Dmg > 0)
            {
                TBitem.Text += "Dmg: " + (ase.Dmg * (1 + ase.Increaseddmg)) * (1 + ase.Elderextra);
            }
            if (ase.Accuracy > 0)
            {
                TBitem.Text += Environment.NewLine + "Accuracy: " + ase.Accuracy;
            }
            //näytetään pelaajan esine
            if (player.Weapon.Dmg > 0)
            {
                TBequiped.Text += "Dmg: " + (player.Weapon.Dmg * (1 + player.Weapon.Increaseddmg)) * (1 + player.Weapon.Elderextra);
            }
            if (player.Weapon.Accuracy > 0)
            {
                TBequiped.Text += Environment.NewLine + "Accuracy: " + ase.Accuracy;
            }
            if (player.Weapon.Critchance > 0)
            {
                TBequiped.Text += Environment.NewLine + "Critchance: " + ase.Critchance;
            }
            if (player.Weapon.Critdmg > 0)
            {
                TBequiped.Text += Environment.NewLine + "Crit damage: " + ase.Critdmg;
            }
        }

        private void Naytahelmet(Helmet helmet, ComboBox sender)
        {
            //näytetään valittu esine
            if (helmet.Accuracy > 0)
            {
                TBitem.Text += "Accuracy: " + helmet.Accuracy;
            }
            if (helmet.Def > 0)
            {
                TBitem.Text += Environment.NewLine + "Defence: " + (helmet.Def * (1 + helmet.Increaseddef));
            }
            if (helmet.Hp > 0)
            {
                TBitem.Text += Environment.NewLine + "Hp: " + helmet.Hp;
            }
            //näytetään pelaajalla oleva esine
            if (player.Helmet.Accuracy > 0)
            {
                TBequiped.Text += "Accuracy: " + player.Helmet.Accuracy;
            }
            if (player.Helmet.Def > 0)
            {
                TBequiped.Text += Environment.NewLine + "Defence: " + (player.Helmet.Def * (1 + player.Helmet.Increaseddef));
            }
            if (player.Helmet.Hp > 0)
            {
                TBequiped.Text += Environment.NewLine + "Hp: " + player.Helmet.Hp;
            }
        }

        private void Naytabodyarmor(Body armor, ComboBox sender)
        {
            //näytetään valittu esine
            if (armor.Accuracy > 0)
            {
                TBitem.Text += "Accuracy: " + armor.Accuracy;
            }
            if (armor.Def > 0)
            {
                TBitem.Text += Environment.NewLine + "Defence: " + armor.Def * (1 + armor.Increaseddef);
            }
            if (armor.Hp > 0)
            {
                TBitem.Text += Environment.NewLine + "HP: " + armor.Hp;
            }
            //näytetään pelaajan esine
            if (player.Body.Accuracy > 0)
            {
                TBequiped.Text += "Accuracy: " + player.Body.Accuracy;
            }
            if (player.Body.Def > 0)
            {
                TBequiped.Text += Environment.NewLine + "Defence: " + player.Body.Def * (1 + player.Body.Increaseddef);
            }
            if (player.Body.Hp > 0)
            {
                TBequiped.Text += Environment.NewLine + "HP: " + player.Body.Hp;
            }
        }

        private void Naytaringi(Ring ring, ComboBox sender)
        {
            // näytetään valittu esine
            if (ring.Accuracy > 0)
            {
                TBitem.Text += "Accuracy: " + ring.Accuracy;
            }
            if (ring.Def > 0)
            {
                TBitem.Text += Environment.NewLine + "Defence: " + ring.Def * (1 + ring.Increaseddef);
            }
            if (ring.Hp > 0)
            {
                TBitem.Text += Environment.NewLine + "HP: " + ring.Hp;
            }
            if (ring.Lifeleech > 0)
            {
                TBitem.Text += Environment.NewLine + "Lifeleech: " + ring.Lifeleech;
            }
            if (ring.Manaleech > 0)
            {
                TBitem.Text += Environment.NewLine + "Manaleech: " + ring.Manaleech;
            }
            if (ring.Addeddmg > 0)
            {
                TBitem.Text += Environment.NewLine + "Added damage: " + ring.Addeddmg;
            }
            // näytetään pelaajan esine
            if (player.Ring.Accuracy > 0)
            {
                TBequiped.Text += "Accuracy: " + player.Ring.Accuracy;
            }
            if (player.Ring.Def > 0)
            {
                TBequiped.Text += Environment.NewLine + "Defence: " + player.Ring.Def * (1 + player.Ring.Increaseddef);
            }
            if (player.Ring.Hp > 0)
            {
                TBequiped.Text += Environment.NewLine + "HP: " + player.Ring.Hp;
            }
            if (player.Ring.Lifeleech > 0)
            {
                TBequiped.Text += Environment.NewLine + "Lifeleech: " + player.Ring.Lifeleech;
            }
            if (player.Ring.Manaleech > 0)
            {
                TBequiped.Text += Environment.NewLine + "Manaleech: " + player.Ring.Manaleech;
            }
            if (player.Ring.Addeddmg > 0)
            {
                TBequiped.Text += Environment.NewLine + "Added damage: " + player.Ring.Addeddmg;
            }
        }

        private void Naytaglovet(Gloves glove, ComboBox sender)
        {
            // näytetään valittu esine
            if (glove.Accuracy > 0)
            {
                TBitem.Text += "Accuracy: " + glove.Accuracy;
            }
            if (glove.Def > 0)
            {
                TBitem.Text += Environment.NewLine + "Defence: " + glove.Def * (1 + glove.Increaseddef);
            }
            if (glove.Hp > 0)
            {
                TBitem.Text += Environment.NewLine + "HP: " + glove.Hp;
            }
            if (glove.Lifeleech > 0)
            {
                TBitem.Text += Environment.NewLine + "Lifeleech: " + glove.Lifeleech;
            }
            if (glove.Addeddmg > 0)
            {
                TBitem.Text += Environment.NewLine + "Added damage: " + glove.Addeddmg;
            }
            // näytetään pelaajan esine
            if (player.Gloves.Accuracy > 0)
            {
                TBequiped.Text += "Accuracy: " + player.Gloves.Accuracy;
            }
            if (player.Gloves.Def > 0)
            {
                TBequiped.Text += Environment.NewLine + "Defence: " + player.Gloves.Def * (1 + player.Gloves.Increaseddef);
            }
            if (player.Gloves.Hp > 0)
            {
                TBequiped.Text += Environment.NewLine + "HP: " + player.Gloves.Hp;
            }
            if (player.Gloves.Lifeleech > 0)
            {
                TBequiped.Text += Environment.NewLine + "Lifeleech: " + player.Gloves.Lifeleech;
            }
            if (player.Gloves.Addeddmg > 0)
            {
                TBequiped.Text += Environment.NewLine + "Added damage: " + player.Gloves.Addeddmg;
            }
        }

        private void Naytabeltti(Belt belt, ComboBox sender)
        {
            // näytetään valittu esine
            if (belt.Accuracy > 0)
            {
                TBitem.Text += "Accuracy: " + belt.Accuracy;
            }
            if (belt.Def > 0)
            {
                TBitem.Text += Environment.NewLine + "Defence: " + belt.Def * (1 + belt.Increaseddef);
            }
            if (belt.Hp > 0)
            {
                TBitem.Text += Environment.NewLine + "HP: " + belt.Hp;
            }
            // näytetään pelaajan esine
            if (player.Belt.Accuracy > 0)
            {
                TBequiped.Text += "Accuracy: " + player.Belt.Accuracy;
            }
            if (player.Belt.Def > 0)
            {
                TBequiped.Text += Environment.NewLine + "Defence: " + player.Belt.Def * (1 + player.Belt.Increaseddef);
            }
            if (player.Belt.Hp > 0)
            {
                TBequiped.Text += Environment.NewLine + "HP: " + player.Belt.Hp;
            }
        }

        private void Naytabootsit(Boots boots, ComboBox sender)
        {
            // näytetään valittu esine
            if (boots.Accuracy > 0)
            {
                TBitem.Text += "Accuracy: " + boots.Accuracy;
            }
            if (boots.Def > 0)
            {
                TBitem.Text += Environment.NewLine + "Defence: " + boots.Def * (1 + boots.Increaseddef);
            }
            if (boots.Hp > 0)
            {
                TBitem.Text += Environment.NewLine + "HP: " + boots.Hp;
            }
            if (boots.Speed > 0)
            {
                TBitem.Text += Environment.NewLine + "Speed: " + boots.Speed;
            }
            // näytetään pelaajan esine
            if (player.Boots.Accuracy > 0)
            {
                TBequiped.Text += "Accuracy: " + player.Boots.Accuracy;
            }
            if (player.Boots.Def > 0)
            {
                TBequiped.Text += Environment.NewLine + "Defence: " + player.Boots.Def * (1 + player.Boots.Increaseddef);
            }
            if (player.Boots.Hp > 0)
            {
                TBequiped.Text += Environment.NewLine + "HP: " + player.Boots.Hp;
            }
            if (player.Boots.Speed > 0)
            {
                TBequiped.Text += Environment.NewLine + "Speed: " + player.Boots.Speed;
            }
        }

        private void BTequip_Click(object sender, EventArgs e)
        {
            if (CBbelts.SelectedItem != null)
            {
                viimeksivalittu = (Belt)CBbelts.SelectedItem;
                viimeksivalittu.Equiped = true;
                newinventory.Remove(viimeksivalittu);
                player.Belt.Equiped = false;
                newinventory.Add(player.Belt);
                player.Belt = (Belt)viimeksivalittu;
            }
            if (CBbody.SelectedItem != null)
            {
                viimeksivalittu = (Body)CBbody.SelectedItem;
                viimeksivalittu.Equiped = true;
                newinventory.Remove(viimeksivalittu);
                player.Body.Equiped = false;
                newinventory.Add(player.Body);
                player.Body = (Body)viimeksivalittu;
            }
            if (CBboots.SelectedItem != null)
            {
                viimeksivalittu = (Boots)CBboots.SelectedItem;
                viimeksivalittu.Equiped = true;
                newinventory.Remove(viimeksivalittu);
                player.Boots.Equiped = false;
                newinventory.Add(player.Boots);
                player.Boots = (Boots)viimeksivalittu;
            }
            if (CBgloves.SelectedItem != null)
            {
                viimeksivalittu = (Gloves)CBgloves.SelectedItem;
                viimeksivalittu.Equiped = true;
                newinventory.Remove(viimeksivalittu);
                player.Gloves.Equiped = false;
                newinventory.Add(player.Gloves);
                player.Gloves = (Gloves)viimeksivalittu;
            }
            if (CBhelmet.SelectedItem != null)
            {
                viimeksivalittu = (Helmet)CBhelmet.SelectedItem;
                viimeksivalittu.Equiped = true;
                newinventory.Remove(viimeksivalittu);
                player.Helmet.Equiped = false;
                newinventory.Add(player.Helmet);
                player.Helmet = (Helmet)viimeksivalittu;
            }
            if (CBrings.SelectedItem != null)
            {
                viimeksivalittu = (Ring)CBrings.SelectedItem;
                viimeksivalittu.Equiped = true;
                newinventory.Remove(viimeksivalittu);
                player.Ring.Equiped = false;
                newinventory.Add(player.Ring);
                player.Ring = (Ring)viimeksivalittu;
            }
            if (CBweapons.SelectedItem != null)
            {
                viimeksivalittu = (weapon)CBweapons.SelectedItem;
                viimeksivalittu.Equiped = true;
                newinventory.Remove(viimeksivalittu);
                player.Weapon.Equiped = false;
                newinventory.Add(player.Weapon);
                player.Weapon = (weapon)viimeksivalittu;
            }
            ClearAllComboboxes();
            Itemsorting();
            game.Setplayerinv(newinventory, player);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newinventory.Clear();
        }
    }
}