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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void 书籍管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookManage bookManage = new BookManage();
            this.Hide();
            bookManage.ShowDialog();
            this.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckUserLend cul = new CheckUserLend();
            this.Hide();
            cul.ShowDialog();
            this.Show();
        }

        private void 系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("图书管理系统\nversion:1.0");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookManage bookManage = new BookManage();
            this.Hide();
            bookManage.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckUserLend cul = new CheckUserLend();
            this.Hide();
            cul.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManage um=new UserManage();
            this.Hide();
            um.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserManage um = new UserManage();
            this.Hide();
            um.ShowDialog();
            this.Show();
        }
    }
}
