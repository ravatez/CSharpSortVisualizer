using Sort.Base;

public class CombSort : Base
{
    public override void Sort(int[] elements)
    {
        int gap = elements.Length;
        bool swapped = true;
        while (gap != 1 || swapped)
        {
            gap = GetNextGap(gap);
            swapped = false;
            for (int i = 0; i < elements.Length - gap; i++)
            {
                if (elements[i] > elements[i + gap])
                {
                    Swap(elements, i, i + gap);
                    swapped = true;
                }
            }
        }
    }

    private int GetNextGap(int gap)
    {
        gap = (gap * 10) / 13;
        return (gap < 1) ? 1 : gap;
    }
}