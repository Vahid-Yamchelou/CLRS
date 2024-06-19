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
    }
}
