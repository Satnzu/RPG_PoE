using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_PoE
{
    class weapon : Esineet
    {
        decimal dmg = 0;
        decimal increaseddmg = 0;
        decimal elderextra = 0;
        decimal critdmg = 0;
        decimal critchance = 0;

        public decimal Dmg { get => dmg; set => dmg = value; }
        public decimal Increaseddmg { get => increaseddmg; set => increaseddmg = value; }
        public decimal Elderextra { get => elderextra; set => elderextra = value; }
        public decimal Critdmg { get => critdmg; set => critdmg = value; }
        public decimal Critchance { get => critchance; set => critchance = value; }
    }
}
