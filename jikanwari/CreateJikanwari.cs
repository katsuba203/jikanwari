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
        private JikanwariData subdata ;
        private int best = 0;
        public CreateJikanwari( JyugyouData jyugyouData)
        {
            jikanwariData=new JikanwariData(jyugyouData.GetClassCount());
            subdata=new JikanwariData(jyugyouData.GetClassCount());
            Look look = new Look(jyugyouData.GetClassCount());
            jyugyouData.SetTotal();
            

            jikanwariData = SetJyugyou(jyugyouData, jikanwariData, look );
            if(jikanwariData.jikanwari[0,0,0] == 0)
            {
                jikanwariData = subdata;
            }//割り当てに失敗していた場合最大値を成果物とする
            //MessageBox.Show(jyugyouData.jTable.jTable.Rows[0]["jyugyouName"].ToString());
            //MessageBox.Show(jyugyouData.jTable.jTable.Rows[1][5].ToString());
        }
        
        private JikanwariData SetJyugyou(JyugyouData jyugyouData, JikanwariData InJikanwariData, Look Inlook)
        {
            JikanwariData jikanwariData = new JikanwariData(InJikanwariData); 
           


            for(int i = 0; i < jyugyouData.jTable.Rows.Count; i++)
            { 
                Look look= new Look(Inlook);
                
                int jyugyouID = (int)jyugyouData.jTable.Rows[i]["Id"];
                bool jyugyouEnd=false;
                
                int jyugyouCount = 0;
                foreach(int num in jikanwariData.jikanwari)
                {
                    if (num == jyugyouID)
                    {
                        jyugyouCount++;
                        if (jyugyouCount >= (int)jyugyouData.jTable.Rows[i]["Count"])
                        {
                            jyugyouEnd= true;
                        }
                    }
                }//参照している授業が割り当て終わっているか確認
                if (jyugyouEnd) continue;//割り当て済みなので次に

                //---------------ここから先で各種条件の確認----------------------

                //曜日
                if (!CheckWeek(jyugyouID, look, jyugyouData)) continue;



                jikanwariData.jikanwari[look.y, look.x,look.z] = jyugyouID;    //授業の割り当て
                

                if (look.End()==false)
                {
                    if (look.count() == jyugyouData.total)
                    {
                        while (!look.End())
                        {
                            look.Next();
                            jikanwariData.jikanwari[look.y, look.x,look.z] = 99;//休みの仮置き
                        }
                        break;
                    }//授業数分の割り当て終了
                    look.Next();

                    JikanwariData outJikanwari =SetJyugyou(jyugyouData, jikanwariData,look);    //次の割り当てを行う

                    if (outJikanwari.jikanwari[3, 4,jyugyouData.GetClassCount()-1] != 0)
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

            //最高記録を保存しておく
            if (best < Inlook.count())
            {
                subdata = jikanwariData;
            }
            return jikanwariData;
        }

        bool CheckWeek(int id,Look look,JyugyouData jyugyouData)
        {
            char[] week = {'月','火','水','木','金' };
            DataRow kdata = jyugyouData.GetKoussiData(id);
            if ((int)kdata[0] == 11)
            {
                Console.WriteLine("stop");
            }
            foreach (char c in kdata["NGyoubi"].ToString())
            {
                if (week[look.x] == c) return false; 
            }
            return true;
        }


    }
}
