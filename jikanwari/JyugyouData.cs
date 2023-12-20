using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jikanwari
{
    public class JyugyouData
    {
        int Id;
        string jyugyouName;//授業を連続して配置等で使用
        int kousiID;
        string kyousitu;
        string jyukouClass;
        public DataTable jTable = new DataTable();
        public DataTable kTable = new DataTable();
        public DataTable cTable = new DataTable();

        public int total;
        
        public void SetJyugyouData()
        {
            UseSQL useSQL = new UseSQL();
            jTable=useSQL.UseSelect("Jyugyou");
            kTable = useSQL.UseSelect("Kousi");
            cTable = useSQL.UseSelect("Class");
            string str="";
            foreach(DataRow row in jTable.Rows)
            {
                str += row[1].ToString();
                str += "\n";
            }
            MessageBox.Show(str);
            useSQL.CloseDB();

        }

        public void SetTotal()
        {
            total = 0;
            if(jTable==null)
            {
                MessageBox.Show("SetTotalがDataTableが存在しないのに呼び出されました");
                return;
            }
            foreach(DataRow row in jTable.Rows)
            {
                total += (int)row["Count"];
            }
        }
        public DataRow GetKoussiData(int id)//授業IDから講師の情報を取得
        {
            DataRow[] jdrs = jTable.Select("Id=" + id);
            int kId = (int)jdrs[0]["KousiID"];
            DataRow[] kdrs = kTable.Select("KousiID=" + kId);
            return kdrs[0];
        }
        public string[] GetClass()
        {
           
            string[] str = new string[cTable.Rows.Count];
            for(int i = 0; i< cTable.Rows.Count; i++)
            {
                str[i] = cTable.Rows[i]["Class"].ToString();
            }
            
            return str;
        }
        public int GetClassCount()
        {
            return cTable.Rows.Count;
        }
    }
}
