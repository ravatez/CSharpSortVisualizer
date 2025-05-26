using SortingVisualization;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System;

public class InsertionSort : ISortStrategy
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

        for (int i = 1; i < n; i++)
        {
            int j = i;

            while (j > 0 && rectangles[j - 1].Height > rectangles[j].Height)
            {
                while (isPaused())
                    await Task.Delay(100);

                await highlight(j - 1, j);
                await animateSwap(j - 1, j);

                j--;
            }
        }
        Console.WriteLine("End of sort reached");
        setIsRunning?.Invoke(false);
    }
}