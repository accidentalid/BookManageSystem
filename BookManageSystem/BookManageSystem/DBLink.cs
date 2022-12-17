using System.Data.SqlClient;

namespace BookManageSystem
{
    internal class DBLink //用于连接数据库
    {
        SqlConnection con;
        public SqlConnection connect()
        {
            string str = @"Data Source=LAPTOP-8DFCNC8K;Initial Catalog=BookDB;Integrated Security=True"; //数据库链接字符
            con = new SqlConnection(str); //创建数据库链接对象
            con.Open(); //打开数据库
            return con; //返回数据库链接对象
        }
        public SqlCommand command(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql,connect());
            return cmd;
        }
        public int Execute(string sql) //更新操作
        {
            return command(sql).ExecuteNonQuery();
        }
        public  SqlDataReader read(string sql) //读取操作
        {
            return command(sql).ExecuteReader();
        }
        public void Close()
        {
            con.Close(); //关闭连接
        }
    }
}
