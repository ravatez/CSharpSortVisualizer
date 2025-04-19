using Sort.Base;

public class SelectionSort : Base
{
    public override void Sort(int[] elements)
    {
        int n = elements.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIdx = i;
            for (int j = i + 1; j < n; j++)
            {
                if (elements[j] < elements[minIdx])
                    minIdx = j;
            }
            Swap(elements, i, minIdx);
        }
    }
}