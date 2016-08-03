---
layout: post
title:  "在树莓派上面使用花生壳"
date:   2015-09-10 22:04:54
categories: linux 树莓派
excerpt: XyzMax 在树莓派上面使用花生壳 外网映射
published: true
---

* content
{:toc}


将pi作为服务器来使用，只能在局域网内访问就显得没有意义了，借助花生壳就能实现把内网的地址映射到外网，下面来记录下操作过程。


---

## 下载安装

到花生壳官网下载[树莓派版](http://hsk.oray.com/download/)

官网也有详细的[教程](http://service.oray.com/question/2680.html)

或者直接使用wget命令，我这里是直接用wget

	$ wget http://download.oray.com/peanuthull/embed/phddns_raspberry.tgz

![hsk]({{ "/css/pics/download-hsk.png"}})

下载完成后直接解压到当前目录

	$ tar zxvf phddns_raspberry.tgz

切换到phddns2目录，并用root权限来启动服务

	$ cd phddns2
	$ sudo ./oraynewph start

当显示SN码以及提示 Oraynewph start success！则表示成功

> 如果出错可能是因为下载的安装包不完整，删除重新下载

---

## 添加映射端口

到[花生壳管理页面](http://hsk.oray.com/)，用刚刚记录下来的SN作为账号登录就可以管理映射端口了

免费版本的只有两个映射数，对于个人来说觉得已经够用了，我这里一个其用来ssh登录，一个用来做网站应用的映射

![port]({{ "/css/pics/hsk-port.png"}})

> 内网访问地址最好使用0.0.0.0，用127.0.0.1会没法从外网访问到内网

> ssh服务不要映射80端口


---

## 使用

花生壳只能映射一个外网的80端口，所以把80端口用来做web服务，另外一个则用来做ssh

以我为例
ssh服务所占据的22端口映射被映射到外网的34348端口，所以连接的时候要指定端口

	$ ssh -p 34348 pi@xxxxxxxxx.eicp.net

这样只要在有网络的地方就能远程连回家里的树莓派了

在手机上面装上ssh的app用流量也能远程操作pi

![phone]({{ "/css/pics/phone-ssh.png"}})

















