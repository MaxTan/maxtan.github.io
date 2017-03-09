---
layout: post
title:  "Insertion Sort-插入排序"
date:   2017-03-09 22:28:14
categories: 算法 排序
excerpt: xyz_max
published: true 
---

## 插入排序

对于未排序序列，在经排序序列中从后向前扫描，找到相应的位置插入。实现通常使用*in-place*排序

1. 从第一个元素开始，该元素被认定为排序
2. 取下一个元素，对已排序数组从后面往前扫描
3. 若从排序数组中取出的元素大于新元素，则移至下一位
4. 重复步骤3，直至找到已排序元素小于或者等于新元素的位置
5. 插入新元素至该位置
6. 重复2-5


![Insertion Sort]({{ "/css/pics/insertion_sort.gif"}})

---

## Implementation

python

``` python
def insertionSort(alist):
    for i in range(1, len(alist)):
        temp = alist[i]
        j = i - 1
        while j >= 0 and alist[j] > temp:
            alist[j + 1] = alist[j]
            alist[j] = temp
            j -= 1
    return alist
```

C#

``` csharp
namespace Algorithms {

    public partial class Sort {

        public int[] InsertionSort(int[] array) {

            for (int i = 1; i < array.Length; i++) {
                var temp = array[i];
                for (int j = i - 1; j >= 0 && array[j] > temp; j--) {
                    array[j + 1] = array[j];
                    array[j] = temp;
                }
            }
            return array;
        }
    }
}
```

---

## 算法复杂度

如果目标是个*n*个元素的序列升序降序排序，那么采用插入排序存在最好和最坏情况。最好的情况是，
序列已经升序排序了在这种情况下，需要进行的比较操作需$$(n-1)$$次即可。最坏情况就是，
序列是降序排序，那么此时需要进行的比较次数为$${2 \over 1}n(n-1)$$次。
插入排序不适合对于数据量比较大的排序应用。 但是如果需要排序的数据量小，例如量级少于千，那么插入排序还是一个不错的选择。

