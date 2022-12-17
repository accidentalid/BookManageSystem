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
    public partial class UserManage : Form
    {
        public UserManage()
        {
            InitializeComponent();
        }

        private void UserManage_Load(object sender, EventArgs e)
        {
            userShow();
        }

        public void userShow()
        {
            dataGridView1.Rows.Clear(); //清空已存在的书籍信息
            DBLink dblink = new DBLink();
            string sql = "select * from t_user;";
            IDataReader dc = dblink.read(sql);
            string a0, a1, a2, a3, a4; //对应每一列的值
            while (dc.Read())
            {
                a0 = dc[0].ToString();
                a1 = dc[1].ToString();
                a2 = dc[2].ToString();
                a3 = dc[3].ToString();
                a4 = dc[4].ToString();

                string[] table = { a0, a1, a2, a4};
                dataGridView1.Rows.Add(table);
                //dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());
            }
            dc.Close();
            dblink.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUser au = new AddUser();
            au.ShowDialog();
            userShow();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString(); //获取用户id
                
                DialogResult dr = MessageBox.Show("是否确认删除？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from t_user where user_id='{id}'";
                    DBLink dblink = new DBLink();
                    if (dblink.Execute(sql) > 0)
                    {
                        MessageBox.Show("已删除该用户信息！");
                        userShow();
                    }
                    else
                    {
                        MessageBox.Show("删除失败" + sql);
                    }
                    dblink.Close();
                }
            }
            catch
            {
                MessageBox.Show("未选择用户!无法执行删除操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
