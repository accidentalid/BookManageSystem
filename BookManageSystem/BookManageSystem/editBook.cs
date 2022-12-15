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
    public partial class editBook : Form
    {
        string ID = "";
        public editBook()
        {
            InitializeComponent();
        }

        public editBook(string book_id,string name,string author,string publisher,string price,string num)
        {
            InitializeComponent();
            ID=textBox_id.Text = book_id;
            textBox_author.Text = author;
            textBox_name.Text = name;
            textBox_publisher.Text = publisher;
            textBox_price.Text= price;
            textBox_num.Text= num;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update t_book set book_id='{textBox_id.Text}',book_name='{textBox_name.Text}',author='{textBox_author.Text}',publisher='{textBox_publisher.Text}',price={textBox_price.Text},number='{textBox_num.Text}' where book_id='{ID}'";
            DBLink dblink = new DBLink();
            if (dblink.Execute(sql)>0)
            {
                MessageBox.Show("修改成功!");
                this.Close();
            }
        }

        private void editBook_Load(object sender, EventArgs e)
        {

        }
    }
}
