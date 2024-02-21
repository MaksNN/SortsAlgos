using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР_САОД_7._3._2
{
    static class SortingAlgorithms
    {
        // Пузырьковая сортировка
        static public int[] BubbleSort(int[] items)
        {
            for (int i = 0; i < items.Length - 1; i++)
            {
                for (int j = 0; j < items.Length - i - 1; j++)
                {
                    if (items[j] > items[j + 1])
                    {
                        int buf = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = buf;
                    }
                }
            }
            return items;
        }

        // Сортировка вставками
        static public void InsertionSort(int[] items)
        {
            int sortedRangeEndIndex = 1;

            while (sortedRangeEndIndex < items.Length)
            {
                if (items[sortedRangeEndIndex].CompareTo(items[sortedRangeEndIndex - 1]) < 0)
                {
                    int insertIndex = FindInsertionIndex(items, items[sortedRangeEndIndex]);
                    Insert(items, insertIndex, sortedRangeEndIndex);
                }

                sortedRangeEndIndex++;
            }
        }

        static private int FindInsertionIndex(int[] items, int valueToInsert)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].CompareTo(valueToInsert) > 0)
                {
                    return i;
                }
            }
            throw new InvalidOperationException("Индекс не найден");
        }

        static private void Insert(int[] itemArray, int indexInsertingAt, int indexInsertingFrom)
        {
            int temp = itemArray[indexInsertingAt];
            itemArray[indexInsertingAt] = itemArray[indexInsertingFrom];
            for (int current = indexInsertingFrom; current > indexInsertingAt; current--)
            {
                itemArray[current] = itemArray[current - 1];
            }
            itemArray[indexInsertingAt + 1] = temp;
        }

        // Сортировка слиянием
        static public void MegreSort(int[] items)
        {
            if (items.Length <= 1)
            {
                return;
            }
            int leftSize = items.Length / 2;
            int rightSize = items.Length - leftSize;
            int[] left = new int[leftSize];
            int[] right = new int[rightSize];
            Array.Copy(items, 0, left, 0, leftSize);
            Array.Copy(items, leftSize, right, 0, rightSize);
            MegreSort(left);
            MegreSort(right);
            Merge(items, left, right);
        }

        static private void Merge(int[] items, int[] left, int[] right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int targetIndex = 0;
            int remaining = left.Length + right.Length;
            while (remaining > 0)
            {
                if (leftIndex >= left.Length)
                {
                    items[targetIndex] = right[rightIndex++];
                }
                else if (rightIndex >= right.Length)
                {
                    items[targetIndex] = left[leftIndex++];
                }
                else if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    items[targetIndex] = left[leftIndex++];
                }
                else
                {
                    items[targetIndex] = right[rightIndex++];
                }
                targetIndex++;
                remaining--;
            }
        }

        // Сортировка Шелла
        static public void ShellSort(int[] a)
        {
            int b, i, j, k, h;
            b = a.Length;
            k = b / 2;
            while (k > 0)
            {
                for (i = 0; i < b - k; i++)
                {
                    j = i;
                    while (j >= 0 && a[j] > a[j + k])
                    {
                        h = a[j];
                        a[j] = a[j + k];
                        a[j + k] = h;
                        j--;
                    }
                }
                k = k / 2;
            }
        }

        // Быстрая сортировка
        static public void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int point = Partition(array, left, right);
                QuickSort(array, left, point);
                QuickSort(array, point + 1, right);
            }
        }

        static public int Partition(int[] array, int left, int right)
        {
            int value = array[(left + right) / 2];
            int i = left;
            int j = right;
            while (i <= j)
            {
                while (array[i] < value)
                    i++;
                while (array[j] > value)
                    j--;
                if (i >= j) break;

                int idem = array[j];
                array[j] = array[i];
                array[i] = idem;
                i++;
                j--;
            }
            return j;
        }
    }
}
