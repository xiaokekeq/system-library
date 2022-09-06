using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 数据库连接;

namespace Library_System
{
    public partial class lend : Form
    {
        string xuehao = "";
        public lend(string data)
        {
            InitializeComponent();
            this.xuehao = data;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {

            Dao dao = new Dao();
            int number = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
            if (number<1)
            {
                MessageBox.Show("库存不足","抱歉",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                int num = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                string sql= $"update BookInformation set 数量=数量-1 where 书号='{num}';";
                string sqlreader = $"select 学号,姓名,联系电话,已借阅书籍 from reader where 学号='{xuehao}'";
                IDataReader dc = dao.read(sqlreader);
                int n = 0;
                string readerID="", readerName="";
                int p=0;
                while (dc.Read())
                {
                    n = Convert.ToInt32(dc[3].ToString());
                    readerID = dc[0].ToString();
                    readerName = dc[1].ToString();
                    p = Convert.ToInt32(dc[2]);
                }      
                string sql1 = $"insert into reader values('{readerID}','{readerName}',{p},'{(n+1).ToString()}','{num}');";
                dao.Execute(sql);
                dao.Execute(sql1);
                MessageBox.Show("借出成功","成功",MessageBoxButtons.OK,MessageBoxIcon.Information);
               
            }
        }

        private void lend_Load(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            string sql = $"select * from BookInformation";
            IDataReader dc = dao.read(sql);
            dataGridView1.Rows.Clear();
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lend_Load(sender, e);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("图书不够请联系工作人员", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
