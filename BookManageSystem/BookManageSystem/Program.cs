using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManageSystem
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            //Application.Run(new addBook());
            //Application.Run(new Admin());
            //Application.Run(new BookManage());
            //Application.Run(new checkBook());
            //Application.Run(new CheckUserLend());
            //Application.Run(new UserManage());
            //Application.Run(new UserBookManage());
            //Application.Run(new AddUser());
            //Application.Run(new OrderManage());
        }
    }
}
