using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using RPG_PoE.model;

namespace RPG_PoE
{
    public class Gamecontroller
    {
        Playerstats player = new Playerstats();
        List<Esineet> inventory = new List<Esineet>();
        List<Monster> monsters = new List<Monster>();
        List<Boss> bosses = new List<Boss>();
        List<Tile> tiles = new List<Tile>();
        TheGame th;
        bool playermove = true;
        bool switchspawn = false;
        decimal playerhp;
        int maxinventorysize = 20;
        int passivepoints;
        //bool cannotregenlife = false;
        bool check = false;
        decimal bosshp;
        int attacktimer = 0;
        int maxstats = 6;
        Random rnd = new Random();
        DataBaseControl dbc = new DataBaseControl();
        PassiveTree PassiveTree;
        public Playerstats Player { get => player; set => player = value; }
        public List<Esineet> Inventory { get => inventory; set => inventory = value; }
        public bool Playermove { get => playermove; set => playermove = value; }
        public bool Switchspawn { get => switchspawn; set => switchspawn = value; }
        public decimal Hp { get => Playerhp; set => Playerhp = value; }
        public List<Monster> Monsters { get => monsters; set => monsters = value; }
        public List<Boss> Bosses { get => bosses; set => bosses = value; }
        public int Attacktimer { get => attacktimer; set => attacktimer = value; }
        public PassiveTree PassiveTree1 { get => PassiveTree; set => PassiveTree = value; }
        public decimal Playerhp { get => playerhp; set => playerhp = value; }
        public bool Check { get => check; set => check = value; }
        public int Passivepoints { get => passivepoints; set => passivepoints = value; }

        public Gamecontroller(TheGame theGame)
        {
            th = theGame;
        }

        //pelaajan tallennus
        public void PlayerSave()
        {
            dbc.VieHahmo(player);
            dbc.VieEsineet(inventory, player.Id);
            List<Esineet> equiped = new List<Esineet>();
            equiped.Add(player.Amulet);
            equiped.Add(player.Belt);
            equiped.Add(player.Body);
            equiped.Add(player.Boots);
            equiped.Add(player.Gloves);
            equiped.Add(player.Helmet);
            equiped.Add(player.Ring);
            equiped.Add(player.Weapon);
            dbc.VieEsineet(equiped, player.Id);
        }

        //inventorin haku databasesta
        public void HaeInventory()
        {
            inventory = dbc.HaeEsineet(player.Id);
            foreach (Esineet esine in inventory)
            {
                if (esine.Equiped)
                {
                    if (esine is Amulet)
                    {
                        player.Amulet = (Amulet)esine;
                    }
                    else if (esine is Belt)
                    {
                        player.Belt = (Belt)esine;
                    }
                    else if (esine is Body)
                    {
                        player.Body = (Body)esine;
                    }
                    else if (esine is Boots)
                    {
                        player.Boots = (Boots)esine;
                    }
                    else if (esine is Gloves)
                    {
                        player.Gloves = (Gloves)esine;
                    }
                    else if (esine is Helmet)
                    {
                        player.Helmet = (Helmet)esine;
                    }
                    else if (esine is Ring)
                    {
                        player.Ring = (Ring)esine;
                    }
                }
            }
        }

        //pelaajaan liittyviä laskuja
        public void Checkhp()
        {
            decimal maxhp = CalculatePlayerHp();
            if (Playerhp > maxhp)
            {
                Playerhp = maxhp;
            }
        }

        public void HpRegen()
        {
            Playerhp += player.Hpregen * CalculatePlayerHp();
        }

        public decimal DefenceCalc()
        {
            decimal defence = 0;
            try
            {
                defence = ((1 + Player.Def) * (1 + (Player.Ring.Def * Player.Ring.Increaseddef +
                Player.Belt.Def * Player.Belt.Increaseddef +
                Player.Boots.Def * Player.Boots.Increaseddef + Player.Gloves.Def * Player.Gloves.Increaseddef +
                Player.Helmet.Def * Player.Helmet.Increaseddef + Player.Ring.Def * Player.Ring.Increaseddef)));
                if (player.Doublearmor)
                {
                    defence += 2 * (Player.Body.Def * Player.Body.Increaseddef);
                }
                else
                    defence = Player.Body.Def * Player.Body.Increaseddef;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return defence;
        }

        public decimal CalculatePlayerDmg()
        {
            decimal dmg = 0;
            try
            {
                dmg = 40 + ((1 + player.Dmg) * (1 + (player.Weapon.Dmg * player.Weapon.Increaseddef * (1 + player.Weapon.Elderextra + player.Amulet.ElderExtradmg)) + player.Gloves.Addeddmg));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return dmg;
        }

        public decimal CalculatePlayerHp()
        {
            decimal hp = (1 + player.Inchp) * (1 + (player.Hp + player.Gloves.Hp + player.Helmet.Hp + player.Ring.Hp + player.Belt.Hp + player.Amulet.Hp + player.Boots.Hp + player.Body.Hp));
            return hp;
        }

        public int CalculatePlayerSpeed()
        {
            int tulos = 700;
            int plus = (int)(player.Speed + player.Boots.Speed);
            try
            {
                tulos = tulos / (1 + plus);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return tulos;
        }

        public void Checkhightscore()
        {

            Score score = dbc.HaeHightscore();
            if (score.Lvl < player.Lvl)
            {
                score = new Score();
                score.Lvl = player.Lvl;
                score.Name = player.Name;
                dbc.SetHightscore(score, player.Id);
            }
        }

        //hirviöitten spawn, move, attack ja pelaaja check
        public List<Oliot> CreateWorld()
        {
            List<Oliot> oliot = new List<Oliot>();
            Player.Towerlvl++;
            decimal level = Player.Towerlvl;
            //spawnaa bossi
            if ((level % 5) == 0)
            {
                Boss boss = new Boss();
                Bosses = boss.GetBosses(player);
                bosshp = Bosses[0].Hp;
            }
            //spawnaa muita vihollisia
            else
            {
                SpawnMonsters();
            }
            return oliot;
        }

        public void SpawnMonsters()
        {
            Monster monster = new Monster();
            List<Monster> monsterit = new List<Monster>();
            monsterit = monster.GetMonsters(Player);
            foreach (Monster mon in monsterit)
            {
                Monsters.Add(mon);
            }
            monsterit.Clear();
        }

        public void Moveolio(Oliot olio, IntVector directions, TheGame theGame)
        {
            try
            {
                if (IsTherePlayer(olio.location + directions))
                {
                    monsterattack(olio, theGame);
                }
                else
                {
                    olio.location += directions;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static IntVector NextStep(IntVector position, IntVector target)
        {
            IntVector direction = target - position;
            IntVector Direction = new IntVector(0, 0);
            if (position != target)
            {
                if (Math.Abs(direction.x) > Math.Abs(direction.y))
                {
                    Direction.x = Math.Sign(direction.x);
                }
                else
                {
                    Direction.y = Math.Sign(direction.y);
                }
            }
            return new IntVector(Direction.x, Direction.y);
        }

        public void MoveMonster(Playerstats player, Oliot mon, TheGame theGame)
        {
            IntVector direction;
            direction = NextStep(mon.location, player.location);
            Moveolio(mon, direction, theGame);
        }

        public void monsterattack(Oliot mon, TheGame theGame)
        {
            decimal playerdef = DefenceCalc();
            Playerhp -= mon.Dmg - mon.Dmg * playerdef / (playerdef + 10 * mon.Dmg);
            if (Playerhp <= 0)
            {
                th.monstertimer.Stop();
                Checkhightscore();
                theGame.Close();
                dbc.Deleteplayer(player.Id);
                theGame.monstertimer.Stop();
                theGame.bosstimer.Stop();
                Deadscreen deadscreen = new Deadscreen();
                deadscreen.ShowDialog();
                Check = true;
            }
            theGame.UpdateUi();
        }

        public bool IsTherePlayer(IntVector directions)
        {
            if (player.location == directions)
            {
                return true;
            }
            return false;
        }


        //pelaajan move, ja monster check
        public void MovePlayer(KeyPressEventArgs e)
        {
            int x = 0;
            int y = 0;
            if (e.KeyChar == 'a')
            {
                x = -1;
                if (!IsThereMonster(x, y))
                    player.LocationX -= 1;
            }
            else if (e.KeyChar == 'w')
            {
                y = -1;
                if (!IsThereMonster(x, y))
                    player.LocationY -= 1;
            }
            else if (e.KeyChar == 's')
            {
                y = +1;
                if (!IsThereMonster(x, y))
                    player.LocationY += 1;
            }
            else if (e.KeyChar == 'd')
            {
                x = +1;
                if (!IsThereMonster(x, y))
                    player.LocationX += 1;
            }
            if (player.LocationX == 19 && player.LocationY == 0 && !Switchspawn && bosshp <= 0)
            {
                Switchspawn = true;
                CreateWorld();
            }
            else if (player.LocationX == 0 && player.LocationY == 19 && Switchspawn && bosshp <= 0)
            {
                Switchspawn = false;
                CreateWorld();
            }
        }

        private bool IsThereMonster(IntVector v)
        {
            return IsThereMonster(v.x, v.y);
        }

        private bool IsThereMonster(int x, int y)
        {
            if (x != 0 || y != 0)
            {
                foreach (Monster mon in monsters)
                {
                    if (player.LocationX + x == mon.LocationX && player.LocationY + y == mon.LocationY)
                    {
                        decimal dmg = CalculatePlayerDmg();
                        decimal dmgdone = dmg - dmg * mon.Def / (mon.Def + 10 * dmg);
                        if (rnd.Next(1, 100) < player.Critchance + player.Weapon.Critchance)
                        {
                            dmgdone = (dmgdone * (player.Critdmg + player.Weapon.Critdmg));
                        }
                        if (player.Dualstrike)
                        {
                            dmgdone = dmgdone * 2;
                        }
                        if (dmgdone == 0)
                        {
                            dmgdone = 40;
                        }
                        mon.Hp -= dmgdone;
                        Playerhp += dmgdone * (player.Lifeleech + player.Amulet.Lifeleech + player.Ring.Lifeleech + player.Gloves.Lifeleech);
                        if (mon.Hp <= 0)
                        {
                            monsters.Remove(mon);
                            lvlcheck();
                            lootdrop();
                        }
                        return true;
                    }
                }
                if (bosses.Count != 0)
                {
                    foreach (Boss mon in bosses)
                    {
                        if (player.LocationX + x == mon.LocationX && player.LocationY + y == mon.LocationY)
                        {
                            decimal dmgdone = player.Dmg - player.Dmg * mon.Def / (mon.Def + 10 * player.Dmg);
                            if (rnd.Next(1, 100) < player.Critchance)
                            {
                                dmgdone = dmgdone * player.Critdmg;
                            }
                            bosshp -= dmgdone;
                            Playerhp += dmgdone * (player.Lifeleech + player.Amulet.Lifeleech + player.Ring.Lifeleech + player.Gloves.Lifeleech);
                            if (bosshp <= 0)
                            {
                                foreach (Boss bos in Bosses)
                                {
                                    lootdrop();
                                }
                                bosses.Clear();
                            }
                        }
                    }
                }
            }
            return false;
        }

        public void lvlcheck()
        {
            player.Exp += 10;
            if (player.Exp > player.Exptonext)
            {
                player.Exp -= player.Exptonext;
                player.Lvl++;
                Passivepoints++;
            }
        }

        //esineitten arvontaa
        private void lootdrop()
        {
            string rarity;
            int loops = rnd.Next(1, 2);
            if (loops + inventory.Count > maxinventorysize)
                loops = maxinventorysize - inventory.Count;
            for (int i = 0; i < loops; i++)
            {
                int arpa = rnd.Next(1, 100);
                if (arpa > 0 && arpa < 45) //common 45%
                {
                    rarity = "common";
                    arvoesine(rarity);
                }
                else if (arpa >= 45 && arpa <= 80) //magic 35%
                {
                    rarity = "magic";
                    arvoesine(rarity);
                }
                else //rare 20%
                {
                    rarity = "rare";
                    arvoesine(rarity);
                }
            }
        }

        private void arvoesine(string rarity)
        {
            int loops = 0;
            if (rarity == "common")
            {
                loops = 2;
            }
            else if (rarity == "magic")
            {
                loops = 4;
            }
            else if (rarity == "rare")
            {
                loops = 6;
            }
            //esineen arvonta
            switch (rnd.Next(1, 9))
            {
                case 1:
                    Amulet amulet = new Amulet();
                    RandomAmulet(loops);
                    inventory.Add(amulet);
                    break;
                case 2:
                    Belt belt = RandomBelt(loops);
                    inventory.Add(belt);
                    break;
                case 3:
                    Body body = RandomBodyarmor(ref loops);
                    inventory.Add(body);
                    break;
                case 4:
                    Boots boots = RandomBoots(loops);
                    inventory.Add(boots);
                    break;
                case 5:
                    Gloves gloves = RandomGloves(loops);
                    inventory.Add(gloves);
                    break;
                case 6:
                    Helmet helmet = RandomHelmet(ref loops);
                    inventory.Add(helmet);
                    break;
                case 7:
                    Ring ring = RandomRing(loops);
                    inventory.Add(ring);
                    break;
                case 8:
                    weapon weapon = RandomWeapon(loops);
                    inventory.Add(weapon);
                    break;
                default:

                    break;
            }
        }

        private weapon RandomWeapon(int loops)
        {
            List<int> rndstat = numerolista();
            int luku = 0;
            weapon weapon = new weapon();
            for (int i = 0; i < loops; i++)
            {
                luku = rnd.Next(0, rndstat.Count);
                switch (rndstat[luku])
                {
                    case 1:
                        weapon.Accuracy = rnd.Next(1, 201);
                        break;
                    case 2:
                        weapon.Dmg = rnd.Next(2, 139);
                        break;
                    case 3:
                        weapon.Elderextra = rnd.Next(1, 26) / 100;
                        break;
                    case 4:
                        weapon.Increaseddmg = rnd.Next(10, 131) / 100;
                        break;
                    case 5:
                        weapon.Critchance = rnd.Next(10, 51) / 50;
                        break;
                    case 6:
                        weapon.Critdmg = rnd.Next(1, 31);
                        break;
                }
                rndstat.RemoveAt(luku);
            }
            return weapon;
        }

        private Ring RandomRing(int loops)
        {
            List<int> rndstat = numerolista();
            int luku = 0;
            Ring ring = new Ring();
            for (int i = 0; i < loops; i++)
            {
                luku = rnd.Next(0, rndstat.Count);
                switch (rndstat[luku])
                {
                    case 1:
                        ring.Accuracy = rnd.Next(1, 400);
                        break;
                    case 2:
                        ring.Addeddmg = rnd.Next(1, 25);
                        break;
                    case 3:
                        ring.Def = rnd.Next(1, 70);
                        break;
                    case 4:
                        ring.Hp = rnd.Next(1, 100);
                        break;
                    case 5:
                        ring.Increaseddef = rnd.Next(1, 25) / 100;
                        break;
                    case 6:
                        ring.Lifeleech = rnd.Next(1, 10) / 10;
                        break;
                    case 7:
                        ring.Manaleech = rnd.Next(1, 10) / 10;
                        break;
                }
                rndstat.RemoveAt(luku);
            }

            return ring;
        }

        private Helmet RandomHelmet(ref int loops)
        {
            List<int> rndstat = numerolista();
            int luku = 0;
            Helmet helmet = new Helmet();
            if (loops > 4)
                loops = 4;
            for (int i = 0; i < loops; i++)
            {
                luku = rnd.Next(0, rndstat.Count);
                switch (rndstat[luku])
                {
                    case 1:

                        helmet.Accuracy = rnd.Next(1, 200);
                        break;
                    case 2:
                        helmet.Def = rnd.Next(1, 140);
                        break;
                    case 3:
                        helmet.Hp = rnd.Next(1, 99);
                        break;
                    case 4:
                        helmet.Increaseddef = rnd.Next(1, 100) / 100;
                        break;
                }
                rndstat.RemoveAt(luku);
            }

            return helmet;
        }

        private Gloves RandomGloves(int loops)
        {
            List<int> rndstat = numerolista();
            int luku = 0;
            Gloves gloves = new Gloves();
            for (int i = 0; i < loops; i++)
            {
                luku = rnd.Next(0, rndstat.Count);
                switch (rndstat[luku])
                {
                    case 1:
                        gloves.Accuracy = rnd.Next(1, 200);
                        break;
                    case 2:
                        gloves.Addeddmg = rnd.Next(1, 25);
                        break;
                    case 3:
                        gloves.Def = rnd.Next(1, 100);
                        break;
                    case 4:
                        gloves.Hp = rnd.Next(1, 100);
                        break;
                    case 5:
                        gloves.Increaseddef = rnd.Next(1, 150) / 100;
                        break;
                    case 6:
                        gloves.Lifeleech = rnd.Next(1, 10) / 10;

                        break;
                }
                rndstat.RemoveAt(luku);
            }

            return gloves;
        }

        private Boots RandomBoots(int loops)
        {
            List<int> rndstat = numerolista();
            int luku = 0;
            Boots boots = new Boots();
            for (int i = 0; i < loops; i++)
            {
                luku = rnd.Next(0, rndstat.Count);
                switch (rndstat[luku])
                {
                    case 1:
                        boots.Accuracy = rnd.Next(1, 200);
                        break;
                    case 2:
                        boots.Def = rnd.Next(1, 70);
                        break;
                    case 3:
                        boots.Hp = rnd.Next(1, 99);
                        break;
                    case 4:
                        boots.Increaseddef = rnd.Next(1, 100) / 100;
                        break;
                    case 5:
                        boots.Speed = rnd.Next(1, 10) / 10;
                        break;
                }
                rndstat.RemoveAt(luku);
            }

            return boots;
        }

        private Body RandomBodyarmor(ref int loops)
        {
            List<int> rndstat = numerolista();
            int luku = 0;
            Body body = new Body();
            if (loops > 4)
                loops = 4;
            for (int i = 0; i < loops; i++)
            {
                luku = rnd.Next(0, rndstat.Count);
                switch (rndstat[luku])
                {
                    case 1:
                        body.Accuracy = rnd.Next(1, 200);
                        break;
                    case 2:
                        body.Def = rnd.Next(1, 400);
                        break;
                    case 3:
                        body.Hp = rnd.Next(1, 130);
                        break;
                    case 4:
                        body.Increaseddef = rnd.Next(110) / 100;
                        break;
                }
                rndstat.RemoveAt(luku);
            }

            return body;
        }

        private Belt RandomBelt(int loops)
        {
            List<int> rndstat = numerolista();
            int luku = 0;
            Belt belt = new Belt();
            if (loops > 4)
                loops = 4;
            for (int i = 0; i < loops; i++)
            {
                luku = rnd.Next(0, rndstat.Count);
                switch (rndstat[luku])
                {
                    case 1:
                        belt.Accuracy = rnd.Next(1, 200);
                        break;
                    case 2:
                        belt.Def = rnd.Next(1, 540);
                        break;
                    case 3:
                        belt.Hp = rnd.Next(1, 99);
                        break;
                    case 4:
                        belt.Increaseddef = rnd.Next(1, 100) / 100;
                        break;
                    default:
                        i--;
                        break;
                }
                rndstat.RemoveAt(luku);
            }
            return belt;
        }

        private Amulet RandomAmulet(int loops)
        {
            List<int> rndstat = numerolista();
            int luku = 0;
            Amulet amulet = new Amulet();
            for (int i = 0; i < loops; i++)
            {
                luku = rnd.Next(0, rndstat.Count);
                switch (rndstat[luku])
                {
                    case 1:
                        amulet.Accuracy = rnd.Next(1, 400);
                        break;
                    case 2:
                        amulet.Def = rnd.Next(1, 100);
                        break;
                    case 3:
                        amulet.ElderExtradmg = rnd.Next(5, 25) / 100;
                        break;
                    case 4:
                        amulet.Hp = rnd.Next(1, 100);
                        break;
                    case 5:
                        amulet.Lifeleech = (rnd.Next(1, 10) / 10);
                        break;
                    case 6:
                        amulet.Manaleech = (rnd.Next(1, 10) / 10);
                        break;
                }
                rndstat.RemoveAt(luku);
            }
            return amulet;
        }

        private List<int> numerolista()
        {
            List<int> rndstat = new List<int>();
            for (int i = 1; i <= maxstats; i++)
            {
                rndstat.Add(i);
            }
            return rndstat;
        }

        //boss juttuja
        public List<Tile> RndAttack(int sizee)
        {
            if (bosses.Count != 0)
            {
                if (attacktimer == 5)
                {
                    attacktimer = 0;
                    tiles = Bosses[0].RndAttack(sizee, player, this);
                    return tiles;
                }
                attacktimer++;
                return tiles;
            }
            else
            {
                tiles.Clear();
                return tiles;
            }

        }
    }
}