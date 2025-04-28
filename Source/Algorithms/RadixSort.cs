using SortingVisualization;
using System.Linq;

public class RadixSort : Base
{
    public override void Sort(int[] elements)
    {
        int max = elements.Max();
        for (int exp = 1; max / exp > 0; exp *= 10)
            CountSort(elements, exp);
    }

    private void CountSort(int[] elements, int exp)
    {
        int n = elements.Length;
        int[] output = new int[n];
        int[] count = new int[10];

        for (int i = 0; i < n; i++)
            count[(elements[i] / exp) % 10]++;

        for (int i = 1; i < 10; i++)
            count[i] += count[i - 1];

        for (int i = n - 1; i >= 0; i--)
        {
            output[count[(elements[i] / exp) % 10] - 1] = elements[i];
            count[(elements[i] / exp) % 10]--;
        }

        for (int i = 0; i < n; i++)
            elements[i] = output[i];
    }
}