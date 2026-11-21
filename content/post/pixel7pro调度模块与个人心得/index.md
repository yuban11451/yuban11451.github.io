+++
date = '2026-11-21T20:20:57+08:00'
draft = false
title = 'Pixel7pro调度模块与个人心得'
image = "Img_2026_11_21_21_06_24 (2).jpg"
tags = [
 "AI编程",
 "magisk",
 "pixel"
]
+++

# 谷歌pixel7pro调度模块

## 琐琐碎碎

也是好久没有更新我的博客了 最近一直在忙学习还有玩）

我最近两个月用DeepSeek4.1模型编程一个pixel7pro模块 这是我第一次用ai长时间编辑项目

连接：

https://wwbku.lanzoub.com/iC1xj4gvof6h  
密码:68cu

我的目前需求如下： 降频 保证流畅度情况下尽量压低功耗

## 思路

### 限制x1大核

谷歌 g2  soc参数如下

- 采用三星5nm工艺制程，相较前代能效比提升约20% 

- CPU集群包含2颗Cortex X1超大核（主频2.85GHz）、2颗Cortex A78大核和4颗Cortex A55小核

- GPU沿用Mali-G710 MP7图形处理器

- 集成新一代Tensor处理单元（TPU）用于AI加速

当然 可以看出这个x1非常臭名昭著 并且还是两颗x1 直接趋势喵）

但是好消息 谷歌的原厂调度器sched_pixel 非常聪明 必要时候才启动双x1大核 其余时间只是500兆左右待机

在第一个版本 我的思路是这样 拉高2颗Cortex A78大核 压低双x1超大核和其调用

在gpt建议下

于是乎频率如下 并限制了cpuset 并多次测试

| 大核  | 300 | 1401 |
|:--- |:---:| ----:|
| 中核  | 400 | 1999 |
| 小核  | 500 | 1826 |

Cpuset

用户后台进程

0-3

系统后台进程

0-3

前台进程

0-5

顶层的进程

0-7

这下可以很好限制对双x1大核启动了以及调用频率 

### 关闭系统选择项

我的朋友在搞lgg7 （好老的机器）

在启用getprop |grep debug.命令后发现原厂系统多处负优化 于是建议我也试一试 

结果如下

```
➜ sdcard getprop |grep debug.
[dalvik.vm.dex2oat-minidebuginfo]: [true]
[dalvik.vm.minidebuginfo]: [true]
[debug.atrace.app_0]: [com.saily.android]
[debug.atrace.app_number]: []
[debug.atrace.tags.enableflags]: [0]
[debug.c2.use_dmabufheaps]: [1]
[debug.force_rtl]: [false]
[debug.hwc.winupdate]: [1]
[debug.hwui.skia_tracing_enabled]: [false]
[debug.hwui.skia_use_perfetto_track_events]: [false]
[debug.hwui.use_hint_manager]: [true]
[debug.perfetto.sdk_sysprop_guard_generation]: [0]
[debug.renderengine.graphite_preview_optin]: [true]
[debug.renderengine.skia_tracing_enabled]: [false]
[debug.renderengine.skia_use_perfetto_track_events]: [false]
[debug.sf.dim_in_gamma_in_enhanced_screenshots]: [1]
[debug.sf.disable_backpressure]: [0]
[debug.sf.early.app.duration]: [16600000]
[debug.sf.early.sf.duration]: [16600000]
[debug.sf.earlyGl.app.duration]: [16600000]
[debug.sf.earlyGl.sf.duration]: [16600000]
[debug.sf.enable_adpf_cpu_hint]: [true]
[debug.sf.enable_gl_backpressure]: [1]
[debug.sf.enable_sdr_dimming]: [1]
[debug.sf.frame_rate_multiple_threshold]: [120]
[debug.sf.late.app.duration]: [16600000]
[debug.sf.late.sf.duration]: [10500000]
[debug.sf.layer_caching_active_layer_timeout_ms]: [1000]
[debug.sf.treat_170m_as_sRGB]: [1]
[debug.sf.use_phase_offsets_as_durations]: [1]
[debug.slsi_platform]: [1]
[debug.stagefright.c2-poolmask]: [1507328]
[debug.stagefright.c2inputsurface]: [-1]
[debug.stagefright.ccodec_delayed_params]: [1]
[debug.tracing.battery_status]: [3]
[debug.tracing.device_state]: [0:DEFAULT]
[debug.tracing.mcc]: [460]
[debug.tracing.mnc]: [2]
[debug.tracing.plug_type]: [0]
[debug.tracing.screen_brightness]: [0.14242691]
[debug.tracing.screen_state]: [2]
[ro.boot.debug_level]: [0x4948]
[ro.force.debuggable]: [0]
[vendor.mali.debug.config]: [/vendor/etc/mali/debug.config]
➜ sdcard
```

于是我关闭了这两项

```
关闭实验性 Graphite 渲染 + 重新启用 USAP 池(加速冷启动)
resetprop -n debug.renderengine.graphite_preview_optin false 2>/dev/null
resetprop -n dalvik.vm.usap_pool_enabled true 2>/dev/null
```

嗯 流畅很多 但不知道是不是心理作用）

### 温控

最后 我拉高了pixel7pro的温控 （原厂40度简直不是日用的温控 ）定为 45度 

## 结果

最后加上后台控制 如果不打游戏 5g使用下 最高功耗不超过3.0w 我对此很满意

## 反思

这次ai编程中 发现deepseek 的deepseek harness还是需要成长空间 很多需求都是左右脑搏击 （当然也可能我的问题 我的问题主要是后期没有严加管理DeepSeek写的markdown文档需求） 最后我选择omp 决定作为我的新agent 用skills /grill-me 重新对齐需求以及删掉无用代码

ps ：/grill-me这个skills太好用了
