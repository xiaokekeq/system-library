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
    public partial class User_System : Form
    {
        string xuehao="";
        
        public User_System(string xuehao)
        {
            InitializeComponent();
            this.xuehao =xuehao;
        }
        public User_System()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lend();
        }
        void lend()
        {
            lend l = new lend(xuehao);
            this.Hide();
            l.ShowDialog();
            this.Show();
        }
        private void User_System_Load(object sender, EventArgs e)
        {
           
            
            Dao dao = new Dao();
            string sql = $"select * from reader where 学号='{xuehao}'";
            IDataReader dc = dao.read(sql);
            dataGridView1.Rows.Clear();
            while(dc.Read())
            {
                label4.Text = $"{dc[0].ToString()}";
                label5.Text = $"{dc[1].ToString()}";
                label6.Text = $"{dc[2].ToString()}";
                label8.Text = $"{dc[3].ToString()}";
                dataGridView1.Rows.Add(dc[4].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Dao dao = new Dao();
            string sql = $"select * from reader where 学号='{xuehao}'";
            string sql1 = $"select * from User_Table where 学号='{xuehao}'";
            modify_Personal_Information mpi = new modify_Personal_Information(sql,sql1,label8.Text);
            this.Hide();
            mpi.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.Value.ToString()=="0")
            {
                MessageBox.Show("(0不是书籍)");
            }
            else
            {
                Dao dao = new Dao();
                int num = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                string sql = $"update BookInformation set 数量=数量+1 where 书号='{num}';";
                string sql1 = $"select COUNT(已借阅书籍) from reader;";
                IDataReader dc = dao.read(sql1);
                dc.Read();
                int n = Convert.ToInt16(dc[0].ToString());
                string sql2 = $"update reader set 已借阅书籍=n;";
                string del = $"delete from reader where 书号={num};";
                dao.Execute(sql);
                dao.Execute(del);
                MessageBox.Show("还书成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dao.Daoclose();

            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            User_System_Load (sender,e);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            button4_Click(sender, e);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
