using Sort.Base;

public class CycleSort : Base
{
    public override void Sort(int[] elements)
    {
        int n = elements.Length;
        for (int cycleStart = 0; cycleStart <= n - 2; cycleStart++)
        {
            int item = elements[cycleStart];
            int pos = cycleStart;
            for (int i = cycleStart + 1; i < n; i++)
                if (elements[i] < item)
                    pos++;

            if (pos == cycleStart) continue;
            while (item == elements[pos]) pos++;
            if (pos != cycleStart)
            {
                int temp = item;
                item = elements[pos];
                elements[pos] = temp;
            }

            while (pos != cycleStart)
            {
                pos = cycleStart;
                for (int i = cycleStart + 1; i < n; i++)
                    if (elements[i] < item)
                        pos++;

                while (item == elements[pos]) pos++;
                if (item != elements[pos])
                {
                    int temp = item;
                    item = elements[pos];
                    elements[pos] = temp;
                }
            }
        }
    }
}