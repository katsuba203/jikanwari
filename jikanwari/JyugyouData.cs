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

        public int total;
        public static string GetConnectionString()//接続文字列の取得
        {
            return "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\a\\source\\repos\\jikanwari\\jikanwari\\Database1.mdf;Integrated Security=True;Connect Timeout=30";//ConfigurationManager.ConnectionStrings["jikanwari.Properties.Settings.jikanwariDB"].ConnectionString;
        }
        public void SetJyugyouData()
        {
            var connection = new SqlConnection();
            string tbStr = "";
            connection.ConnectionString = GetConnectionString();
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Jyugyou";
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(jTable);
            command.CommandText = @"SELECT * FROM Kousi";
            adapter =new SqlDataAdapter(command);
            adapter.Fill(kTable);

            connection.Close();
            for (int rowindex = 0; rowindex < jTable.Rows.Count; rowindex++)
            {
                for (int colindex = 0; colindex < jTable.Columns.Count; colindex++)
                {
                    tbStr+=(jTable.Rows[rowindex][colindex].ToString() + " ");
                }
                tbStr+=("\n");

            }
            //MessageBox.Show(tbStr);
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
                total += (int)row["count"];
            }
        }
    }
}
