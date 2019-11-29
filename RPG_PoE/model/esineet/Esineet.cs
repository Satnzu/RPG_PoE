using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_PoE
{
    public class Esineet
    {
        decimal def = 0;
        decimal increaseddef = 0;
        decimal hp = 0;
        decimal accuracy = 0;
        decimal resistance = 0;
        bool equiped = false;
        string nam;

        public decimal Def { get => def; set => def = value; }
        public decimal Increaseddef { get => increaseddef; set => increaseddef = value; }
        public decimal Hp { get => hp; set => hp = value; }
        public decimal Accuracy { get => accuracy; set => accuracy = value; }
        public bool Equiped { get => equiped; set => equiped = value; }
        public string Nam { get => nam; set => nam = value; }
    }
}
