using System;

namespace heapsort;

class Program
{
    static void Main(string[] args)
    {
        int[] array = new int[10];

        PopulateArray(array);

        Console.Write("   Массив до сортировки: ");
        PrintArray(array);

        HeapSort(array);

        Console.Write("Массив после сортировки: ");
        PrintArray(array);
    }

    static void HeapSort(int[] array)
    {
        int size = array.Length;

        for (int rootIdx = size / 2 - 1; rootIdx >= 0; rootIdx--)
            Heapify(array, rootIdx, size);

        // на этом месте у нас теперь всегда максимальный элемент под индексом 0
        // то есть root у нас гарантированно 0
        for (int i = size - 1; i >= 0; i--)
        {
            Swap(array, 0, i);
            Heapify(array, 0, i);
        }
    }

    static void Heapify(int[] array, int rootIdx, int size)
    {
        int leftIdx = rootIdx * 2 + 1;
        int rightIdx = rootIdx * 2 + 2;
        int curRootIdx = rootIdx;

        if (leftIdx < size && array[leftIdx] > array[curRootIdx])
            curRootIdx = leftIdx;

        if (rightIdx < size && array[rightIdx] > array[curRootIdx])
            curRootIdx = rightIdx;

        if (curRootIdx == rootIdx)
            return;

        Swap(array, curRootIdx, rootIdx);
        Heapify(array, curRootIdx, size);
    }

    static void Swap(int[] array, int idx0, int idx1)
    {
        int tmp = array[idx0];
        array[idx0] = array[idx1];
        array[idx1] = tmp;
    }

    static void PopulateArray(int[] array)
    {
        Random random = new Random();

        for (int i = 0; i < array.Length; i++)
            array[i] = random.Next(1, array.Length);
    }

    static void PrintArray(int[] array)
    {
        Console.WriteLine($"[{string.Join(", ", array)}]");
    }
}
