using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_PoE
{
    class Amulet : Esineet
    {
        decimal lifeleech = 0;
        decimal manaleech = 0;
        decimal elderExtradmg = 0;

        public decimal Lifeleech { get => lifeleech; set => lifeleech = value; }
        public decimal Manaleech { get => manaleech; set => manaleech = value; }
        public decimal ElderExtradmg { get => elderExtradmg; set => elderExtradmg = value; }

        public void arvostats(string rarity)
        {

        }
    }
}
