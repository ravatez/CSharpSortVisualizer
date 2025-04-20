using Sort.Base;

public class ShellSort : Base
{
    public override void Sort(int[] elements)
    {
        int n = elements.Length;
        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < n; i++)
            {
                int temp = elements[i];
                int j;
                for (j = i; j >= gap && elements[j - gap] > temp; j -= gap)
                    elements[j] = elements[j - gap];
                elements[j] = temp;
            }
        }
    }
}