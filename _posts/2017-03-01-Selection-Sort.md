---
layout: post
title:  "Selection Sort-选择排序"
date:   2017-03-01 16:50:24
categories: 算法 排序
excerpt: xyz_max
published: true 
---


## 选择排序

择怕排序是一种简单直观的算法， 不断地选择剩余元素的最小者。

1. 找到数组最小元素并将其和数组第一个元素交换位置。
2. 在下剩下的元素中找到最小元素并将其与数组第二个元素交换，直至整个数组排序。

选择排序的主要优点与数据移动有关。如果某个元素位于正确的最终位置上则它不会被移动。 选择排序每次交换一对元素，他们当中至少有一个被移动到其最终位置上，因此对n个元素的表进行排序总共进行最多n-1次交换。
在所有的完全依靠交换去移动元素的排序方法中，选择排序属于非常好的一种。

* 比较次数 = $$(N-1)+(N-2)+(N+3)+...+2+1~N^2/2$$
* 交换次数 = N
* 运行时间与输入无关
* 数据移动最少

![Selection Sort]({{ "/css/pics/selection_sort.gif"}})

---


## Implementation

python

``` python
def selectionSort(alist):
    for i in range(len(alist)):
        print(alist)
        min_index = i

        for j in range(i + 1, len(alist)):
            if alist[j] < alist[min_index]:
                min_index = j
        alist[min_index], alist[i] = alist[i], alist[min_index]
    return alist


unsorted_list = [8, 5, 2, 6, 9, 3, 1, 4, 0, 7]
print(selectionSort(unsorted_list))
```


C#


``` csharp
using System;

namespace Algorithms {

    public partial class Sort {

        public int[] SelectionSort(int[] array) {

            var min = 0;
            var temp = 0;

            for (int i = 0; i < array.Length; i++) {
                Console.WriteLine(string.Join(",", array));
                min = i;
                for (int j = i + 1; j < array.Length; j++) {
                    if (array[min] > array[j]) {
                        min = j;
                    }
                    temp = array[min];
                    array[min] = array[i];
                    array[i] = temp;
                }
            }
            return array;
        }
    }
}
```

---


## 算法复杂度

选择排序的交换操作结余*0*和$$(n-1)$$次之间。 选择排序的比较操作为$$n(n-1)/2$$次之间。 选择排序的赋值操作介于*0*和$$3(n-1)$$次之间。

比较次数$$O(n^2)$$,比较次数与关键字的初始状态无关，总得比较次数$$N=(n-1)+(n-2)+...+1=n*(n-1)/2$$。交换次数$$O(n)$$,最好的情况是已经有序，交换0次；最坏的情况是逆序，交换$$n-1$$次。 交换次数比冒泡少，&&n&&值少小时，选择排序比冒泡快。

