# 图书管理系统

## 数据库设计

1、管理员 用户

2、 登录、注册、书籍管理、用户删除、借书、还书

3. 管理员：admin_id（*） admin_psw 
4. 用户：user_id（*） |  name  | gender char(2) (添加check约束) | user_psw 

![](https://my-typoraimage.oss-cn-hangzhou.aliyuncs.com/img/20221215212130.png)  

3. 图书：book_id（*）  |  book_name  |  author  | publisher   | price  | count
4. 借书: no()*  | user_id  |  book_id  |  book_name(为了方便加的) |  date