using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaTor_2
{
    class Fish : Player
    {
        public Fish(int posX, int posY, string caller = "fish") :base(posX, posY, caller)
        {
            Age = 0;
        }

        public Fish() { }
    }
}
