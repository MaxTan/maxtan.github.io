---
layout: post
title:  "在windwos10里面使用zsh"
date:   2016-08-03 16:50:54
categories: windwos10 linux zsh
excerpt: XyzMax
published: true
---

* content
{:toc}

## windows10 Redstone


今天微软正式推送了Win10 Redstone周年更新，终于可以在windows上面愉快地使用zsh了。

记录一下安装过程。

----


## Bash on Ubuntu on Windows

先把windows10更新到1607版本号，在程序面板>启用windows功能里面把 *适用于Linux的Windows子系统(Beta)* 给打开，并且把开发人员模式打开就可以开始安装bash了。


安装完后会提示新建用户，这个时候就已经大功告成了。

![ruby-v]({{ "/css/pics/install-bash.png"}})

---

### oh-my-zsh必须要有

    $ sudo apt-get install zsh
    $ wget https://github.com/robbyrussell/oh-my-zsh/raw/master/tools/install.sh -O - | sh


---

### 把zsh修改成默认启动shell

    $ vim ~/.bashrc

![ruby-v]({{ "/css/pics/launch-zsh.png"}})


---

### 把vscode的终端也换成zsh

修改用户配置文件settings.json，把bash.exe覆盖上去。

*"terminal.integrated.shell.windows": "C:\\Windows\\sysnative\\bash.exe"*

![ruby-v]({{ "/css/pics/vscode-zsh.png"}})


----

## 完








