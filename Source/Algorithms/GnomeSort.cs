using SortingVisualization;

public class GnomeSort : Base
{
    public override void Sort(int[] elements)
    {
        int index = 0;
        while (index < elements.Length)
        {
            if (index == 0 || elements[index] >= elements[index - 1])
                index++;
            else
            {
                Swap(elements, index, index - 1);
                index--;
            }
        }
    }
}