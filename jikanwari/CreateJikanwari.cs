using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jikanwari
{
    public  class CreateJikanwari
    {
        public JikanwariData jikanwariData;
        public CreateJikanwari( JyugyouData jyugyouData)
        {
            jikanwariData = new JikanwariData();
            Look look = new Look();
            jyugyouData.SetTotal();
            

            jikanwariData = SetJyugyou(jyugyouData, jikanwariData, look );
            //MessageBox.Show(jyugyouData.jTable.jTable.Rows[0]["jyugyouName"].ToString());
            //MessageBox.Show(jyugyouData.jTable.jTable.Rows[1][5].ToString());
        }

        private JikanwariData SetJyugyou(JyugyouData jyugyouData, JikanwariData InJikanwariData, Look Inlook)
        {
            JikanwariData jikanwariData = new JikanwariData(InJikanwariData); 
           
            for(int i = 0; i < jyugyouData.jTable.Rows.Count; i++)
            { 
                Look look= new Look(Inlook);
                if ((int)jyugyouData.jTable.Rows[i][0] == 13)
                {
                    //デバッグ用
                    Console.WriteLine("stop");
                }
                int jyugyouCount = 0;
                bool jyugyouEnd=false;
                foreach(int num in jikanwariData.jikanwari)
                {
                    if (num == (int)jyugyouData.jTable.Rows[i]["Id"])
                    {
                        jyugyouCount++;
                        if (jyugyouCount >= (int)jyugyouData.jTable.Rows[i]["count"])
                        {
                            jyugyouEnd= true;
                        }
                    }
                }//参照している授業が割り当て終わっているか確認
                if (jyugyouEnd) continue;//割り当て済みなので次に
                
                jikanwariData.jikanwari[look.y, look.x] = (int)jyugyouData.jTable.Rows[i]["Id"];
                

                if (look.End()==false)
                {
                    if (look.count() == jyugyouData.total)
                    {
                        while (!look.End())
                        {
                            look.Next();
                            jikanwariData.jikanwari[look.y, look.x] = 99;//休みの仮置き
                        }
                        break;
                    }//授業数分の割り当て終了
                    look.Next();

                    JikanwariData outJikanwari =SetJyugyou(jyugyouData, jikanwariData,look);

                    if (outJikanwari.jikanwari[3, 4] != 0)
                    {
                        jikanwariData = outJikanwari;
                        break;
                    }
                    
                }
                if (look.End())
                {
                    break;
                }

                
            }

            return jikanwariData;
        }
    }
}
