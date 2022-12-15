using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManageSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=""&&textBox2.Text!="")
            {
                login();
            }
            else
            {
                MessageBox.Show("输入项存在空值，请重新输入");
            }
        }
        //登陆验证，允许登录时返回真
        public void login() 
        {
            //选中用户
            if (radioButtonUser.Checked == true)
            {
                DBLink dblink = new DBLink();
                string sql = $"select * from t_user where user_id='{textBox1.Text}' and user_psw='{textBox2.Text}'";
                IDataReader dc=dblink.read(sql);
                if (dc.Read())
                {
                    Data.UID = dc["user_id"].ToString();
                    Data.UName= dc["name"].ToString();

                    MessageBox.Show("登录成功！");
                    //跳转新窗体
                    User user = new User();
                    this.Hide();
                    user.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("登陆失败！");
                }
                dblink.Close();
            }
            //选中管理员
            if(radioButtonAdmin.Checked == true)
            {
                DBLink dblink = new DBLink();
                string sql = $"select * from t_admin where admin_id='{textBox1.Text}' and admin_psw='{textBox2.Text}'";
                IDataReader dc = dblink.read(sql);
                if (dc.Read())
                {
                    MessageBox.Show("登录成功！");
                    //跳转新窗体
                    Admin admin = new Admin();  
                    this.Hide();
                    admin.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("登陆失败！");
                }
                dblink.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
