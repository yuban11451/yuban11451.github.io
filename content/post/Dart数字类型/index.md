+++
date = '2026-08-06T19:06:35+08:00'
draft = false
title = 'Dart数字类型'
image = "matt-le-SJSpo9hQf7s-unsplash.jpg"     
categories = [
    "dart",
    "学习笔记"
]
+++

# dart数字类型 - int/num/double

场景 当我们需要一个数字类型的时候，需要使用int/num/double

区别 int-整数数字 num-可整可小数 double-小数

```
void main(){
    int friendCount = 5;            //整数
    print("我有$friendCount朋友");
    mun rest = 1.5;                //可整数可小数
    print("我有$rest月的假期);
    double appleCount = 1.5;       //小数
    print("我买了$appleCount");
}
```

double 不能直接给int赋值 （把需赋值处理 放最后面）

```
frientCount                          //int
appleCount                          //double
frientCount = appleCount.toint();  //double转换为int 进行赋值
```

num 不能直接给double赋值

```
appleCount                  //double
rest                       //num
appleCount = rest.todouble() //num转换为double 进行赋值
```

double 可直接能给num赋值

```
appleCount //double
rest //num
rest = appleCount //double直接给num赋值
```
