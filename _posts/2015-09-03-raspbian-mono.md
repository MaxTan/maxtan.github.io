---
layout: post
title:  "在raspbian上安装mono"
date:   2015-09-03 22:14:54
categories: mono .net linux
excerpt: XyzMax 
published: false
---

* content
{:toc}

##安装mono

	$ sudo apt-get install mono-runtime

然而这并没有什么卵用

	$ sudo apt-get install mono-complete

这样？ 一会看看

[https://www.maketecheasier.com/write-c-sharp-programs-raspberry-pi](https://www.maketecheasier.com/write-c-sharp-programs-raspberry-pi)


##遇到问题

虽然安装mono很顺利，但在测试的时候发现程序启动的时候会自动到 /usr/lib/mono/2.0	里面去找相应的dll，可能是因为项目模式2.0的问题，而mono只安装了	 4.0 和4.5

![mono-runtime-error]({{ "/css/pics/mono-runtime-error.png"}})

根据错误提示，手动把4.5的目录里面的文件拷贝过去

先创建一个2.0的目录

	$ sudo mkdir /usr/lib/mono/2.0

把4.5里面的文件拷贝过去

	$ sudo cp -rf /usr/lib/mono/4.5/* /usr/lib/mono/2.0