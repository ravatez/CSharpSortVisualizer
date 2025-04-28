using System;
using SortingVisualization;

public class SortContextManager
{
    private int[] elements = Array.Empty<int>();
    private Base currentSortContext;

    public void AddContext(Base sortContext)
    {
        currentSortContext = sortContext ?? throw new ArgumentNullException(nameof(sortContext), "Sort context cannot be null.");
    }

    public void AddElements(int[] newElements)
    {
        if (newElements == null || newElements.Length == 0)
            throw new ArgumentException("Elements array cannot be null or empty.", nameof(newElements));

        elements = newElements;
    }

    public void Sort()
    {
        if (currentSortContext == null)
            throw new InvalidOperationException("Sort context is not set.");

        currentSortContext.Sort(elements); // Or `ref elements` if your base class supports ref
    }

    public void Display()
    {
        if (elements.Length == 0)
        {
            Console.WriteLine("No elements to display.");
            return;
        }

        Console.WriteLine("Sorted Elements:");
        foreach (var number in elements)
        {
            Console.WriteLine(number);
        }
    }
}

