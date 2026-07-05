+++
date = '2026-07-05T18:12:10+08:00'
draft = false
title = 'Notebookml个人使用经验'

categories = [
    "工具"
]    

image = "matt-le-SJSpo9hQf7s-unsplash.jpg"

+++

# notebookml使用心得

NotebookLM 的故事始于 ***\*2023 年 5 月的 Google I/O 大会\****，当时它以“Project Tailwind”之名首次亮相。 这款最初被定义为“主要是为学生设计的工具”的原型产品，其诞生初衷是“重新构想 AI 时代的笔记软件”。 该项目由知名科普作家 Steven Johnson 和产品经理 Raiza Martin 共同领导，旨在利用强大的语言模型重新定义笔记软件的核心形态。





我在悠然推荐下接触这款软件 对我自学有很大帮助 目前我的自学成果在 [新建标签页](https://yuban11451.github.io/) 展示



# 准备阶段：

1.一个Google账号

​                2. 魔法

​                3. 一双手，聪明的脑子，和细心的眼睛

![img_v3_0213a_6afd4f27-fceb-4649-ab37-785311b62ceg_MIDDLE](C:\Users\XOS\AppData\Roaming\LarkShell\sdk_storage\64c0475d03e4575081c99eeb016a5074\resources\images\img_v3_0213a_6afd4f27-fceb-4649-ab37-785311b62ceg_MIDDLE.webp)







注 ：Google账号 我这边建议推荐购买google（淘宝拼多多都有 目前国内86账户风控严重 注册就封禁）

魔法 不做推荐 代理地区建议台湾 美国 新加坡 ***\*（不要选香港 审核严重无法使用）\****





开启魔法（注意地区选择） 打开 [新建标签页](https://notebooklm.google.com/?icid=home_maincta&pli=1)  登录谷歌账号（移动端打开谷歌服务 play商店下载 这里只做pc网页端使用 但大体类似）







![img_v3_0213a_57ce54b6-9b8b-4ef2-88bf-f351754e49fg_MIDDLE](C:\Users\XOS\AppData\Roaming\LarkShell\sdk_storage\64c0475d03e4575081c99eeb016a5074\resources\images\img_v3_0213a_57ce54b6-9b8b-4ef2-88bf-f351754e49fg_MIDDLE.webp)





点击创建笔记

![img_v3_0213a_554e3f15-2367-4b43-bf54-0df9d3f0b96g_MIDDLE](C:\Users\XOS\AppData\Roaming\LarkShell\sdk_storage\64c0475d03e4575081c99eeb016a5074\resources\images\img_v3_0213a_554e3f15-2367-4b43-bf54-0df9d3f0b96g_MIDDLE.webp)







按照选项你可以选择你所需要学习对象的文件 网站（注 如b站或者[linux.do](http://linux.do/)论坛无法爬取

你可以去自行复制B站视频字幕论坛网站内容选择复制文字粘贴解决

这里不再赘述）













# 使用案例

比如现在我在自学python 我使用自学网站为[简介 - Python教程 - 廖雪峰的官方网站](https://liaoxuefeng.com/books/python/introduction/index.html)





首先复制链接



复制链接  [函数的参数 - Python教程 - 廖雪峰的官方网站](https://liaoxuefeng.com/books/python/function/parameter/index.html)



![img_v3_0213a_dc5c3ce0-cd6e-44d2-a30b-3e76ca2135eg_MIDDLE](C:\Users\XOS\AppData\Roaming\LarkShell\sdk_storage\64c0475d03e4575081c99eeb016a5074\resources\images\img_v3_0213a_dc5c3ce0-cd6e-44d2-a30b-3e76ca2135eg_MIDDLE.webp)

打开notebooklm网站 将链接复制



![img_v3_0213a_e947424b-278e-4bc1-a3d4-6a0c4fc3208g_MIDDLE](C:\Users\XOS\AppData\Roaming\LarkShell\sdk_storage\64c0475d03e4575081c99eeb016a5074\resources\images\img_v3_0213a_e947424b-278e-4bc1-a3d4-6a0c4fc3208g_MIDDLE.webp)

点击创建



有三个页面：

添加来源

![img_v3_0213a_bbc91feb-b787-4c54-9d05-a4dab424fd4g_MIDDLE](C:\Users\XOS\AppData\Roaming\LarkShell\sdk_storage\64c0475d03e4575081c99eeb016a5074\resources\images\img_v3_0213a_bbc91feb-b787-4c54-9d05-a4dab424fd4g_MIDDLE.webp)

ai对话框

![img_v3_0213a_460dea50-d36e-4720-aea2-153cbc41d78g_MIDDLE](C:\Users\XOS\AppData\Roaming\LarkShell\sdk_storage\64c0475d03e4575081c99eeb016a5074\resources\images\img_v3_0213a_460dea50-d36e-4720-aea2-153cbc41d78g_MIDDLE.webp)



studio

![img_v3_0213a_e829f63d-fadb-4c0e-b89a-3546ea809f5g_MIDDLE](C:\Users\XOS\AppData\Roaming\LarkShell\sdk_storage\64c0475d03e4575081c99eeb016a5074\resources\images\img_v3_0213a_e829f63d-fadb-4c0e-b89a-3546ea809f5g_MIDDLE.webp)e)











首先我们自学 不是一上来就库库点studio页面全部选一遍





首先我们目标是自学 先从学开始



先仔细研读一遍网页网站

这篇文章

我会发现有一段不懂





def power(x, n):

​    s = 1

​    while n > 0:

​        n = n - 1

​        s = s * x

​    return s





这行代码为什么要s = 1

这时候你可以去问notebookml





打开对话界面  将这行代码复制进对话框



![img_v3_0213a_c188ecac-1a41-4874-83cd-4c9cb6a0870g_MIDDLE](C:\Users\XOS\AppData\Roaming\LarkShell\sdk_storage\64c0475d03e4575081c99eeb016a5074\resources\images\img_v3_0213a_c188ecac-1a41-4874-83cd-4c9cb6a0870g_MIDDLE.webp)







notebooklm会给出解释 ***\*仔细读并理解给出的解释：\****



这段代码是用来计算 ***\*$x$ 的 $n$ 次方\****（即 $x^n$）的。

在大白话里，`s = 1` 的意义可以从以下几个方面来理解：



1.  ***\*乘法的“起步价”：\**** 我们要算的是连乘（把 $n$ 个 $x$ 乘在一起）。在数学里，乘法的初始值必须是 ***\*1\****。就像你存钱一样，如果是计算翻倍，手里得先有“1块钱”作为基数，才能翻成2块、4块。





1.  ***\*为什么不能是 0？\**** 如果 `s = 0`，那么在循环里执行 `s = s * x` 时，无论 $x$ 是多少，结果永远是 `0 * x = 0`。这样不管循环多少次，最后算出来的结果都是 0，这个函数就废了。





1.  ***\*对应数学逻辑：\****



- 当 $n = 0$ 时（即 $x^0$），循环一次都不执行，函数直接返回 `s` 的初始值 ***\*1\****。根据数学定义，任何非零数的 0 次方都等于 1，这刚好对上了。



- 当 $n = 1$ 时，循环执行一次，`s = 1 * x`，结果就是 $x$ 本身。



- 当 $n = 2$ 时，循环执行两次，`s` 变成了 `1 * x * x`，也就是 $x^2$。







***\*总结一下：\**** `s` 在这里扮演的是一个“累乘器”的角色，它负责把每次循环里的 $x$ 给“攒”起来。为了不影响乘法的结果，必须用 ***\*1\**** 作为初始值来开始累加。





 如果你还无法理解 可以让notebooklm大白话解释

 如果还是理解不了 选出不理解的地方提出问题

 如此反复知道理解为止

![img_v3_0213a_6413b691-f95d-4157-a9eb-67afe3e31ebg](C:\Users\XOS\AppData\Roaming\LarkShell\sdk_storage\64c0475d03e4575081c99eeb016a5074\resources\images\img_v3_0213a_6413b691-f95d-4157-a9eb-67afe3e31ebg.jpg)



***\*然后如何确定你确实理解了？\****





你可以把你理解的话丢给ai进行确认

![img_v3_0213a_463e9309-8c1b-447c-b17a-438183c6b9fg](C:\Users\XOS\AppData\Roaming\LarkShell\sdk_storage\64c0475d03e4575081c99eeb016a5074\resources\images\img_v3_0213a_463e9309-8c1b-447c-b17a-438183c6b9fg.jpg)



当然你想更深入理解 你可以让ai出题

给我出类似的题目进行测验



![img_v3_0213a_6e76be48-2214-4a91-b90f-a6439f733c3g](C:\Users\XOS\AppData\Roaming\LarkShell\sdk_storage\64c0475d03e4575081c99eeb016a5074\resources\images\img_v3_0213a_6e76be48-2214-4a91-b90f-a6439f733c3g.jpg)

你可以加深自己对这个知识点理解



***\*模式框架就是：\****

***\*选出你不理解的地方\****

***\*说出你的不理解地方\****





ps：把所有的东西都理解透了后  我的建议按照网站的代码重新敲一遍加深理解  







最后收尾阶段 

点击studio 选择闪卡和测验进行测试 

（闪卡我推荐如公交地铁这种短时间空闲时间进行短时记忆与复习

大部分时间我推荐使用测验进行收尾工作

这里我点击测验

![img_v3_0213a_cd63ec2c-7b93-4e6d-9371-43f29bb02a5g](C:\Users\XOS\AppData\Roaming\LarkShell\sdk_storage\64c0475d03e4575081c99eeb016a5074\resources\images\img_v3_0213a_cd63ec2c-7b93-4e6d-9371-43f29bb02a5g.jpg)

如果不太明白点击提示

![img_v3_0213a_e7105017-31ae-422a-96bc-4e756c2fcfbg](C:\Users\XOS\AppData\Roaming\LarkShell\sdk_storage\64c0475d03e4575081c99eeb016a5074\resources\images\img_v3_0213a_e7105017-31ae-422a-96bc-4e756c2fcfbg.jpg)

选择错误选项



notebooklm会给你解释

![img_v3_0213a_03434089-1f83-45f9-b92b-1cf458c5a1ag](C:\Users\XOS\AppData\Roaming\LarkShell\sdk_storage\64c0475d03e4575081c99eeb016a5074\resources\images\img_v3_0213a_03434089-1f83-45f9-b92b-1cf458c5a1ag.jpg)





如果还是不太理解 选择解释跳转对话界面给出详细解释

还是不理解 ***\*按照上文方法继续\****



![img_v3_0213a_8d7c024d-e5ba-4ac8-b1cc-78dc437c962g](C:\Users\XOS\AppData\Roaming\LarkShell\sdk_storage\64c0475d03e4575081c99eeb016a5074\resources\images\img_v3_0213a_8d7c024d-e5ba-4ac8-b1cc-78dc437c962g.jpg)



做完这一切后 我会写一篇博客网站作为学习笔记 

随时可以访问博客复习



这是我目前使用notebookml使用心得与体会

![img_v3_0213a_8d7c024d-e5ba-4ac8-b1cc-78dc437c962g](C:\Users\XOS\AppData\Roaming\LarkShell\sdk_storage\64c0475d03e4575081c99eeb016a5074\resources\images\img_v3_0213a_8d7c024d-e5ba-4ac8-b1cc-78dc437c962g.jpg)



***\*自学还是需要个人努力 而不是更好的工具\****



当然可能很肤浅 欢迎各位补充

see you 

![img_v3_0213a_2ab61887-76c4-47ee-a1d4-e3955d60d5ag](C:\Users\XOS\AppData\Roaming\LarkShell\sdk_storage\64c0475d03e4575081c99eeb016a5074\resources\images\img_v3_0213a_2ab61887-76c4-47ee-a1d4-e3955d60d5ag.jpg)
