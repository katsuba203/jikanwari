using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jikanwari
{
    internal class Look
    {
        public int x = 0;
        public int y = 0; 
        public Look() { }
        public Look(Look look)
        {
            this.x = look.x;
            this.y = look.y;
        }
        public void Next()
        {
            if (y >= 3)
            {
                y = 0;x++;
            }//X,Yを移動
            else
            {
                y++;
            }
        }
        public bool End()
        {
            if (x >= 4 && y >= 3) return true;
            else return false;
        }
        public int count()
        {
            if(x==y) return (x + 1) * (y + 1);
            return (x + 1) * (y + 1)+x;
        }
    }
}
