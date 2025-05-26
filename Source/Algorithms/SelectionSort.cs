using SortingVisualization;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System;
public class SelectionSort : ISortStrategy
{
    public async Task Sort(
        List<Rectangle> rectangles,
        Func<int, int, Task> animateSwap,
        Func<int, int, Task> highlight,
        Func<bool> isPaused,
        Func<bool> isRunning,
        Action<bool> setIsRunning)
    {
        int n = rectangles.Count;

        for (int i = 0; i < n - 1; i++)
        {
            int minIdx = i;

            for (int j = i + 1; j < n; j++)
            {
                while (isPaused())
                    await Task.Delay(100);

                await highlight(minIdx, j);

                if (rectangles[j].Height < rectangles[minIdx].Height)
                {
                    minIdx = j;
                }

                await Task.Delay(100);
            }

            if (minIdx != i)
            {
                await animateSwap(i, minIdx);
            }
        }
        Console.WriteLine("End of sort reached");
        setIsRunning?.Invoke(false);
    }
}