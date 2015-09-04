---
layout: post
title:  "在raspbian上安装mono"
date:   2015-09-04 23:43:54
categories: mono .net linux
excerpt: XyzMax 
published: true
---

* content
{:toc}

##废话
其实买这个树莓派的初衷也是出于想把以往写的.net程序放在linux上面跑，毕竟C#才是我的最爱。

---

好了，废话不多说，开始我的mono之旅。


---

##mono
mono是指由Novell公司(由Xamarin发起，并由Miguel de lcaza领导的，一个致力于开创·NET在Linux上使用的开源工程


---

###安装mono

按照这里的方法直接在apt上面用命令行安装[https://www.maketecheasier.com/write-c-sharp-programs-raspberry-pi](https://www.maketecheasier.com/write-c-sharp-programs-raspberry-pi)

	$ sudo apt-get update
	$ sudo apt-get install mono-runtime

这次安装快得让人不可思议，短短1分钟不到就安装完成，这尼玛比windows 下安装 .net framework还要简单快速方便。

![mono-runtime-error]({{ "/css/pics/mono-runtime-successful.png"}})

正在感叹开源伟大的时候发现其实并没有什么卵用，把以前写的程序放上去一样不能运行。

看起来好像只是安装了最基本的.net运行时。

直接运行在windows上面编译过的exe报以下错误

![mono-run-error]({{ "/css/pics/mono-run-error.png"}})

到 /usr/lib/mono 目录下面看发现根本没有2.0的目录，只有4.0和4.5的目录，难道是新版本的mono不带2.0了？ 而且我记得CozyBili.exe也不是用2.0版本编写的。

好的，试试在 /usr/lib/mono/ 目录创建一个2.0的目录然后直接把4.5里面的文件拷到2.0里面去

	$ sudo mkdir /usr/lib/mono/2.0
	$ sudo cp -rf /usr/lib/mono/4.5/* /usr/lib/mono/2.0

拷贝过去后再运行，也是同样的结果，不过这次不是缺少mscorlib.dll，而是缺少system.linq.dll。

看来应该是安装有点了问题，很多.net基本的dll库都不在里面的。

---

最后在这里[https://www.maketecheasier.com/write-c-sharp-programs-raspberry-pi](https://www.maketecheasier.com/write-c-sharp-programs-raspberry-pi)得知还有其他得安装方式：

	$ sudo apt-get install mono-complete

这次的安装内容非常丰富，足足有差不多200M(好像是吧，没截图)，不过还好因为软件源用的是国内高校的，整个安装过程也非常快速，几分钟不到就下载安装完毕了。

![mono]({{ "/css/pics/mono-successful.png"}})

Yes！   在windows平台上面开发、编译的.net程序终于在Linux上面跑起来了！！


C#才是当之无愧的一次编译，到处运行。


---

##完