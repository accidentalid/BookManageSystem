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
    public partial class addBook : Form
    {
        public addBook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_id.Text != "" && textBox_name.Text != "" && textBox_num.Text != "" && textBox_price.Text != "") //作者，出版社可以为空
            {
                DBLink dblink = new DBLink();
                string sql = $"insert into t_book values('{textBox_id.Text}','{textBox_name.Text}','{textBox_author.Text}','{textBox_publisher.Text}','{textBox_price.Text}',{textBox_num.Text})";
                int n = dblink.Execute(sql);
                if (n > 0)
                {
                    MessageBox.Show("添加成功！");
                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
                textBox_id.Text = "";
                textBox_name.Text = "";
                textBox_author.Text = "";
                textBox_publisher.Text = "";
                textBox_price.Text = "";
                textBox_num.Text = "";
            }
            else
            {
                MessageBox.Show("输入了不允许的空值！");
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox_id.Text = "";
            textBox_name.Text = "";
            textBox_author.Text = "";
            textBox_publisher.Text = "";
            textBox_price.Text = "";
            textBox_num.Text = "";
        }

        private void addBook_Load(object sender, EventArgs e)
        {

        }
    }
}
