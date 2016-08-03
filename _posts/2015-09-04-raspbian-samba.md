---
layout: post
title:  "在树莓派上面使用samba文件共享服务"
date:   2015-09-04 18:37:54
categories: 树莓派 linux 
excerpt: XyzMax 树莓派 samba文件共享
published: true
---

* content
{:toc}

## 需要原因



树莓派现在被我拔掉鼠标键盘显示器后直接搁在客厅，主要用远程登录的方式去操作pi，既然树莓派是一台完完整整的电脑，那以后肯定少不了在上面运行一些任务，日常工作使用中也会经常用到文件共享这一服务，包括一些把一些写好的程序上传到pi上面，在pi上面执行一些下载任务等等。


---

## 文件共享方式



粗略到网上查了下，发现有两种文件共享的方式

* filezilla：

>  FileZilla是一个免费开源的FTP软件，分为客户端版本和服务器版本，具备所有的FTP软件功能。可控性、有条理的界面和管理多站点的简化方式使得Filezilla客户端版成为一个方便高效的FTP客户端工具，而FileZilla Server则是一个小巧并且可靠的支持FTP&SFTP的FTP服务器软件。
FileZilla是一种快速、可信赖的FTP客户端以及服务器端开放源代码程式，具有多种特色、直接的接口。FileZilla在2002年11月获选为当月最佳推荐专案。

* samba：

>  Samba是在Linux和UNIX系统上实现SMB协议的一个免费软件，由服务器及客户端程序构成。SMB（Server Messages Block，信息服务块）是一种在局域网上共享文件和打印机的一种通信协议，它为局域网内的不同计算机之间提供文件及打印机等资源的共享服务。SMB协议是客户机/服务器型协议，客户机通过该协议可以访问服务器上的共享文件系统、打印机及其他资源。通过设置“NetBIOS over TCP/IP”使得Samba不但能与局域网络主机分享资源，还能与全世界的电脑分享资源。

这里选择用samba，filezilla以后有用得到的时候再记录。

---


## 使用Samba过程

### 安装Samba

linux上面安装软件真的过瘾，就像包管理一样，敲入安装命令就行了，不用像windows或者osx那样到处找安装包，安装命令如下：

	$ sudo apt-get install samba
	$ sudo apt-get install samba-commmon-bin #这个也记得要安装

---



### 配置Samba

samba的功能非常强大，而且可配置性也非常高，这里因为我急需要文件传输这个服务，所以按照网上的一个教程来尽量简化到能用的程度，往后可能会写一篇专门samba配置的记录文章。

---
安装完成后，配置文件在 /etc/samba/smb.conf 使用vim或者nano打开能看到里面非常多配置记录，因为这里我想尽快能用，所以直接建一个新的配置文件，旧的也不要删除，先修改名称备份起来。

	$ sudo mv /etc/samba/smb.conf /etc/samba/smb.conf.backup

然后再用vim或nano新建一个文本，里面敲入

	[global]
    	log file = /var/log/samba/log.%m
	[tmp]
    	comment = Temporary file space
    	path = /tmp
    	read only = no
    	publishedic = yes
    	writable = yes

这里能看得出来是直接把/tmp目录作为共享目录，保存为 /ect/samba/smb.conf，然后输入命令把服务重启。
	
	$ sudo /etc/init.d/samba restart

重启完成后在 /etc/samba/ 目录下面创建一个smbpasswd文件：

	$ sudo touch /etc/samba/smbpasswd


配置好了这些还不能使用，还有对用户权限做配置， samba用户需要是系统已经存在的用户。

	$ sudo smbpasswd -a username

提示让你输入共享密码，这下子可以了。

>注意，如果smbpasswd命令提示无效的话，那就没安装samba-commmon-bin


 ---

### 使用samba

在osx下面使用samba非常简单

finder下直接连接到服务器 输入 smb://192.168.1.166 输入刚刚添加的账户和密码。

![samba-use]({{ "/css/pics/samba-use.png"}})

ok! 连接成功！ 我这里是直接改称根sd卡的根目录

![samba-successful]({{ "/css/pics/samba-successful.png"}})

---

## 结束

OK!  以上，就能和树莓派进行文件共享了。





















