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
            tableShow();
        }
        public void tableShow()
        {
            dataGridView1.Rows.Clear(); //清空已存在的用户信息
            DBLink dblink = new DBLink();
            string sql = $"select book_name from View_borrow_user where user_id='{Data.UID}';";
            IDataReader dc = dblink.read(sql);
            string a0, a1, a2, a3; //对应每一列的值
            while (dc.Read())
            {
                a3 = dc[0].ToString();
                //a0 = dc[1].ToString();
                //a1 = dc[2].ToString();
                //a2 = dc[3].ToString();
                string[] table = { a3 };
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            dblink.Close();
            Data.MaxLend = dataGridView1.RowCount;
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
            tableShow();
        }

        private void 我的ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserBookManage ubm=new UserBookManage();
            this.Hide();
            ubm.ShowDialog();
            this.Show();
            tableShow();
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
            tableShow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserBookManage ubm = new UserBookManage();
            this.Hide();
            ubm.ShowDialog();
            this.Show();
            tableShow();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 账户充值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Recharge rc = new Recharge();
            rc.ShowDialog();
        }

        private void 我的订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserOrder userOrder = new UserOrder();
            this.Hide();
            userOrder.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserOrder userOrder = new UserOrder();
            this.Hide();
            userOrder.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Recharge rc = new Recharge();
            rc.ShowDialog();
        }
    }
}
