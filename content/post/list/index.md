+++
date = '2026-06-14T14:53:09+08:00'
draft = false
title = 'List'  

image = 'helena-hertz-wWZzXlDpMog-unsplash.jpg.png' 

+++



# list 

 1.列表 有序集合 可随时添加和删除其中元素

``` >>> classmates = ['Michael', 'Bob', 'Tracy']
>>> classmates = ['Michael', 'Bob', 'Tracy']
>>> classmates
>>> ['Michael', 'Bob', 'Tracy']
```

 len() 获取list元素个数

  ``` 
>>>len(classamtes)
>>3
  ```

2. **索引元素 **

​      0开始 

  ```
classmates[0]
'Michael'
classmates[1]
'Bob'
classmate[2]
'Tracy'
  ```

 ``` 
classmates[-2]
'Bob'
classmates[-3]
'Michael'
 ```



 超出范围 

```plain
Traceback (most recent call last):
  File "<stdin>", line 1, in <module>
IndexError: list index out of range
```

3. **list 添加**

* 添加后缀元素

  ``` 
  classmates.append('Adma')
  classmates
  ['Michael','Bob','Tracy','Adam']
  ```



​       元素插定指定位置  选择位置 原元素位置推后一位

``` 
classamtes.insert(1,'Jack')
classmates
['Michael','Jack','Bob','Tracy','Adam']
```

* 删除元素 pop（） 

 

​     单独删除后缀 pop（）

``` 
classmates.pop()
Adam
classmates
['Michael','Jack','Bob','Tracy']
```



   指定位置 pop （i）

   ``` 
classmates.pop(1)
'Jack'
classmates
['Micheal','Bob','Tracy']
   ```



3. 替换元素

   ``` 
   classmates[1] = 'Sarah'
   classmates
   ['Michael','Sarah',Tracy']    
   ```

     元素可以不同

    ``` 
   L= ['apple',123,ture]
    ```

   

​          list 也可以套入list

     s = ['python',['asp','php'],'scheme']



​        list 里面无元素

     L = []
     len(L)
     0



       #    tuple



​        tupe 与  list 非常相似  **tupe 无法修改**（更加安全）

    t = (1,2)
    t
    (1,2)



   ``` 
t = ()
t
()
   ```

​     

  ``` 
t = (1)
t
1
  ```

   加上括号 避免误认为数学括号

    t = (1,)
    (1,)

​    

    t =('a','b',['A','B'])
    t[2][0] = 'x'
    t[2][1] = 'y'
    ('a','b',['x','y'])

