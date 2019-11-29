using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_PoE
{
    class Gloves : Esineet
    {
        decimal lifeleech = 0;
        decimal addeddmg = 0;

        public decimal Lifeleech { get => lifeleech; set => lifeleech = value; }
        public decimal Addeddmg { get => addeddmg; set => addeddmg = value; }
    }
}
