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
    public partial class BookManage : Form
    {
        public BookManage()
        {
            InitializeComponent();
            
        }

        private void BookManage_Load(object sender, EventArgs e)
        {
            tableShow();
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString(); 
            
        }
        //在表格控件中显示读取的书籍信息
        public void tableShow()
        {
            dataGridView1.Rows.Clear(); //清空已存在的书籍信息
            DBLink dblink = new DBLink();
            string sql = "select * from t_book;";
            IDataReader dc = dblink.read(sql);
            string a0,a1,a2,a3,a4,a5; //对应每一列的值
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

        private void button2_Click(object sender, EventArgs e) //编辑图书信息
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string author = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string publisher = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string price = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                string num = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                editBook edit = new editBook(id,name,author,publisher,price,num); //传递参数
                edit.ShowDialog();

                tableShow(); //刷新界面
            }
            catch
            {
                MessageBox.Show("Error");
            }
            
        }

        private void button3_Click(object sender, EventArgs e) //删除图书键
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString(); //获取书号
                label2.Text = id + dataGridView1.SelectedRows[0].Cells[1].Value.ToString(); //标签2显示书号书名
                DialogResult dr = MessageBox.Show("是否确认删除？","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from t_book where book_id='{id}'";
                    DBLink dblink = new DBLink();
                    if (dblink.Execute(sql) > 0)
                    {
                        MessageBox.Show("已删除该书籍信息！");
                        tableShow();
                    }
                    else
                    {
                        MessageBox.Show("删除失败"+sql);
                    }
                    dblink.Close();
                }
            }
            catch
            {
                MessageBox.Show("未选择图书!无法执行删除操作！","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e) //点击事件
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString(); //获取书号
            label2.Text = id + dataGridView1.SelectedRows[0].Cells[1].Value.ToString(); //标签2显示书号书名
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addBook a = new addBook();
            a.ShowDialog();
            tableShow();
        }
        //编码查询引用
        public void tableByid()
        {
            dataGridView1.Rows.Clear(); //清空已存在的书籍信息
            DBLink dblink = new DBLink();
            string sql = $"select * from t_book where book_id='{textBox1.Text}';";
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
        private void button5_Click(object sender, EventArgs e) //编码查询
        {
            tableByid();
            textBox1.Text = "";//清空输入
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tableShow();
        }

        private void button6_Click(object sender, EventArgs e) //按书名查询
        {
            tableByName();
            textBox2.Text = "";
        }

        private void button7_Click(object sender, EventArgs e) //按作者查询
        {
            tableByAuthor();
            textBox3.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.SelectedRows.Count; //获取选择行数
            string sql = $"delete from t_book where book_id in(";
            for(int i = 0; i < n; i++)
            {
                sql += $"'{dataGridView1.SelectedRows[i].Cells[0].Value.ToString()}',";
            }
            sql = sql.Remove(sql.Length - 1);
            sql += ")";
            MessageBox.Show(sql);
            DBLink dblink = new DBLink();
            if (dblink.Execute(sql) > n - 1)
            {
                MessageBox.Show($"批量删除图书信息成功!\n成功删除{n}条信息");
                tableShow();
            }
            else
            {
                MessageBox.Show("图书信息删除失败！\n请检查书籍数据");
            }
        }
    }
}
