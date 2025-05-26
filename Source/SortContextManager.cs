using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Shapes;
using SortingVisualization;

//public class SortContextManager
//{
//    private int[] elements = Array.Empty<int>();
//    private Base currentSortContext;

//    public void AddContext(Base sortContext)
//    {
//        currentSortContext = sortContext ?? throw new ArgumentNullException(nameof(sortContext), "Sort context cannot be null.");
//    }

//    public void AddElements(int[] newElements)
//    {
//        if (newElements == null || newElements.Length == 0)
//            throw new ArgumentException("Elements array cannot be null or empty.", nameof(newElements));

//        elements = newElements;
//    }

//    public void Sort()
//    {
//        if (currentSortContext == null)
//            throw new InvalidOperationException("Sort context is not set.");

//        currentSortContext.Sort(elements); // Or `ref elements` if your base class supports ref
//    }

//    public void Display()
//    {
//        if (elements.Length == 0)
//        {
//            Console.WriteLine("No elements to display.");
//            return;
//        }

//        Console.WriteLine("Sorted Elements:");
//        foreach (var number in elements)
//        {
//            Console.WriteLine(number);
//        }
//    }
//    public int[] GetElements()
//    {
//        return elements;
//    }
//}

public class SortContextManager
{
    private ISortStrategy strategy;

    public void SetStrategy(ISortStrategy sortStrategy)
    {
        strategy = sortStrategy ?? throw new ArgumentNullException(nameof(sortStrategy));
    }

    public async Task Sort(List<Rectangle> rectangles, Func<int, int, Task> animateSwap, Func<int, int, Task> highlight, Func<bool> isPaused, Func<bool> isRunning, Action<bool> setIsRunning)
    {
        if (strategy == null)
            throw new InvalidOperationException("Sorting strategy not set.");

        await strategy.Sort(rectangles, animateSwap, highlight, isPaused, isRunning, setIsRunning);
    }
}

