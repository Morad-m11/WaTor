using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WaTor_2
{
    public interface IField
    {
        bool IsEmpty { get; set; }

        int PosX { get; set; }

        int PosY { get; set; }

        Color CellColor { get; set; }
    }
}