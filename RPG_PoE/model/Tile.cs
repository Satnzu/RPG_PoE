using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_PoE.model
{
    public class Tile
    {
        int x;
        int y;
        
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public Tile(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
