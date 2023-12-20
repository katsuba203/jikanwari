using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jikanwari
{
    internal class UseSQL
    {
        SqlConnection connection = new SqlConnection();
        public UseSQL() 
        {
            
            
            connection.ConnectionString = GetConnectionString();
            connection.Open();


        }
        public static string GetConnectionString()//接続文字列の取得
        {
            return "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\a\\source\\repos\\jikanwari\\jikanwari\\Database1.mdf;Integrated Security=True;Connect Timeout=30";//ConfigurationManager.ConnectionStrings["jikanwari.Properties.Settings.jikanwariDB"].ConnectionString;
        }
        public void CloseDB()
        {
            connection.Close();
        }
        public DataTable UseSelect(string sql)
        {
            DataTable dt = new DataTable();
            var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM "+sql;
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);

            return dt;
        }
    }
}
