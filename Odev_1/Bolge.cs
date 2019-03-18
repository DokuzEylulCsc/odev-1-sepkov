using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Bolge
    {
        private int x, y;
        private bool askerVarMı;
        public Bolge(int x, int y,bool asker)
        {
            this.x = x;
            this.y = y;
            this.askerVarMı = asker;
        }
        public int ReturnX()
        {
            return x;
        }
        public int ReturnY()
        {
            return y;
        }
        public bool ReturnAsker()
        {
            return askerVarMı;
        }
    }
}
