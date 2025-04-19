using Sort.Base;

public class QuickSort : Base
{
    public override void Sort(int[] elements)
    {
        QuickSortRecursive(elements, 0, elements.Length - 1);
    }

    private void QuickSortRecursive(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);
            QuickSortRecursive(arr, low, pi - 1);
            QuickSortRecursive(arr, pi + 1, high);
        }
    }

    private int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }
        Swap(arr, i + 1, high);
        return i + 1;
    }
}
