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
        public static void MergeSort(IList<double> list, int p, int r)
        {
            if (p >= r) return;
            int q = (p + r) / 2;
            MergeSort(list, p, q);
            MergeSort(list, q+1, r);
            Merge(list, p, q, r);
        }
    }
}
