+++
date = '2026-06-18T19:41:02+08:00'
draft = false
title = '模式匹配'

image = 'helena-hertz-wWZzXlDpMog-unsplash.jpg.png'   

categories = [
    "学习笔记",
    "python"
]

+++

# 针对若干个变量匹配



​       可以使用 **mate** 语句

 ``` 
 socer = 'b'
 if socer = 'a'
    print('socer is b')
 elif socer = 'b'
    print('socer is b')
 elif socer = 'c'
    print('socer is c')
 else:
    print('linalid socer.')
 ```

如果使用match语法 代码更易读

``` 
socer = 'a'
  match socer:
      case 'a'
          print('score is a')
      case 'b'
          print('score is b')
      case 'c'
          print('score is c')
      case_: 表示匹配条件
          print('socer is ???')      
```

 针对若干复杂条件:

 ``` 
 age = 15
 
 match age:
     case x if x < 10:       
         print(f'< 10 years old: {x}')  #范围比较
     case 10:
         print('10 years old.')  #匹配
     case 11 | 12 | 13 | 14 | 15 | 16 | 17 | 18:         
         print('11~18 years old.')
     case 19:
         print('19 years old.')
     case _:
         print('not sure.')
 
 ```

`match`语句还可以匹配列表是输出，功能非常强大

  ``` 
  args = ['gcc', 'hello.c', 'world.c']
  # args = ['clean']
  # args = ['gcc']
  
  match args:
      # 如果仅出现gcc，报错:
      case ['gcc']:
          print('gcc: missing source file(s).')
      # 出现gcc，且至少指定了一个文件:
      case ['gcc', file1, *files]:
          print('gcc compile: ' + file1 + ', ' + ', '.join(files))
      # 仅出现clean:
      case ['clean']:
          print('clean')
      case _:
          print('invalid command.')
  ```



 ## **易错项**



1. case ['gcc', file1, *files]    [gcc 第一个文件 *剩余文件 ]

2. 如果任何一个case没有匹配成功 程序会跳过这个match

3. case ['clean']: 这种写法是精确匹配，要求列表里有且仅有一个元素且内容为   'clean'。

   case ['clean', *files]: 这种写法表示第一个是 'clean'，后面可以带零个或多个其他   内容。

   如果数据是 ['clean']，最精准的匹配方式是不带星号的 case ['clean']
