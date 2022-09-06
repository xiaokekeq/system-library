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
    public partial class Updata : Form
    {
        Dao dao = new Dao();
        public string data = "";
        public Updata(string data)
        {
            this.data = data;
            InitializeComponent();
            string sql = $"select * from BookInformation where 书号='{data}';";
            IDataReader dc=dao.read(sql);
            dc.Read();
            textBox1.Text = dc[0].ToString();
            textBox2.Text = dc[1].ToString();
            textBox3.Text = dc[2].ToString();
            textBox4.Text = dc[3].ToString();
            textBox5.Text = dc[4].ToString();
            textBox6.Text = dc[5].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            string sql = $"update BookInformation set 价格='{textBox5.Text}',出版社='{textBox4.Text}',作者='{textBox3.Text}',书名='{textBox2.Text}',数量='{textBox6.Text}' where 书号='{data}';";
            int n = dao.Execute(sql);
            if (n > 0)
            {
                MessageBox.Show("修改成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("修改失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dao.Daoclose();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }
    }
}
