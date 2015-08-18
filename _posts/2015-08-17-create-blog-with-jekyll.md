---
layout: post
title:  "使用jekyll搭建个人博客"
date:   2015-08-18 22:55:54
categories: jekyll 
---


* content
{:toc}

##序


之前一直都想自己搭建一个属于自己的个人博客，也有试过用.NET来写过一个， 而且也部署到阿里云上面，虽然博客搭好了但一直都没开始动笔，因为编辑器部分一直都没时间去写。在这个月月初的时候xyz的域名被检测到没有备案，因此部署在阿里云的博客系统也因此不能访问， 所以索性就选择在github上面使用jekyll搭建博客。

---

##搭建过程

[jekyll官网](http://jekyllrb.com/)上面有详细的安装教程，这里我把我安装遇过程记录下。

jekyll需要用到ruby，windows系统需要到[ruby官网](https://www.ruby-lang.org/en/downloads/)下载安装，我用的mac，osx里面自带ruby，但我从来没用过ruby，需要先更新下ruby的版本号：

	#查看当前ruby版本
	$ ruby -v

	#列出已知的ruby版本
	$ rvm list known
	#安装ruby 1.9.3
	$ rvm install 1.9.3


更新成功后查看查看ruby版本

![ruby-v]({{ "/css/pics/ruby-v.png"}})

更新成功后开始安装jekyll

	$gem install jekyll

安装成功后照样查看下版本，看是否安装成功

![jekyll-v]({{ "/css/pics/jekyll-v.png"}})

这样jekyll就已经全部安装完毕了，下面就可以开始搭建自己的博客。

---

###搭建自己的个人博客

![create-blog]({{ "/css/pics/create-bolg.png"}})

	#创建blog
	$ jekyll new "Bolg Name"

	#启动网站
	$ jekyll serve

使用  jekyll new 命令后会在当前工作目录创建一个blog工程文件夹

文件结构如下：

![blog-dir]({{ "/css/pics/my-blog-dir.png"}})


_site目录是启动服务后生成的静态文件目录，git的过滤规则文件也要把这文件夹添加进去。

现在就可以使用jekyll搭建好的博客，当然默认是非常简陋的，想要个性化的自己来写UI这部分。
不想麻烦的也可以使用一些现在的jekyll模版

如: [http://jekyllthemes.org/]("http://jekyllthemes.org/")

---

##绑定个性域名
github page 默认使用 username.github.io 做域名，但也可以使用自己已有的域名做绑定。

我之前在万网买了一个.xyz的域名，当时见便宜，而且觉得xyz挺有意思的，就注册了一个。
但现在xyz在国内并不能做备案，放着也没用，而且github是国外的服务器，没备案的域名也可以的。

首先在域名管理哪里添加一个CNAME的记录。

![cname]({{ "/css/pics/cname.png"}})

然后在博客的仓库里面添加一个CNAME文件，里面填写你的域名就行了

---

##遇到的问题

在更新ruby和用gem 安装的jekyll的时候非常慢，而且安装多次也没有成功， 原因是官方的源不怎么稳定，不过幸好淘宝做了一个国内的镜像，更换下源再安装就快多了。

更改淘宝源的命令如下：

	# 删除默认的官方源	
	$ gem sources -r https://rubygems.org/

	# 添加淘宝源
	$ gem sources -a https://ruby.taobao.org/

	# 查看当前源
	$ gem sources -l 




