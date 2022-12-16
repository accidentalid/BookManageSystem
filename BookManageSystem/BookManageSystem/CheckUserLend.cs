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
    public partial class CheckUserLend : Form
    {
        public CheckUserLend()
        {
            InitializeComponent();
            tableShow();
        }
        //在表格控件中显示书籍的借阅信息
        public void tableShow()
        {
            dataGridView1.Rows.Clear(); //清空已存在的书籍信息
            DBLink dblink = new DBLink();
            string sql = "select [no],user_id,book_id,[date] from View_borrow_user;";
            IDataReader dc = dblink.read(sql);
            string a0, a1, a2, a3; //对应每一列的值
            while (dc.Read())
            {
                a0 = dc[0].ToString();
                a1 = dc[1].ToString();
                a2 = dc[2].ToString();
                a3 = dc[3].ToString();
                //a4 = dc[4].ToString();

                string[] table = { a0, a1, a2, a3 };
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            dblink.Close();
        }
        //按读者查询
        public void tableByUser()
        {
            dataGridView1.Rows.Clear(); //清空已存在的书籍信息
            DBLink dblink = new DBLink();
            string sql = $"select [no],user_id,book_id,[date] from View_borrow_user where user_id='{textBox2.Text}';";
            IDataReader dc = dblink.read(sql);
            string a0, a1, a2, a3; //对应每一列的值
            while (dc.Read())
            {
                a0 = dc[0].ToString();
                a1 = dc[1].ToString();
                a2 = dc[2].ToString();
                a3 = dc[3].ToString();
                //a4 = dc[4].ToString();

                string[] table = { a0, a1, a2, a3 };
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            dblink.Close();
        }
        private void CheckUserLend_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            tableByUser();
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableShow();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
