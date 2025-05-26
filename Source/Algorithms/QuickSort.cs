using SortingVisualization;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System;

public class QuickSort : ISortStrategy
{
    public async Task Sort(
        List<Rectangle> rectangles,
        Func<int, int, Task> animateSwap,
        Func<int, int, Task> highlight,
        Func<bool> isPaused,
        Func<bool> isRunning,
        Action<bool> setIsRunning)
    {
        await QuickSortRecursive(rectangles, 0, rectangles.Count - 1, animateSwap, highlight, isPaused, isRunning);

        Console.WriteLine("End of sort reached");
        setIsRunning?.Invoke(false);
    }

    private async Task QuickSortRecursive(
        List<Rectangle> arr,
        int low,
        int high,
        Func<int, int, Task> animateSwap,
        Func<int, int, Task> highlight,
        Func<bool> isPaused,
        Func<bool> isRunning)
    {
        if (low < high)
        {
            int pi = await Partition(arr, low, high, animateSwap, highlight, isPaused, isRunning);
            await QuickSortRecursive(arr, low, pi - 1, animateSwap, highlight, isPaused, isRunning);
            await QuickSortRecursive(arr, pi + 1, high, animateSwap, highlight, isPaused, isRunning);
        }
    }

    private async Task<int> Partition(
        List<Rectangle> arr,
        int low,
        int high,
        Func<int, int, Task> animateSwap,
        Func<int, int, Task> highlight,
        Func<bool> isPaused,
        Func<bool> isRunning)
    {
        var pivot = arr[high].Height;
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            while (isPaused())
                await Task.Delay(100);

            await highlight(j, high); // highlight current and pivot

            if (arr[j].Height < pivot)
            {
                i++;
                await animateSwap(i, j);
            }
        }

        await animateSwap(i + 1, high);
        return i + 1;
    }
    
}
