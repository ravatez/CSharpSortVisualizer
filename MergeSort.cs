using System;

public class MergeSort
{
    public static void Sort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;

            Sort(array, left, middle);
            Sort(array, middle + 1, right);

            Merge(array, left, middle, right);
        }
    }

    private static void Merge(int[] array, int left, int middle, int right)
    {
        int leftArrayLength = middle - left + 1;
        int rightArrayLength = right - middle;

        int[] leftArray = new int[leftArrayLength];
        int[] rightArray = new int[rightArrayLength];

        Array.Copy(array, left, leftArray, 0, leftArrayLength);
        Array.Copy(array, middle + 1, rightArray, 0, rightArrayLength);

        int i = 0, j = 0, k = left;

        while (i < leftArrayLength && j < rightArrayLength)
        {
            if (leftArray[i] <= rightArray[j])
            {
                array[k] = leftArray[i];
                i++;
            }
            else
            {
                array[k] = rightArray[j];
                j++;
            }
            k++;
        }

        while (i < leftArrayLength)
        {
            array[k] = leftArray[i];
            i++;
            k++;
        }

        while (j < rightArrayLength)
        {
            array[k] = rightArray[j];
            j++;
            k++;
        }
    }
}