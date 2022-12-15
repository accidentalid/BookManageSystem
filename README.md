# 图书管理系统

期末大作业，比较简陋（丑）



## 数据库设计

1. 管理员 用户

2. 登录、注册、书籍管理、用户删除、借书、还书

3. 管理员：admin_id（*） admin_psw 
4. 用户：user_id（*） |  name  | gender char(2) (添加check约束) | user_psw 

![](https://my-typoraimage.oss-cn-hangzhou.aliyuncs.com/img/20221215212130.png)  

5. 图书：book_id（*)  |  book_name  |  author  | publisher   | price  | count

6. 借书: no()*  | user_id  |  book_id  |  book_name(为了方便加的) |  date

## 操作界面

### 登陆界面

![](https://my-typoraimage.oss-cn-hangzhou.aliyuncs.com/img/20221215213116.png)



### 用户界面

![image-20221215213154362](https://my-typoraimage.oss-cn-hangzhou.aliyuncs.com/img/image-20221215213154362.png)

### 借阅书籍

![](https://my-typoraimage.oss-cn-hangzhou.aliyuncs.com/img/20221215213222.png)

### 个人信息

![](https://my-typoraimage.oss-cn-hangzhou.aliyuncs.com/img/20221215213304.png)

### 管理员界面

![image-20221215213346505](C:/Users/39081/AppData/Roaming/Typora/typora-user-images/image-20221215213346505.png)

### 书籍管理

![image-20221215213401975](https://my-typoraimage.oss-cn-hangzhou.aliyuncs.com/img/image-20221215213401975.png)

### 书籍添加

![image-20221215213503529](https://my-typoraimage.oss-cn-hangzhou.aliyuncs.com/img/image-20221215213503529.png)

### 查看用户借阅

![image-20221215213538742](https://my-typoraimage.oss-cn-hangzhou.aliyuncs.com/img/image-20221215213538742.png)