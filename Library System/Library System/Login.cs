using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 数据库连接;

namespace Library_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                login1();
            }
            else
            {
                MessageBox.Show("账号或密码为空", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void login1()
        {
            Dao dao = new Dao();
            if (radioButtonadmin.Checked == true)
            {
                string sql = $"select * from admin where adminID='{textBox1.Text}'and adminPsw='{textBox2.Text}'";
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    MessageBox.Show("欢迎使用图书管理系统", "登录成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Admin_System admin = new Admin_System();
                    admin.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("账号或密码错误", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dc.Close();
            }
            else
            {
                string sql = $"select * from User_Table where UserID='{textBox1.Text}'and UserPsw='{textBox2.Text}'";
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    MessageBox.Show("欢迎使用图书管理系统", "登录成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    User_System user = new User_System($"{dc[2].ToString()}");
                    user.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("账号或密码错误", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dc.Close();
            }
            dao.Daoclose();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            enroll();
        }
        void enroll()
        {
            Dao dao = new Dao();
            if (radioButtonadmin.Checked == true)
            {
                try
                {
                    string sql = $"insert into admin values ('{textBox1.Text}', '{textBox2.Text}'); ";
                    int dc = dao.Execute(sql);
                    if (dc > 0)
                    {
                        MessageBox.Show("欢迎使用图书管理系统", "注册成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Admin_System admin = new Admin_System();
                        admin.ShowDialog();
                        this.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("账号已存在", "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    IDataReader num = dao.read($"select count(*) from  User_Table");
                    num.Read();
                    string sql = $"insert into User_Table values ('{textBox1.Text}', '{textBox2.Text}','{1001+Convert.ToInt32(num[0].ToString())}')";
                    int n = dao.Execute(sql);
                    //IDataReader dc = dao.read(sql);
                    if (n>0)
                    {
                        //dc.Read();
                        MessageBox.Show("成功", "注册成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Hide();
                       // User_System user = new User_System();
                        //user.ShowDialog();
                       // this.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("账号已存在", "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            dao.Daoclose();
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                radioButtonadmin_CheckedChanged(sender, e);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                radioButtonadmin_CheckedChanged(sender, e);
            }
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }
        private void radioButtonadmin_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonadmin.Checked==true)
            {
                textBox1.Text = "admin";
                textBox2.Text = "admin";
            }
            else
            {
                textBox1.Text = "User";
                textBox2.Text = "User";
            }
        }

        private void Login_Load_1(object sender, EventArgs e)
        {
            Dao d = new Dao(textBox3.Text);
           
            timer1.Enabled = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string fileName = Application.StartupPath + @"..\使用帮助.pdf";
            try
            {
                Process.Start(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"打开错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            button2_Click_1(sender, e);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2_Click(sender, e);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            button2_Click_1(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
        }
    }
}
