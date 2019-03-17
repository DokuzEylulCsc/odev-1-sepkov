using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Bolge
    {
        private int x, y;
        public Bolge(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int ReturnX()
        {
            return x;
        }
        public int ReturnY()
        {
            return y;
        }
    }
}
