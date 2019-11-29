using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using RPG_PoE.model;

namespace RPG_PoE
{
    public class Boss : Oliot
    {
        Bitmap bossimg = new Bitmap(Properties.Resources.Shieldmonster, new Size(88, 88));
        Gamecontroller gc = new Gamecontroller(null);
        Random rnd = new Random();

        public Bitmap Bossimg { get => bossimg; set => bossimg = value; }

        public void SetBossStats(int towerlvl)
        {
            Random rnd = new Random();
            Dmg = (rnd.Next(10, 20) * (1 + towerlvl / 5));
            Def = (rnd.Next(15, 90) * (1 + towerlvl / 5));
            Hp = (rnd.Next(100, 1000) * (1 + towerlvl / 5));
            Resistance = 50 / 100;
        }

        public List<Boss> GetBosses(Playerstats player)
        {
            List<Boss> bosses = new List<Boss>();
            Random rnd = new Random();
            for (int i = 2; i > 0; i--)
            {
                for (int j = 2; j > 0; j--)
                {
                    Boss monster = new Boss();
                    monster.SetBossStats(player.Towerlvl);
                    int x = 10 - i;
                    int y = 10 - j;
                    monster.LocationX = x;
                    monster.LocationY = y;
                    bosses.Add(monster);
                }
            }
            return bosses;
        }

        public List<Tile> RndAttack(int th, Playerstats player, Gamecontroller gc)
        {
            List<Tile> coordinates = new List<Tile>();

            switch (rnd.Next(1,5))
            {
                case 1:
                    coordinates = BossAttackTicTacToe(coordinates, th);
                    break;
                case 2:
                    coordinates = BossAttackSpin(coordinates, th);
                    break;
                case 3:
                    coordinates = BossAttackMeteor(coordinates, th, player);
                    break;
                case 4:
                    BossAttackMonsterSpawn(gc);
                    break;
                default:

                    break;
            }
            return coordinates;
        }

        public List<Tile> BossAttackTicTacToe(List<Tile> tiles, int size)
        {
            for (int y = 0; y < size; y++)
            {
                int i = -1;
                if (y % 2 == 0)
                {
                    i = 0;
                }
                for (int x = i; x < size - 1; x++)
                {
                    x++;
                    Tile tile = new Tile(x, y);
                    tiles.Add(tile);
                }
            }
            return tiles;
        }

        public List<Tile> BossAttackSpin(List<Tile> tiles, int size)
        {
            for (int x = this.LocationX - 2; x < this.LocationX + 4; x++)
            {
                for (int y = this.LocationY - 2; y < this.LocationY + 4; y++)
                {
                    Tile tile = new Tile(x,y);
                    tiles.Add(tile);
                }
            }
            return tiles;
        }

        public List<Tile> BossAttackMeteor(List<Tile> tiles, int size, Playerstats player)
        {
            for (int x = player.LocationX - 2; x < player.LocationX + 3; x++)
            {
                for (int y = player.LocationY - 2; y < player.LocationY + 3; y++)
                {
                    Tile tile = new Tile(x, y);
                    tiles.Add(tile);
                }
            }

            return tiles;
        }

        public void BossAttackMonsterSpawn(Gamecontroller gc)
        {
            gc.SpawnMonsters();
        }
    }
}
