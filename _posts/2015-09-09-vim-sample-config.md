---
layout: post
title:  "Vim的简单配置"
date:   2015-09-9 17:30:54
categories: linux vim
excerpt: XyzMax vim配置
published: true
---

* content
{:toc}


##简单配置

用vim编辑 ~/.vimrc , 我这里没有，直接创建一个

	set tabstop=4
	set softtabstop=4
	set shiftwidth=4
	set expandtab

	set nu		#设置行号
	set autoindet	#设置自动缩进
	syntax on 	#设置语法高亮

![config]({{ "/css/pics/vim-sample-config.png"}})