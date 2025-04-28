using SortingVisualization;

public class InsertionSort : Base
{
    public override void Sort(int[] elements)
    {
        int n = elements.Length;
        for (int i = 1; i < n; ++i)
        {
            int key = elements[i];
            int j = i - 1;

            while (j >= 0 && elements[j] > key)
            {
                elements[j + 1] = elements[j];
                j = j - 1;
            }
            elements[j + 1] = key;
        }
    }
}