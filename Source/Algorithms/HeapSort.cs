using SortingVisualization;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System;

public class HeapSort : ISortStrategy
{
    public async Task Sort(
        List<Rectangle> rectangles,
        Func<int, int, Task> animateSwap,
        Func<int, int, Task> highlight,
        Func<bool> isPaused,
        Func<bool> isRunning, Action<bool> setIsRunning)
    {
        int n = rectangles.Count;

        for (int i = n / 2 - 1; i >= 0; i--)
            await Heapify(rectangles, n, i, animateSwap, highlight, isPaused);

        for (int i = n - 1; i >= 0; i--)
        {
            while (isPaused())
                await Task.Delay(100);

            await animateSwap(0, i);
            await Heapify(rectangles, i, 0, animateSwap, highlight, isPaused);
        }
        Console.WriteLine("End of sort reached");
        setIsRunning?.Invoke(false);
    }

    private async Task Heapify(
        List<Rectangle> rectangles,
        int n,
        int i,
        Func<int, int, Task> animateSwap,
        Func<int, int, Task> highlight,
        Func<bool> isPaused)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && rectangles[left].Height > rectangles[largest].Height)
            largest = left;

        if (right < n && rectangles[right].Height > rectangles[largest].Height)
            largest = right;

        if (largest != i)
        {
            while (isPaused())
                await Task.Delay(100);

            await highlight(i, largest);
            await animateSwap(i, largest);

            await Heapify(rectangles, n, largest, animateSwap, highlight, isPaused);
        }
    }
}