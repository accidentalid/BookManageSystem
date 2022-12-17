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
    public partial class Recharge : Form
    {
        public Recharge()
        {
            InitializeComponent();
        }

        private void 账户充值_Load(object sender, EventArgs e)
        {
            label7.Text = Data.UID.ToString();
            label8.Text = Data.UName.ToString();
            label4.Text = Data.UMoney.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!= "")
            {
                DBLink dblink = new DBLink();
                int addMoney = int.Parse(textBox1.Text);
                string sql = $"update t_user set poket+={addMoney} where user_id='{Data.UID}';";
                int n = dblink.Execute(sql);
                if (n > 0)
                {
                    Data.UMoney += addMoney;
                    MessageBox.Show("账户充值成功");
                    label4.Text = Data.UMoney.ToString();
                }
                else
                {
                    MessageBox.Show("充值失败！");
                }
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("输入的充值金额不能为空!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
