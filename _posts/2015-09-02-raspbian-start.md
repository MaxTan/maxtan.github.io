---
layout: post
title:  "树莓派初次体验"
date:   2015-09-2 22:38:54
categories: 树莓派 raspbian linux
excerpt: XyzMax 树莓派无线网络配置 树莓派快速入门
published: true
---

* content
{:toc}


###开始树莓派之旅

续： 终于熬到下班，回到家迫不急到把壳子、sd卡、无线网卡等全部装上，连上电源和显示器。。。
Yes！  一次点亮！  开始记录初次体验过程

---


##树莓派rasp-config

树莓派在第一次启动的时候会需要进行一个简单的配置，具体的设置方法网上非常多，这里不做过多详细的说明
[详细参考这里](http://blog.csdn.net/xdw1985829/article/details/38816375)

后面还想重新配置直接在终端输入

	$ sudo raspi-config

---

##无线网卡配置并且连接到网络

因为家里的显示器和电脑都在房间，而无线路由则放在客厅，所有预先买了一个USB无线网卡做配置。 因为树莓派本身轻巧，而且通过ssh就能远程连接，把它放在客厅的路由器旁边直接用网线连接会好点，wifi总没有物理线路稳定。


因为手头上没有合适的鼠标，直接进入GUI发现鼠标无法响应，应该是驱动的问题，so，只能在直接修改配置文件。

	$ sudo nano /etc/network/interfaces

vim还没怎么用过，先用nano吧，这个比较易用点

在interfaces里面输入

	allow-hotplug wlan0			#不知道这是啥？
	iface wlan0 inet static		#把无线网卡的IP方式设置为静态
	wpa-ssid ********			#无线热点名称
	wpa-psk	********			#无线热点密码
	address 192.168.1.166		#手动分配一个静态地址
	netmask 255.255.255.0		#设置子网掩码
	gateway 192.168.1.10		#网关
	network 192.168.1.10		#服务器地址

这里要设置为静态IP的原因是因为使用DHCP来分配的话，即使内网IP也会经常变动，所以设定好一个固定的IP方便以后ssh或者远程桌面连接

设置完了重启下，再试试ping外网，能通就OK了

*注意修改interfaces文件需要root权限*

---

##使用树莓派内置的以太网卡配置静态IP
前面提到过，主要还是把树莓派放到路由器旁边使用网线直连，简单配置好后，把显示器键盘全卸掉，放到厅里面接上网线。  回到房间用电脑ssh登录(raspbian默认开启ssh服务)

	$ ssh pi@192.168.1.166

Nice！ 赞！

![ssh]({{ "/css/pics/raspbian-ssh.png"}})

依旧使用nano编辑interfaces文件
和无线配置一样，只是少了无线热点的账号和密码的配置

![interfaces-condif]({{ "/css/pics/interface-config.png"}})

关机，把无线网卡拔掉

开机再次登录，Yes！ 无线网卡可以退休了。

---

##更换源

刚好用今中午找到的中山大学的镜像源。
按照使用说明来，还是得用nano编辑 etc/apt/sources.list 文件

	#deb http://mirrordirector.raspbian.org/raspbian/ wheezy main contrib non-free rpi
	# Uncomment line below then 'apt-get update' to enable 'apt-get source'
	#deb-src http://archive.raspbian.org/raspbian/ wheezy main contrib non-free rpi

	deb http://mirrors.ustc.edu.cn/raspbian/raspbian/ wheezy main non-free contrib	
	deb-src http://mirrors.ustc.edu.cn/raspbian/raspbian/ wheezy main non-free contrib

直接把旧的注释掉，再加上新的源地址,然后更新下。

	$ sudo apt-get update

![apt-update]({{ "/css/pics/raspbian-update.png"}})

OK,大功告成！

---


###END

睡觉。。。。。。。。。

---
