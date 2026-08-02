+++
date = '2026-07-31T20:35:35+08:00'
draft = false
title = 'Dart'
image = "matt-le-SJSpo9hQf7s-unsplash.jpg"     
categories = [
    "dart",
    "学习笔记"
]
+++

---

# dart变量与常量

## dart变量（可被修改）

dart变量声明 - var

关键词  var

语法 var 变量名 = 值/表达式；

   void main(){

```
 void main(){
 var age = 20; //第一次被赋值之后 类型被确定 后面不许被更改其他类型

 print(age);

 var age = 21;

 print(age);

 var age1 = 20 + 21;

 print(age1);
} 

20

21

41
```

  2 . 注意

​       ；结尾

​       第一次被赋值之后 类型被确定 后面不许改为其他类型

## dart常量（不可修改）

## const声明

关键词:const

const 属性名 = 值/表达式；

const 不允许表达式中有变量存在，必须为常量或者固定值

```
 void main(){
 const num1 = 3.1415926;

 const num = num1;

 const length = 2  *num*  10; //圆的周长 
```

```
 void main(){
 const num = 3.1415926;

 num = 3.14;  //修改常量

 const length = 2  *num*  10;

}
```

## final 声明（获取时间）

关键词 final

final 属性词 = 表达式/值

3.find运行时被初始化 其值设置后不可以被修改

```null
void main(){ 
  final time = DateTime.now()；//获取用户电脑时间 运行时为常量
  print（time）

}
```
