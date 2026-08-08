+++
date = '2026-08-08T08:22:32+08:00'
draft = false
title = 'Dart和字符串'
image = "matt-le-SJSpo9hQf7s-unsplash.jpg"     
categories = [
    "dart",
    "学习笔记"
]
+++

# dart string

场景 当我们需要一个变量描述一段文本，就可以使用string来声明

关键词 string

语法 string 属性名 = = ‘文本内容’

特点 引号支持双引号或者单引号 ， 支持拼接及模版字符串

```
void main(){
    String text = "明天";
    print(text);
}
```

# dart -string -模板字符串

场景 当String 类型的变量当前时间来显示 ， 可以使用模板字符串或者拼接实现

需求 打印出我要在具体时吃饭

语法 String 属性名 = ‘文本内容\$变量名’。或者String 变量名 = ‘文本内容\${变量名}’

```
void main(){
    String text = "小米";
    print("我的名字叫$text");
}
```

```
void main(){
    text = "我今天要在${DateTimes.now()}睡觉"；
    print（text）;
}
```
