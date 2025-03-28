using System;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 34, 7, 23, 32, 5, 62 };
        Console.WriteLine("Original array: " + string.Join(", ", array));
        
        QuickSort.Sort(array, 0, array.Length - 1);
        Console.WriteLine("Quick Sorted array: " + string.Join(", ", array));

        MergeSort.Sort(array, 0, array.Length - 1);
        Console.WriteLine("Merge Sorted array: " + string.Join(", ", array));

        HeapSort.Sort(array);
        Console.WriteLine("Heap Sorted array: " + string.Join(", ", array));

        BubbleSort.Sort(array);
        Console.WriteLine("Bubble Sorted array: " + string.Join(", ", array));

        InsertionSort.Sort(array);
        Console.WriteLine("Insertion Sorted array: " + string.Join(", ", array));
    }
}