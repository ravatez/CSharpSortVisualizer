using SortingVisualization;
using System;
public class TimSort : Base
{
    const int RUN = 32;

    public override void Sort(int[] elements)
    {
        int n = elements.Length;
        for (int i = 0; i < n; i += RUN)
            InsertionSort(elements, i, Math.Min((i + RUN - 1), (n - 1)));

        for (int size = RUN; size < n; size = 2 * size)
        {
            for (int left = 0; left < n; left += 2 * size)
            {
                int mid = left + size - 1;
                int right = Math.Min((left + 2 * size - 1), (n - 1));

                if (mid < right)
                    Merge(elements, left, mid, right);
            }
        }
    }

    private void InsertionSort(int[] arr, int left, int right)
    {
        for (int i = left + 1; i <= right; i++)
        {
            int temp = arr[i];
            int j = i - 1;
            while (j >= left && arr[j] > temp)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = temp;
        }
    }

    private void Merge(int[] arr, int l, int m, int r)
    {
        int len1 = m - l + 1, len2 = r - m;
        int[] left = new int[len1];
        int[] right = new int[len2];

        for (int x = 0; x < len1; x++)
            left[x] = arr[l + x];
        for (int x = 0; x < len2; x++)
            right[x] = arr[m + 1 + x];

        int i = 0, j = 0, k = l;

        while (i < len1 && j < len2)
        {
            if (left[i] <= right[j])
                arr[k++] = left[i++];
            else
                arr[k++] = right[j++];
        }

        while (i < len1)
            arr[k++] = left[i++];

        while (j < len2)
            arr[k++] = right[j++];
    }
}