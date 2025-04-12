using System;
using Sort.Base;

public class BubbleSort : Base
{
    public void Sort()
    {
        if(IsEmpty())
        {
            Console.WriteLine("Doesnt have elements to Sort");
            return;
        }

        int n = elements;
        bool swapped;
        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (elements[j] > elements[j + 1])
                {
                    Swap(j, j + 1);
                    swapped = true;
                }
            }
            // If no two elements were swapped in the inner loop, then the array is already sorted
            if (!swapped)
                break;
        }
    }
}