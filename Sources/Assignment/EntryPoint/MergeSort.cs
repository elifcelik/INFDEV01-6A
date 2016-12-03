using System;
using System.Collections.Generic;
using System.Linq;

namespace EntryPoint
{
    public class MergeSort
    {
        public IEnumerable<T> Sort<T>(IEnumerable<T> input, Func<T, T, bool> compareFunc)
        {
            var inputArray = input.ToArray();

            MergeSortRecursive(ref inputArray, 0, inputArray.Length - 1, compareFunc);

            return inputArray;

        }

        private static void MergeSortRecursive<T>(ref T[] data, int left, int right, Func<T, T, bool> compareFunc)
        {
            if (left >= right) return;

            int m = left + (right - left) / 2;

            MergeSortRecursive(ref data, left, m, compareFunc);
            MergeSortRecursive(ref data, m + 1, right, compareFunc);
            Merge(ref data, left, m, right, compareFunc);
        }

        private static void Merge<T>(ref T[] data, int left, int mid, int right, Func<T, T, bool> compareFunc)
        {
            int i;
            int j;
            int k;

            int n1 = mid - left + 1;
            int n2 = right - mid;

            var leftArray = new T[n1];
            var rightArray = new T[n2];

            for (i = 0; i < n1; i++)
                leftArray[i] = data[left + i];

            for (j = 0; j < n2; j++)
                rightArray[j] = data[mid + 1 + j];

            i = 0;
            j = 0;
            k = left;

            while (i < n1 && j < n2)
            {
                if (compareFunc(leftArray[i], rightArray[j]))
                {
                    data[k] = leftArray[i];
                    i++;
                }
                else
                {
                    data[k] = rightArray[j];
                    j++;
                }

                k++;
            }

            while (i < n1)
            {
                data[k] = leftArray[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                data[k] = rightArray[j];
                j++;
                k++;
            }
        }
    }
}
