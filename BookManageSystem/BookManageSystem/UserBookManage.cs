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
    public partial class UserBookManage : Form
    {
        public UserBookManage()
        {
            InitializeComponent();
            tableShow();
        }
        
        
        public void tableShow()
        {
            dataGridView1.Rows.Clear(); //清空已存在的用户信息
            DBLink dblink = new DBLink();
            string sql = $"select [no],book_id,book_name,[date] from View_borrow_user where user_id='{Data.UID}';";
            IDataReader dc = dblink.read(sql);
            string a0, a1, a2, a3; //对应每一列的值
            while (dc.Read())
            {
                a3 = dc[0].ToString();
                a0 = dc[1].ToString();
                a1 = dc[2].ToString();
                a2 = dc[3].ToString();
                string[] table = { a3,a0, a1, a2 };
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            dblink.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string no = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string book_id=dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string book_name=dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            string sql = $"delete from t_borrow where [no]={no};update t_book set number=number+1 where book_id={book_id}";
            DBLink dblink = new DBLink();
            if (dblink.Execute(sql) > 1)
            {
                MessageBox.Show($"用户 {Data.UName} 成功归还书籍 《{book_name}》");
                tableShow();
            }
        }

        private void UserBookManage_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
