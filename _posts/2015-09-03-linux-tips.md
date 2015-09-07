---
layout: post
title:  "linux使用笔记"
date:   2015-09-03 22:14:54
categories: linux
excerpt: XyzMax
published: ture
---

* content
{:toc}


###文件操作

	切换目录
	$ cd

	查看当前目录
	$ pwd

	创建目录
	$ mkdir

	创建文件
	$ touch

	删除
	$ rm

	mv命令是移动文件命令，也可用作重命名
	$ mv oldName newName

	查找命令
	find

	查看文件内容
	$ cat

###开放端口给外网访问

	$ /sbin/iptables -I INPUT -p tcp --dport 8000 -j ACCEPT #开启8000端口 
 
	$ /etc/rc.d/init.d/iptables save #保存配置 
 
	$ /etc/rc.d/init.d/iptables restart #重启服务 
 
	#查看端口是否已经开放 
 
	$ /etc/init.d/iptables status


