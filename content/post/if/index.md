+++
date = '2026-06-16T17:45:57+08:00'
draft = true
title = 'If'
+++

# 条件判断

##      1.判断

​       注意添加  ` ：`

``` 
age = 20 
if age >= 18:
     prnit('adult')
```



``` 
age = 3
if age >= 18:
    print('adult')
else:
     print('teenager')
```

   

##  2. 多次判断      

     ``` 
age >= 3
if age >= 18:
    print('adult')
elif age >= 6:
     print('teenager')
else:
    print('kid')
     ```

​    其中`elif`是`else if`的缩写

   ``` 
if <条件判断1>:
    <执行1>
elif <条件判断2>:
    <执行2>
elif <条件判断3>:
    <执行3>
else:
    <执行4>
  
   ```

​        **“先到先得”原则：在 if...elif...else 结构中，程序非常“懒”，只要碰到第一个符合条件的选项，它做完就收工了，后面的哪怕也符合条件，它也不会再看** 

​           **else 是最后的港湾：当所有条件都不成立时，程序才会去找 else。**

    ##   3.str 与 int

``` 
birth = input('birth: ')
if birth < 2000:
    print('00前')
else:
    print('00后')

```

​    报错

       Traceback (most recent call last):

  File "<stdin>", line 1, in <module>
TypeError: unorderable types: str() > int()

​     因为input 返回数值为str str不能与整数比较 需要转换为int

 ``` 
s = input('birth: ')
birth = int(s)
if birth < 2000:
    print('00前')
else:
    print('00后')

 ```

​       类型转换的风险：用 int() 转换 input() 的内容时，一定要确保用户输入的是数字，否则程序会“罢工”报错。
