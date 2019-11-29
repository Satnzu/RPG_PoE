using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RPG_PoE
{

    class ImageGallery
    {
        Bitmap stairsimg = new Bitmap(Properties.Resources.pixelstair, new Size(44, 44));
        Bitmap Deadimg = new Bitmap(Properties.Resources.Dead, new Size(200, 105));
        Bitmap warning = new Bitmap(Properties.Resources.danger, new Size(44, 44));
        Bitmap explosion = new Bitmap(Properties.Resources.explosion, new Size(44, 44));

        public Bitmap Stairsimg { get => stairsimg; set => stairsimg = value; }
        public Bitmap Deadimg1 { get => Deadimg; set => Deadimg = value; }
        public Bitmap Warning { get => warning; set => warning = value; }
        public Bitmap Explosion { get => explosion; set => explosion = value; }
    }
}
