using Sort.Base;

public class HeapSort : Base
{
    public override void Sort(int[] elements)
    {
        int n = elements.Length;

        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(elements, n, i);

        for (int i = n - 1; i >= 0; i--)
        {
            Swap(elements, 0, i);
            Heapify(elements, i, 0);
        }
    }

    private void Heapify(int[] arr, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && arr[left] > arr[largest])
            largest = left;

        if (right < n && arr[right] > arr[largest])
            largest = right;

        if (largest != i)
        {
            Swap(arr, i, largest);
            Heapify(arr, n, largest);
        }
    }
}