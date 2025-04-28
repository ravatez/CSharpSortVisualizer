using SortingVisualization;

public class MergeSort : Base
{
    public override void Sort(int[] elements)
    {
        MergeSortRecursive(elements, 0, elements.Length - 1);
    }

    private void MergeSortRecursive(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int middle = left + (right - left) / 2;
            MergeSortRecursive(arr, left, middle);
            MergeSortRecursive(arr, middle + 1, right);
            Merge(arr, left, middle, right);
        }
    }

    private void Merge(int[] arr, int left, int middle, int right)
    {
        int n1 = middle - left + 1;
        int n2 = right - middle;

        int[] L = new int[n1];
        int[] R = new int[n2];

        for (int i = 0; i < n1; i++)
            L[i] = arr[left + i];
        for (int j = 0; j < n2; j++)
            R[j] = arr[middle + 1 + j];

        int i1 = 0, j1 = 0, k = left;

        while (i1 < n1 && j1 < n2)
        {
            if (L[i1] <= R[j1])
                arr[k++] = L[i1++];
            else
                arr[k++] = R[j1++];
        }

        while (i1 < n1)
            arr[k++] = L[i1++];

        while (j1 < n2)
            arr[k++] = R[j1++];
    }
}
