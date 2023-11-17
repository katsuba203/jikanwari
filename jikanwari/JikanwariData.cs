using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jikanwari
{
    public class JikanwariData
    {
        //科目名を割り付ける対象　時間割の成果物
        public int[,] jikanwari=new int[4,5];

        public JikanwariData() { }  
        public JikanwariData( JikanwariData data ) 
        {
            if (data.jikanwari[0,0]!=0)
            {
                for (int i = 0;i<4;i++)
                {
                    for(int j = 0;j<5;j++)
                    {
                        jikanwari[i, j] = data.jikanwari[i,j];
                    }
                }
            }
        }
    }
}
