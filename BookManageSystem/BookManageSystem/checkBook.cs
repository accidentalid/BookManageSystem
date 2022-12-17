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
    public partial class checkBook : Form
    {
        public checkBook()
        {
            InitializeComponent();
            tableShow();
        }
        //显示图书信息
        public void tableShow()
        {
            dataGridView1.Rows.Clear(); //清空已存在的书籍信息
            DBLink dblink = new DBLink();
            string sql = "select * from t_book;";
            IDataReader dc = dblink.read(sql);
            string a0, a1, a2, a3, a4, a5; //对应每一列的值
            while (dc.Read())
            {
                a0 = dc[0].ToString();
                a1 = dc[1].ToString();
                a2 = dc[2].ToString();
                a3 = dc[3].ToString();
                a4 = dc[4].ToString();
                a5 = dc[5].ToString();
                string[] table = { a0, a1, a2, a3, a4, a5 };
                dataGridView1.Rows.Add(table);
                //dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());
            }
            dc.Close();
            dblink.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        

        private void checkBook_Load(object sender, EventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            label4.Text = Data.UMoney.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString(); //获得要借阅的书籍号
            string book_name=dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            int number = int.Parse(dataGridView1.SelectedRows[0].Cells[5].Value.ToString()); //获取库存数
            if (number < 1)
            {
                MessageBox.Show("当前库内已无此书，请联系管理员获取帮助");
            }
            else
            {
                string sql = $"insert into t_borrow(user_id,book_id,[date]) values('{Data.UID}','{id}',getdate());update t_book set number=number-1 where book_id='{id}'" ;
                DBLink dblink=new DBLink();
                if (dblink.Execute(sql) > 1) //执行了两条语句
                {
                    MessageBox.Show($"用户：{Data.UName}  借阅图书《{book_name}》成功");
                    tableShow();
                }
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString(); //获取书号
            label2.Text = id + dataGridView1.SelectedRows[0].Cells[1].Value.ToString(); //标签2显示书号书名
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //书名查询引用,模糊查询
        public void tableByName()
        {
            dataGridView1.Rows.Clear(); //清空已存在的书籍信息
            DBLink dblink = new DBLink();
            string sql = $"select * from t_book where book_name like '%{textBox2.Text}%';";
            IDataReader dc = dblink.read(sql);
            string a0, a1, a2, a3, a4, a5; //对应每一列的值
            while (dc.Read())
            {
                a0 = dc[0].ToString();
                a1 = dc[1].ToString();
                a2 = dc[2].ToString();
                a3 = dc[3].ToString();
                a4 = dc[4].ToString();
                a5 = dc[5].ToString();
                string[] table = { a0, a1, a2, a3, a4, a5 };
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            dblink.Close();
        }
        //按作者查询
        public void tableByAuthor()
        {
            dataGridView1.Rows.Clear(); //清空已存在的书籍信息
            DBLink dblink = new DBLink();
            string sql = $"select * from t_book where author like '%{textBox3.Text}%';";
            IDataReader dc = dblink.read(sql);
            string a0, a1, a2, a3, a4, a5; //对应每一列的值
            while (dc.Read())
            {
                a0 = dc[0].ToString();
                a1 = dc[1].ToString();
                a2 = dc[2].ToString();
                a3 = dc[3].ToString();
                a4 = dc[4].ToString();
                a5 = dc[5].ToString();
                string[] table = { a0, a1, a2, a3, a4, a5 };
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            dblink.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e) //书名查找
        {
            tableByName();
            textBox2.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tableByAuthor();
            textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString(); //获得要购买的书籍号
            string book_name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            int number = int.Parse(dataGridView1.SelectedRows[0].Cells[5].Value.ToString()); //获取库存数
            int price = int.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());//获取售价
            if (number < 1)
            {
                MessageBox.Show("当前库内已无此书，请联系管理员获取帮助");
                return;
            }
            if (price > Data.UMoney) //余额不足时
            {
                MessageBox.Show("账户内余额不足，请充值后进行购买");
            }
            else
            {
                string sql = $"insert into t_order(user_id,book_id,[date]) values('{Data.UID}','{id}',getdate());update t_user set poket={Data.UMoney-price} where user_id='{Data.UID}';update t_book set number=number-1 where book_id='{id}'";
                DBLink dblink = new DBLink();
                if (dblink.Execute(sql) > 2) //执行了三条语句
                {
                    MessageBox.Show($"用户：{Data.UName}  购买图书《{book_name}》成功");
                    tableShow();
                }
                Data.UMoney -= price;
                label4.Text = Data.UMoney.ToString();
            }
        }
    }
}
