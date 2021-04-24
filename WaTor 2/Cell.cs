using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WaTor_2
{
    class Cell : IField
    {
        public bool IsEmpty { get; set; }

        public Color CellColor { get; set; }

        public int PosX { get; set; }
        
        public int PosY { get; set; }

        public Cell(int posX, int posY, string caller)
        {
            PosX = posX;
            PosY = posY;
            IsEmpty = false;

            if (caller == "shark")
                CellColor = Color.IndianRed;
            else
                CellColor = Color.ForestGreen;
        }

        public Cell(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
            IsEmpty = true;
            CellColor = Color.Blue;
        }

        public Cell() { }
    }
}
