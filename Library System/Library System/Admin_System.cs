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
    public partial class Admin_System : Form
    {
        public Admin_System()
        {
            InitializeComponent();
        }

        private void Admin_System_Load(object sender, EventArgs e)
        {
            table();
        }
        public void table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from BookInformation";
            Dao dao = new Dao();
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(),dc[2].ToString(),dc[3].ToString(), dc[4].ToString(), dc[5].ToString());
            }
            //dataGridView1.Rows[0].Cells[0].Value= "123";
            dao.Daoclose();          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin_AddBook add = new admin_AddBook();
            add.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Updata up = new Updata(dataGridView1.SelectedCells[0].Value.ToString());      
            up.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            table();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            Dao dao = new Dao();
            string sql = $"DELETE FROM BookInformation WHERE 书号='{dataGridView1.SelectedCells[0].Value.ToString()}';";
            int n = dao.Execute(sql);
            if (n > 0)
            {
                MessageBox.Show("删除成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("删除失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dao.Daoclose();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = $"select * from BookInformation where 书号='{textBox2.Text}';";
            IDataReader dc = dao.read(sql);
            if (dc.Read())
            {
                MessageBox.Show("查询成功","成功",MessageBoxButtons.OK,MessageBoxIcon.Information);
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());
            }
            else
            {
                MessageBox.Show("查询失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dao.Daoclose();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = $"select * from BookInformation where 书名='{textBox1.Text}';";
            IDataReader dc = dao.read(sql);
            if (dc.Read())
            {
                MessageBox.Show("查询成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());
                }
               
            }
            else
            {
                MessageBox.Show("查询失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dao.Daoclose();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            button4_Click(sender, e);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("这是管理员界面","欢迎使用",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            toolStripMenuItem8_Click(sender, e);
        }
    }
}
