+++
date = '2026-06-29T20:08:17+08:00'
draft = false
title = '调用函数'

image = "matt-le-SJSpo9hQf7s-unsplash.jpg"

categories = [
    "python",
    "学习笔记"
]

+++

# 函数

直接从Python的官方网站查看[文档](http://docs.python.org/3/library/functions.html#abs)，也可以在交互式命令行通过`help(abs)`查看`abs`函数的帮助信息



| 函数名        | 功能说明           | 备注                                                |
| ------------- | ------------------ | --------------------------------------------------- |
| **`abs()`**   | 求**绝对值**       | 接收 1 个参数；参数数量或类型错误会报 `TypeError`。 |
| **`max()`**   | 返回**最大值**     | 可以接收任意多个参数。                              |
| **`int()`**   | 转换为**整数**     | 将其他数据类型（如字符串或浮点数）转换为整数。      |
| **`float()`** | 转换为**浮点数**   | 将其他数据类型转换为小数形式。*                     |
| **`str()`**   | 转换为**字符串**   | 将其他数据类型转换为文本字符串形式。*               |
| **`bool()`**  | 转换为**布尔值**   | 将其他数据类型转换为 `True` 或 `False`。*           |
| **`hex()`**   | 转换为**十六进制** | 将一个整数转换成十六进制表示的字符串。              |
| **`help()`**  | 查看**帮助信息**   | 在交互式命令行中使用，例如 `help(abs)`。            |

**说明：**

- 带有 `*` 标记的函数（`float`, `str`, `bool`）虽然在当前的文本片段中未详细展开，但它们与 `int()` 共同构成了 Python 的基本类型转换工具箱，符合来源中提到的“数据类型转换函数”这一分类。

- **函数名作为引用**：请记住，表格中的这些名称（如 `abs`、`int`）本质上都是指向函数对象的引用，你可以像执行 `f = abs` 一样为它们起别名。

  

1. 调用 abs 函数(绝对值)

```python
a = abs(100)
print(a)
100
a = abs(-20)
print(a)
20
a = abs(12.34)
print(a)
12.34
```

调用函数的时候，如果传入的参数数量不对，会报`TypeError`的错误，并且Python会明确地告诉你：`abs()`有且仅有1个参数，但给出了两个：

```
abs(1, 2)
Traceback (most recent call last):
  File "<stdin>", line 1, in <module>
TypeError: abs() takes exactly one argument (2 given)
```

如果传入的参数数量是对的，但参数类型不能被函数所接受，也会报`TypeError`的错误，并且给出错误信息：`str`是错误的参数类型：

``` 
abs('a')
Traceback (most recent call last):
  File "<stdin>", line 1, in <module>
TypeError: bad operand type for abs(): 'str'
```



   2.int()整数

``` python
a = int('123')
print(a)
123
a = int(12.34)
print(a)
12

```



   3.max函数 选取最大值   

```python
a = max(1,2)
print(a)
2
a = (2,3,4,5,6,-1,-2)
print(a)
6

```



4. float 浮点数    

``` python
a = float(12.34)
print(a)
12.34
```

5.  str 数字转换为文本

``` python
a = str(1.23)
print(a)
'12.34'
a = str(100)
print(a)
'100'
```



6. bool() 布尔值

``` python
bool(1)
ture
bool('')
false
```



  7.hex()整数 转换为十六进制表示的字符串

```python
n1 = hex(255)
print(n1)
0xe1
n2 = hex(1000)
print(n2)
0x3e8
```



在 Python 中，函数被视为一种对象。**函数名**（比如 `abs`）并不是函数本身，而是一个**变量**，它存储了指向该函数对象的内存地址，也就是所谓的“引用”。

可以把它想象成一个标签：

- 把函数名赋给变量

既然函数名只是一个变量（标签），那么你当然可以把这个变量的值赋给另一个变量。

执行 `a = abs` 时，你并不是在运行函数，而是把 `abs` 指向的那个“机器地址”也告诉了变量 `a`。现在，标签 `abs` 和标签 `a` 都贴在了同一个“绝对值计算”机器上。

```
>>> a = abs # 变量a指向abs函数
>>> a(-1) # 所以也可以通过a调用abs函数
1
```

