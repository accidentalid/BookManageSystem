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
    public partial class UserOrder : Form
    {
        public UserOrder()
        {
            InitializeComponent();
            tableShow();
        }
        public void tableShow()
        {
            dataGridView1.Rows.Clear(); //清空已存在的书籍信息
            DBLink dblink = new DBLink();
            string sql = $"select [no],[book_name],[date],[price] from v_order where user_id='{Data.UID}';";
            IDataReader dc = dblink.read(sql);
            string a0, a1, a2, a3, a4; //对应每一列的值
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

        private void UserOrder_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                selectByPrice();
            }
            else
            {
                MessageBox.Show("判断条件不能为空！");
            }
            
        }

        public void tableMore(int tag) //查询高价商品
        {
            dataGridView1.Rows.Clear();//清空已存在的信息
            DBLink dblink = new DBLink();
            string sql = $"select [no],[book_name],[date],[price] from v_order where user_id='{Data.UID}' and price>={tag}; ";
            IDataReader dc = dblink.read(sql);
            string a0, a1, a2, a3; //对应每一列的值
            while (dc.Read())
            {
                a0 = dc[0].ToString();
                a1 = dc[1].ToString();
                a2 = dc[2].ToString();
                a3 = dc[3].ToString();


                string[] table = { a0, a1, a2, a3 };
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            dblink.Close();
        }

        public void tableLess(int tag)
        {
            DBLink dblink = new DBLink();
            string sql = $"select [no],[book_name],[date],[price] from v_order where user_id='{Data.UID}' and price<{tag}; ";
            IDataReader dc = dblink.read(sql);
            string a0, a1, a2, a3, a4; //对应每一列的值
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

        //条件查询函数
        public void selectByPrice()
        {
            int tag = int.Parse(textBox1.Text);
            if (radioButton3.Checked == true)
            {
                dataGridView1.Rows.Clear();
                tableLess(tag);
            }
            else
            {
                dataGridView1.Rows.Clear();
                tableMore(tag);
            }        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tableShow();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是退格和数字，则屏蔽输入
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
        }
    }
}
