using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRS
{
    public static class SortAlgorithms
    {
        public static void InsertionSort(IList<double> list)
        {
            for(int i = 1; i < list.Count; i++)
            {
                double key = list[i];
                int j = i - 1;
                while(j >= 0 && key < list[j])
                {
                    list[j+1] = list[j];
                    j--;
                }
                list[j + 1] = key;
            }
        }

        private static void Merge(IList<double> list, int p, int q, int r)
        {
            int countLeft = q - p + 1;
            int countRight = r - q;
            List<double> left = new();
            List<double> right = new();

            for (int i = 0; i < countLeft; i++)
            {
                left.Add(list[p + i]);
            }

            for(int i = 0; i < countRight; i++)
            {
                right.Add(list[q+1 + i]);
            }

            int leftIndex = 0;
            int rightIndex = 0;
            int listIndex = p;

            while (leftIndex < countLeft && rightIndex < countRight)
            {
                if(left[leftIndex] < right[rightIndex])
                {
                    list[listIndex] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    list[listIndex] = right[rightIndex];
                    rightIndex++;
                }
                listIndex++;
            }

            while(leftIndex < countLeft)
            {
                list[listIndex] = left[leftIndex];
                listIndex++;
                leftIndex++;
            }

            while (rightIndex < countRight)
            {
                list[listIndex] = right[rightIndex];
                listIndex++;
                rightIndex++;
            }
        }

        /// <summary>
        /// first call -> MergeSort(list, 0, list.Count - 1)
        /// </summary>
        /// <param name="list">list to sort</param>
        /// <param name="p">from index</param>
        /// <param name="r">to index</param>
        public static void MergeSort(IList<double> list, int p, int r)
        {
            if (p >= r) return;
            int q = (p + r) / 2;
            MergeSort(list, p, q);
            MergeSort(list, q+1, r);
            Merge(list, p, q, r);
        }

        public static void HeapSort(double[] list)
        {
            HeapSort heap = new(list);
            heap.Sort();
        }
    }

    class HeapSort
    {
        double[] list;
        int heapSize;

        public HeapSort(double[] arr)
        {
            list = arr;
            heapSize = arr.Length;
            BuildMaxHeap();
        }

        public int Left(int i)
        {
            return (2 * i) + 1;
        }

        public int Right(int i)
        {
            return (2 * i) + 2;
        }

        public void MaxHeapify(int i)
        { 
            int l = Left(i);
            int r = Right(i);
            int largest = i;

            if (l < heapSize && list[l] > list[i])
            {
                largest = l;
            }

            if (r < heapSize && list[r] > list[largest])
            {
                largest = r;
            }

            if (largest != i)
            {
                double temp = list[i];
                list[i] = list[largest];
                list[largest] = temp;
                MaxHeapify(largest);
            }
        }

        private void BuildMaxHeap()
        {
            for (int i = (list.Length / 2) - 1; i >= 0; i--)
            {
                MaxHeapify(i);
            }
        }

        public void Sort()
        {
            for (int i = list.Length - 1; i > 0; i--)
            {
                double temp = list[i];
                list[i] = list[0];
                list[0] = temp;

                heapSize--;
                MaxHeapify(0);
            }
        }
    }
}
