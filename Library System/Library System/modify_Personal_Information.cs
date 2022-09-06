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
    public partial class modify_Personal_Information : Form
    {
        string data = "";
        string data1 = "";
        string data2 = "";
        int n1 = 0;
        string dc2 = "";
        int n2 = 0;
        public modify_Personal_Information(string data,string data1,string data2)
        {
            Dao dao = new Dao();
            InitializeComponent();
            this.data = data;
            this.data2 = data;
            this.data1 = data1;
            IDataReader dc=dao.read(data);
            IDataReader dc1 = dao.read(data1);
            dc1.Read();
            bool a=dc.Read();
            
            if (data2!="")
            {
                textBox3.Text = dc[0].ToString();
                textBox1.Text = dc1[0].ToString();
                textBox2.Text = dc1[1].ToString();
                textBox4.Text = dc[1].ToString();
                textBox5.Text = dc[2].ToString();
                dc2= dc[0].ToString();
            }
            else
            {
                textBox1.Text = dc1[0].ToString();
                textBox2.Text = dc1[1].ToString();
                textBox3.Text=dc1[2].ToString();
                n1 = 1;
                dc2= dc1[2].ToString();
            }
            dao.Daoclose();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            try
            {             
                int n=0;
                if (n1==1)
                {
                    string sql = "";
                    sql = $"insert into reader values({textBox3.Text},'{textBox4.Text}','{textBox5.Text}','','');";
                    n = dao.Execute(sql);
                    
                }
                else
                {
                    string sql = $"update reader set 姓名='{textBox4.Text}',联系电话='{textBox5.Text}' where 学号='{textBox3.Text}';";
                    n = dao.Execute(sql);
                }


                if (n > 0)
                {
                    MessageBox.Show("修改成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败,出现未知错误",ex.Message , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dao.Daoclose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }
    }
}
