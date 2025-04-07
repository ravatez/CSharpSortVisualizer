using System;

public class HeapSort : IsSort
{
    public void Sort(int[] array)
    {
        int n = array.Length;

        // Build max heap
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(array, n, i);
        }

        // Extract elements from heap one by one
        for (int i = n - 1; i >= 0; i--)
        {
            // Move current root to end
            Swap(array, 0, i);

            // Call max heapify on the reduced heap
            Heapify(array, i, 0);
        }
    }

    private static void Heapify(int[] array, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && array[left] > array[largest])
        {
            largest = left;
        }

        if (right < n && array[right] > array[largest])
        {
            largest = right;
        }

        if (largest != i)
        {
            Swap(array, i, largest);
            Heapify(array, n, largest);
        }
    }

    private static void Swap(int[] array, int a, int b)
    {
        int temp = array[a];
        array[a] = array[b];
        array[b] = temp;
    }
}
