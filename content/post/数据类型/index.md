+++
date = '2026-06-19T23:34:17+08:00'
draft = false
title = '数据类型'

 categories = [
    "学习笔记",
    "python"
]

image = "matt-le-SJSpo9hQf7s-unsplash.jpg"

+++

# 数据类型与变量

1. **变量名第一个数不能为数学**

   12356...

   

1. **解决特殊符号**                                                                                                                        

   ```              python
   s2 = 'hello,\'adam\''
   print(s2)
   hello,'adam'
   
   
   或者这样解决:  
   a = "'hello world'"
   print(a)
   > 'hello world'  
   ```

   4.   **布尔法则**

      ``` python
      a = Ture
      b = False
      print(a and b)   #False（又一个假取假）
      print(a or b)    #Ture（一个为真为真）
      print（not a）   #False（取反）
      ```

5. **变相指向**

   ``` python
   a = 'ABC'
   b = a
   a = 'XYZ'
   print(b)
   
   > abc
   
   ```

   a = 'abc'

![py-var-code-1](https://liaoxuefeng.com/books/python/basic/data-types/step-1.png)



​      b = a 

​      

![py-var-code-2](https://liaoxuefeng.com/books/python/basic/data-types/step-2.png)

​     a = XYZ



​                            ![py-var-code-3](https://liaoxuefeng.com/books/python/basic/data-types/step-3.png)

​     b = ABC

      #  数据算数

/ = ➗

    10/3 
    3.3333333333333335

// = 除法保留整数

  ``` 
  10 // 3
  3
  ```

 % = 除法保留余数

 ``` 
 >>> 10 % 3
 1
 ```

