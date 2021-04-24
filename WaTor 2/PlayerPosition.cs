using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaTor_2
{
    public class PlayerPosition
    {
        public string Type { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public List<PlayerPosition> PlayerPositions { get; set; }

        //public PlayerPosition(string type, int x, int y)
        //{
        //    Type = type;
        //    X = x;
        //    Y = y;
        //}

        public void UpdatePositions(List<PlayerPosition> ToAdd, List<PlayerPosition> ToRemove)
        {

        }

        public void AddPos(string type)
        {

        }
    }
}
