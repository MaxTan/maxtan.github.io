---
layout: post
title:  "在Linux上面部署.NET网站"
date:   2015-09-8 00:07:54
categories: 开源项目 Nancy mono Linux dotnet
excerpt: XyzMax 在Linux后台运行Nancy自承载服务
published: true
---

* content
{:toc}


##序


拿到树莓派，第一件事就是想在上面部署自己写的Web应用，既然在Linux下面，那最常见的解决方案当属LAPM了，Linux就占首位；但我平常工作使用都是C#/.NET，所以我这里还是选择使用C#来做这件事情。

而且这样做显然更好玩。


---

##关于Web服务器

关于承载 .net web应用的http服务器在windows上面一般都是用iis，虽然apache、nginx等在Linux知名的Web服务器也有windows版本，但iis作为微软本家的产品不管是兼容性还是易用性都是首选。

随着mono的日渐成熟，微软也开始拥抱开源，apache、nginx以及国人的Jexus都有对应mono解决方案，但这里我更加钟情于[Nancy](http://nancyfx.org/)。

---

###Nancy

Nancy是一个[开源项目](https://github.com/NancyFx/Nancy)，我本身对这个项目也非常感兴趣，往后会对她做详细的文章记录，这里只作简单的介绍

* Nancy 是一个轻量级用于构建基于 HTTP 的 Web 服务，基于 .NET 和 Mono 平台，框架的目标是保持尽可能多的方式，并提供一个super-duper-happy-path所有交互。

* Nancy 设计用于处理  DELETE ,  GET ,  HEAD ,  OPTIONS ,  POST ,  PUT   和 PATCH  等请求方法，并提供简单优雅的 DSL 以返回响应。

* Nancy和Asp.net MVC原理相似，但有自己的一套路由机制，在使用上更加易用，可以用Nancy快速开发一些网站。

* Nancy并不依赖任何现有的框架，所以她可以运行在任何平台上面。

>最重要的一点是，她能做自承载服务，程序跑起来网站就运行了，不依赖任何http服务器。

---

##过程

由于这篇博文主要记录在Linux上面部署的过程的记录，所以程序方面会另开新章做专门的记录，写好的Web应用就是一个*.exe的可执行控制台程序，这里是已经把测试程序写好并且拷贝到Linux上面。

首先是在Linux上面[安装mono运行库](/2015/09/05/raspbian-mono/)，然后运行程序。

	$ mono NancyTestWebSite.exe




整个过程到这里就完了。 


没错，是完了，就是这么简单。

---

###部署过程中遇到的问题

---

####局域网内不能访问


    public void Start() {
        _nancyHost = new NancyHost(new Uri("http://127.0.0.1:12345"));
        _nancyHost.Start();
    }


在Nancy里面配置地址和端口，我这里直接用127.0.0.1即是本机IP，用12345端口号做测试。

程序运行后在树莓派本机可以通过浏览器访问到应用，但在同一局域网段内的其他的主机则无法访问，在这个问题上面浪费了我很多时间，而且弄了半天的防火墙才发现debian默认就不开防火墙，查看当前有监听到的端口，12345端口确实也是正常监听状态，不过后来发现了一点问题。

使用netstat命令查看端口使用状态

	$ netstat -an

![port-list-png]({{ "/css/pics/port-list.png"}})

ssh服务占用的22端口号，它的IP是 0.0.0.0 和127.0.0.1一样是指本机的IP，难道是这里的问题？？？

立马把程序改成0.0.0.0重新编译一份拷贝上了重新运行。。。。

终于有响应了，但为毛是400!?

不对，冷静分析下，有响应就说明已经通了。 400可能是mono运行库导致的程序内部错误问题。


回去Debug下程序才发现Nancy根本不支持0.0.0.0 IP 启动程序。

这下犯难了，127.0.0.1其他主机不能访问，0.0.0.0又不被允许。。。。  一拍脑门，不是还有个localhost么，试试。


哦耶！ 看成果。


![nancy-chenggong]({{ "/css/pics/nancy-successful.png"}})

---

####应用常驻后台

作为一个web应用，不能持续运行就没有一点意义。 而Nancy又是作为一个单独的程序做自承载的，以往在windows系统上面启动，放她哪里一直开着就能达到效果了，但在Linux上面，显然不能像windows那样，Linux拿来当服务器来使用，弄个GUI反而影响稳定性，况且我只是用ssh直接连接到pi上面的。


Linux的字符界面也可以使用多任务，在当前任务按ctrl ＋ z 把该任务挂起，再启用后台任务就行了，还有种方法就是在命令后面加 &

	$ mono NancyTestWebSite.exe &

但是Nancy做自承载的时候是直接用控制台项目，开一条工作线程，然后让当前线程挂起等待输入，从而达到一个让程序持续性运行的效果


    static void Main() {
        using (var nancyHost = new NancyHost(new Uri("http://localhost:12345/nancy/"))) {
            nancyHost.Start();
            Console.WriteLine("Nancy now listening");
            Console.ReadKey();
        }
        Console.WriteLine("Stopped. Good bye!");
    }

但在Linux运行后台任务时如果等待输入的操作，后台任务会呈stopped状态，所以要换种方式。


---

最后还是用到了[topshelf](http://topshelf-project.com/),把程序包一层做成服务，使它以服务的形式常驻在系统后台

最后使用nohup命令让程序常驻后台

	$ nohup mono Sofware/NancyTest/NancyLearn.exe & < nohup.out

退出当前用户，用其他用户登录查看进程，依旧还在。

![service]({{ "/css/pics/nancy-service.png"}})

---


##结束
部署的工作花了我一晚上的时间的，主要原因还是对Linux不熟悉，但可以看出mono还是非常厉害，不用重新编译，不用因为跨平台而对代码作出修改，牛逼！













