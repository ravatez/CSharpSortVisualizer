using Sort.Base;

public class PigeonholeSort : Base
{
    public override void Sort(int[] elements)
    {
        int min = elements.Min();
        int max = elements.Max();
        int range = max - min + 1;

        List<int>[] holes = new List<int>[range];
        for (int i = 0; i < range; i++)
            holes[i] = new List<int>();

        foreach (var item in elements)
            holes[item - min].Add(item);

        int index = 0;
        foreach (var hole in holes)
        {
            foreach (var item in hole)
                elements[index++] = item;
        }
    }
}