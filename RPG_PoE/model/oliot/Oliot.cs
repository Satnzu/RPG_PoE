using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_PoE
{
    public class Oliot
    {
        int lvl = 0;
        string name;
        decimal hp = 0;
        decimal inchp = 0;
        decimal increaseddmg = 0;
        decimal lifeleech = 0;
        decimal manaleech = 0;
        decimal def = 0;
        decimal dmg = 0;
        decimal speed;
        decimal resistance;
        decimal accuracy;
        decimal critchance;
        decimal critdmg;
        decimal hpregen;
        int locationX;
        int locationY;
        public IntVector location
        {
            get
            {
                return new IntVector(LocationX, LocationY);
            }
            set
            {
                LocationX = value.x;
                LocationY = value.y;
            }
        }

        public int Lvl { get => lvl; set => lvl = value; }
        public string Name { get => name; set => name = value; }
        public decimal Hp { get => hp; set => hp = value; }
        public decimal Inchp { get => inchp; set => inchp = value; }
        public decimal Increaseddmg { get => increaseddmg; set => increaseddmg = value; }
        public decimal Lifeleech { get => lifeleech; set => lifeleech = value; }
        public decimal Manaleech { get => manaleech; set => manaleech = value; }
        public decimal Def { get => def; set => def = value; }
        public decimal Dmg { get => dmg; set => dmg = value; }
        public decimal Speed { get => speed; set => speed = value; }
        public decimal Resistance { get => resistance; set => resistance = value; }
        public decimal Accuracy { get => accuracy; set => accuracy = value; }
        public decimal Critchance { get => critchance; set => critchance = value; }
        public decimal Critdmg { get => critdmg; set => critdmg = value; }
        public decimal Hpregen { get => hpregen; set => hpregen = value; }
        public int LocationX { get => locationX; set => locationX = value; }
        public int LocationY { get => locationY; set => locationY = value; }
    }
}
