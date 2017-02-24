---
layout: post
title:  "Linked List-链表"
date:   2017-02-24 16:09:24
categories: 数据结构
excerpt: xyz_max
published: true 
---

* content
{:toc}

# Linked List - 链表

链表是线性表的一种。 线性表是最基本、最简单、也是最常用的一种数据结构。 线性表中数据元素之间的关系是一对一关系、除了第一个和最后一个数据元素之外，其他数据元素都是首尾相接的。线性表有两种存储方式，一种是顺序存储结构，另一只是链式存储结构。常用的数组就是一种典型的顺序存储结构。


链式存储结构是两个相邻的元素，在内存中不是相邻的，每一个元素都有一个指针域，指针域一般是存储着下一个元素的指针。这种存储方式的优点是定点插入和定点删除，时间复杂度为*O(1)*,而且不会浪费太多内存，添加元素的时候才会申请内存，删除元素就会释放内存。缺点是访问的时间复杂度最坏为*O(n)*.

顺序表的特性是随机读取，也就是访问一个元素的时间复杂度是*O(1)*,链式表的特征是插入和删除的时间复杂度为O(1)。

链表就是链式存储的线性表。 根据指针域的不同，链表分为单向链表、双向链表和循环链表。

## 代码实现

Python

``` python
    class ListNode:
        def _init_(self, val):
            self.val = val
            self.next = None
```

C#

``` csharp

    public class ListNode {

        int val;
        public ListNode Next;

        public ListNode(int val) {
            this.val = val;
            this.Next = null;
        }
    }
```

---

## 链表的基本操作

### 反转链表

#### 单向链表

链表的基本形式是: `1 -> 2 -> 3 -> null`, 反转需要变成 `3 -> 2 -> 1 -> null`。

* 访问讴歌检点curt.next时，需要检验curt是否为null。
* 要把反转后的最后一个节点指向null。


Python

```python
    class ListNode:

        def __init__(self, val):
            self.val = val
            self.next = None


        def reverse(self, head):
            prev = None
            while head:
                temp = head.next
                head.next = prev
                prev = head
                head = temp
            return prev
```


C#

```csharp
    public class ListNode {
        int val;
        public ListNode Next;

        public ListNode(int val) {
            this.val = val
        }
    }

    //迭代方式
    public ListNode Reverse(ListNode head) {
        ListNode prev = null;

        while (head != null) {
            ListNode next = head.Next;
            head.Next = prev;
            prev = head;
            head = next;
        }
        return prev;
    }

    //递归方式
    public ListNode Reverse(ListNode head) {
        if (head == null || head.Next == null) {
            return head;
        }
        ListNode next = head.Next;
        ListNode newHead = Reverse(next);
        next.Next = head;
        head.Next = null;
        return newHead;
    }

```

---

#### 双向链表
双向链表和单向链表的区别在于：双向链表的反转核心在于`next`和`prev`域的交换,还需要注意的是当前节点和上一节点的递推。

python

``` python
    class DListNode:

        def __init__(self, val):
            self.val = val
            self.prev = self.next = null

        def reverse(self, head):
            curt = None
            while head:
                curt = head
                head = curt.next
                curt.next = curt.prev
                curt.prev = head

            return curt

```


C#

```csharp
    public class DListNode {
        int val;
        public DListNode Prev;
        public DListNode Next;

        public DListNode(int val) {
            this.val = val;
            this.Prev = this.Next = null;
        }
    }

    public DListNode Reverse(DListNode head) {
        DListNode curt = null;
        while(head != null) {
            curt = head;
            head = curt.Next;
            curt.Next = curt.Prev;
            curt.Prev = head;
        }
        return curt
    }
```
