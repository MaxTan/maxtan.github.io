---
layout: post
title:  "给树莓派安装Raspbian"
date:   2015-09-2 15:36:54
categories: 树莓派 Raspberrpi
excerpt: XyzMax 树莓派安装系统
published: true
---

* content
{:toc}

##大背景

一早就想玩玩树莓派了，这次终于狠下心咬咬牙把省了大半年的饭钱买了一块树莓派2B和一堆零配件。 闲话少扯，下面开始记录下装系统的过程。

---

##安装过程

###下载系统镜像

首先要下载系统镜像，第一时间去找找国内有没有维护景象点，毕竟国内有的话，速度快也省时间，刚好搜到有个在广州的站点，中大LUG，Nice！  [http://mirrors.ustc.edu.cn/raspbian/](http://mirrors.ustc.edu.cn/raspbian/)
但进到去发现并没有什么卵用，只有12年的几个老版本镜像。
好吧直接去[官网](https://www.raspberrypi.org/downloads/)下载，速度还行。 
官方是推荐使用NOOBS和Raspbian两个，当然还有其他的一些系统，像ubuntu、pinet之类，还有今年刚发布的windows10物联网版。

---

###写入到sd卡

下载后解压得到一个3.05G的*.img镜像，按照官方给的快速指南，在windows上使用Win32DiskImager把镜像写入到sd卡，mac上面有直接的命令行可使用，回头再补充再mac上写入系统镜像的方法。

![write-raspbian]({{ "/css/pics/raspbian-write.png"}})

非常简单，选好sd卡盘符，选好镜像，点击write就开始了

![write-raspbian]({{ "/css/pics/raspbian-write-seed.png"}})

卡是在X宝随树莓派一起买的闪迪 16GClass10 写入速度平均在14M/s，速度还可以。(查过防伪码了，是真品，是真品	)

![wirte-raspbian]({{ "/css/pics/raspbian-write-successful.png"}})

好的，短短几分钟就把3.05G的大家伙写进去了。

---

###End

写入卡后系统就算装完了，看了下快速指南，把卡插到pi上面就能直接跑起来，不过现在还在上班，不能直接把树莓派点亮，晚上回去再接着玩并把过程记录下来。