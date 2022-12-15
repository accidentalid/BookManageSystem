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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
            label1.Text = $"    欢迎用户 {Data.UName}\n使用本图书管理系统";
        }

        private void User_Load(object sender, EventArgs e)
        {

        }

        private void 书籍管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBook checkBook = new checkBook();
            this.Hide();
            checkBook.ShowDialog();
            this.Show();
        }

        private void 我的ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserBookManage ubm=new UserBookManage();
            this.Hide();
            ubm.ShowDialog();
            this.Show();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("感谢使用本图书管理系统，请联系管理员寻求帮助");
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            this.Close();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkBook checkBook = new checkBook();
            this.Hide();
            checkBook.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserBookManage ubm = new UserBookManage();
            this.Hide();
            ubm.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
