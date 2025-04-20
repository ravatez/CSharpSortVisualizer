using Sort.Base;
public class CountingSort : Base
{
    public override void Sort(int[] elements)
    {
        int max = elements.Max();
        int min = elements.Min();
        int range = max - min + 1;
        int[] count = new int[range];
        int[] output = new int[elements.Length];

        foreach (int t in elements)
            count[t - min]++;

        for (int i = 1; i < count.Length; i++)
            count[i] += count[i - 1];

        for (int i = elements.Length - 1; i >= 0; i--)
        {
            output[count[elements[i] - min] - 1] = elements[i];
            count[elements[i] - min]--;
        }

        for (int i = 0; i < elements.Length; i++)
            elements[i] = output[i];
    }
}