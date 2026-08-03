+++
date = '2026-08-03T17:16:21+08:00'
draft = false
title = 'Dart和string'
image = "matt-le-SJSpo9hQf7s-unsplash.jpg"     
categories = [
    "dart",
    "学习笔记"
]
+++

# dart和String

## String

场景 当String类型的 **变量** 当前时间来显示可以使用模板字符串或者拼接实现

需求 打印出我需要在（具体时间）的时候吃早饭

语法 string 属性名 = ‘文本内容$变量名’； 或String 变量名 = ‘文本内容 hugo \${变量名}’

注意 当前存在模板中的内容是一个表达式的需要使用 \${},更推荐使用 \${}

```
void main(){
    String text = "hello,world"; //注意大写 S
    print(text)；
}
```

```
hello, world
```

String text 变量

```
void main(){
    String text = "hello,world";
    print(text)；
    text = "hello,Dart";//String为变量可被定义
    print(txet)；
}
```

```
hello,world
hello,Dart
```

string 属性名 = ‘文本内容$变量名’； 或String 变量名 = ‘文本内容 hugo \${变量名}’

引用 *\$*

```
void main(){
   String content = '张三';
   String content1 = '我要和$content一起去吃饭';
   print(conternt2);
}
```

```
我要和张三一起去吃饭
```

```
void main(){
    String cotent = '我要${DateTime.now()'学习dart’;
    print(cotent)；
}
```

```
我要2026-08-03 17:14:13.845180学习dart
```
