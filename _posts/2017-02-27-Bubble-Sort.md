---
layout: post
title:  "Bubble Sort-冒泡排序"
date:   2017-02-27 17:30:24
categories: 算法 排序
excerpt: xyz_max
published: true 
---

## Bubble Sort - 冒泡算法

持续比较相邻的元素，大的上升，小的下沉，冒泡

![Bubble Sort](../css/pics/bubble_sort.gif)

---

## Implementation

python

``` python
    def bubbleSort(alist):
        print(alist)
        for i in range(len(alist)):
            for j in range(len(alist)):
                if alist[j - 1] > alist[j]:
                    alist[j - 1], alist[j] = alist[j], alist[j - 1]
    return alist

```

C#

``` csharp

    public int[] BubbleSort(int[] array) {

        for (int i = 0; i < array.Length; i++) {
            Console.WriteLine(string.Join(",", array));
            for (int j = 1; j < array.Length - i; j++) {
                if (array[j - 1] > array[i]) {
                    var temp = array[j - 1];
                    array[j - 1] = array[j];
                    array[j] = temp;
                }
            }
        }
        return array;
    }

```

---

## 算法复杂度

平均情况与最坏情况均为 $$O(n^2)$$, 使用了 temp 作为临时交换变量，空间复杂度为 *O(1)*.