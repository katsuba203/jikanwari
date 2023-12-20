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
        public int[,,] jikanwari;

        public JikanwariData(int n) 
        {
            if (n != 0)
            {
                 jikanwari= new int[4,5,n];
            }
            {
                MessageBox.Show("JyugyouDataのコンストラクタの引数が間違っています");
            }
           
        }  
        public JikanwariData( JikanwariData data ) 
        {

            if (data.jikanwari[0,0,0]!=0)
            {
                for (int i = 0;i<4;i++)
                {
                    for(int j = 0;j<5;j++)
                    {
                        for (int k = 0;k<data.jikanwari.GetLength(2);k++)
                        {
                            jikanwari[i, j,k] = data.jikanwari[i,j,k];
                        }
                       
                    }
                }
            }
        }
    }
}
