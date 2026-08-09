+++
date = '2026-08-10T04:38:02+08:00'
draft = false
title = 'Dart列表'
image = "matt-le-SJSpo9hQf7s-unsplash.jpg"     
categories = [
    "dart",
    "学习笔记"
]
+++

# dart列表类型- List

场景 当一个变量需要多少个值存储时，可以使用列表类型list

需要 一个班级学生list 支持对学生 查找 增加 删除 循环

会发 List 属性名 = ["学生1”，“学生2“]

```
void main(){
    List students = ["小明", "小红", "小刚"];
    print(students);
}
```

## List常用的操作方法

* 在尾部添加 add（内容）

* 在尾部添加一个列表 addAll（列表）

* 删除满足内容的第一个 remove（内容） **注意 只删除满足条件的第一个**

* 删除最后有个 removeLast（）

* 删除引用范围内的数据 removeRange（start,end）**注意 开始包含 结尾不包含 从0开始**
  
  0,1,2,3,4

```
void main(){
 List students = ["小明", "小红", "小刚"];
 print(students);
 student.add("小芳");
 print(students);
 student.add("小芳");
 print(students);
 students.addAll("小王","小夏");
 print(students);
 students.remove("小芳");
 print(students);
 students.removeLast();
 print(students);
 students.removeRange(0,5);
 print(students);
}
```

```
[小明 小红 小刚 小芳]
[小明 小红 小刚 小芳 小芳]
[小明 小红 小刚 小芳 小芳 小王 小夏]
[小明 小红 小刚 小芳 小王 小夏]
[小夏]
```
