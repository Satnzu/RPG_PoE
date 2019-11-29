using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RPG_PoE
{
    public class Playerstats : Seikkailija
    {
        int id;
        int exp;
        int exptonext;
        decimal lesslife = 0;
        Bitmap playerimg = new Bitmap(Properties.Resources.knight, new Size(44, 44));
        weapon weapon = new weapon();
        Amulet amulet = new Amulet();
        Belt belt = new Belt();
        Body body = new Body();
        Boots boots = new Boots();
        Gloves gloves = new Gloves();
        Helmet helmet = new Helmet();
        Ring ring = new Ring();
        //skill point hässäkkä
        //attack
        int dmg1 = 0;
        int dmg2 = 0;
        int lifesteal1 = 0;
        int lifesteal2 = 0;
        int dmglesslife = 0;
        bool dualstrike = false;
        //defence
        int def1 = 0;
        int def2 = 0;
        int life1 = 0;
        int life2 = 0;
        int lifereg1 = 0;
        int lifereg2 = 0;
        int bigdef = 0;
        bool doublearmor = false;
        //special
        //COMING SOON

        public int Id { get => id; set => id = value; }
        internal weapon Weapon { get => weapon; set => weapon = value; }
        internal Amulet Amulet { get => amulet; set => amulet = value; }
        internal Belt Belt { get => belt; set => belt = value; }
        internal Body Body { get => body; set => body = value; }
        internal Boots Boots { get => boots; set => boots = value; }
        internal Gloves Gloves { get => gloves; set => gloves = value; }
        internal Helmet Helmet { get => helmet; set => helmet = value; }
        internal Ring Ring { get => ring; set => ring = value; }
        public Bitmap Playerimg { get => playerimg; set => playerimg = value; }
        public int Exp { get => exp; set => exp = value; }
        public int Exptonext { get => exptonext; set => exptonext = value; }
        public int Dmg1 { get => dmg1; set => dmg1 = value; }
        public int Dmg2 { get => dmg2; set => dmg2 = value; }
        public int Lifesteal1 { get => lifesteal1; set => lifesteal1 = value; }
        public int Lifesteal2 { get => lifesteal2; set => lifesteal2 = value; }
        public int Dmglesslife { get => dmglesslife; set => dmglesslife = value; }
        public bool Dualstrike { get => dualstrike; set => dualstrike = value; }
        public int Def1 { get => def1; set => def1 = value; }
        public int Def2 { get => def2; set => def2 = value; }
        public int Life1 { get => life1; set => life1 = value; }
        public int Life2 { get => life2; set => life2 = value; }
        public int Lifereg1 { get => lifereg1; set => lifereg1 = value; }
        public int Lifereg2 { get => lifereg2; set => lifereg2 = value; }
        public int Bigdef { get => bigdef; set => bigdef = value; }
        public bool Doublearmor { get => doublearmor; set => doublearmor = value; }
        public decimal Lesslife { get => lesslife; set => lesslife = value; }
    }
}