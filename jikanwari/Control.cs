using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jikanwari
{
    internal class Control
    {
        public JyugyouData jyugyouData = new JyugyouData();
        CreateJikanwari createJikanwari;
        public Control()
        {
            jyugyouData.SetJyugyouData();
        
        
        }

        public void CreateJikanwari(Label[,] jLabels, Label[,] kLabels)
        {
                        
            createJikanwari = new CreateJikanwari(jyugyouData);
            viewLabels(jLabels, kLabels, (int)jyugyouData.cTable.Rows[0][0]);
            //viewのデフォルトの表示クラスは適当なので必要であれば修正
        }
        private void viewLabels(Label[,] jLabels, Label[,] kLabels, int classId)
        {
            

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int id = createJikanwari.jikanwariData.jikanwari[i, j,classId];
                    jLabels[i, j].Text = "NULL";
                    kLabels[i, j].Text = "NULL";
                    DataRow[] jdrs = jyugyouData.jTable.Select("Id=" + id);
                    if (id != 0)
                    {
                        jLabels[i, j].Text = jdrs[0]["JyugyouName"].ToString();

                        DataRow kdrs = jyugyouData.GetKoussiData(id);
                        //if (kdrs[0] != null)
                        //{
                        kLabels[i, j].Text = kdrs["KousiName"].ToString();
                        //}


                    }


                }
            }
        }
    }
}
