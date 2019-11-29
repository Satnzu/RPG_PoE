using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RPG_PoE
{
    public class Monster : Oliot
    {
        Bitmap monsterimg = new Bitmap(Properties.Resources.monster, new Size(44, 44));

        public Bitmap Monsterimg { get => monsterimg; set => monsterimg = value; }

        public void setmonsterstats(int towerlvl)
        {
            Random rnd = new Random();
            Dmg = (rnd.Next(1, 5) * (1 + towerlvl / 5));
            Def = (rnd.Next(1, 50) * (1 + towerlvl / 5));
            Hp = (rnd.Next(50, 100) * (1 + towerlvl / 5));
            Resistance = (rnd.Next(0, 50) / 100);
        }

        public List<Monster> GetMonsters(Playerstats player)
        {
            List<Monster> monsters = new List<Monster>();
            bool test = false;
            Random rnd = new Random();
            for (int i = rnd.Next(3,7); i > 0; i--)
            {
                Monster monster = new Monster();
                monster.setmonsterstats(player.Towerlvl);
                int x = rnd.Next(0, 19);
                int y = rnd.Next(0, 19);
                monster.LocationX = x;
                monster.LocationY = y;
                monster.LocationY = y;
                try
                {
                    foreach (Monster mon in monsters)
                    {
                        if (mon.LocationX == monster.LocationX && mon.LocationY == monster.LocationY && mon.LocationX == player.LocationX && mon.LocationY == player.LocationY)
                        {
                            i++;
                            test = true;
                        }
                        else
                            monsters.Add(monster);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                if (!test)
                {
                    monsters.Add(monster);
                }
            }
            return monsters;
        }
    }
}
