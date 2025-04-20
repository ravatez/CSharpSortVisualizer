using System;
using Sort.Base;

public class BubbleSort : Base
{
    public override void Sort(int[] elements)
    {
        int n = elements.Length; // Corrected to access the length of the array
        bool swapped;
        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (elements[j] > elements[j + 1])
                {
                    Swap(elements, j, j + 1);
                    swapped = true;
                }
            }
            // If no two elements were swapped in the inner loop, then the array is already sorted
            if (!swapped)
                break;
        }
    }
}