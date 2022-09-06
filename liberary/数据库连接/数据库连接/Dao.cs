using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace 数据库连接
{
    public class Dao
    {
        public Dao(string server)
        {
            this.server = server;
        }
        public Dao()
        {

        }
        string server;
        SqlConnection sc;
        public SqlConnection connect()//连接数据库
        {
            string conString = $"server = {server}; Initial Catalog = Bookmanage; Integrated Security = True";
            sc = new SqlConnection(conString);
            sc.Open();
            return sc;     
        }
        public SqlCommand command(string sql)//创建用于执行数据库操作对象
        {
            SqlCommand Scmd = new SqlCommand(sql, connect());
            return Scmd;
        }
        public int Execute(string sql)//用来增删改
        {
            return command(sql).ExecuteNonQuery();
        }
        public SqlDataReader read(string sql)//读取数据
        {
            return command(sql).ExecuteReader();
        }
        public void Daoclose()
        {
            sc.Close();
        }
    }
}
