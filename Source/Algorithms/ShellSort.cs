using SortingVisualization;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System;
public class ShellSort : ISortStrategy
{
    public async Task Sort(
        List<Rectangle> rectangles,
        Func<int, int, Task> animateSwap,
        Func<int, int, Task> highlight,
        Func<bool> isPaused,
        Func<bool> isRunning, Action<bool> setIsRunning)
    {
        int n = rectangles.Count;

        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < n; i++)
            {
                Rectangle temp = new Rectangle { Height = rectangles[i].Height };
                int j = i;

                while (j >= gap && rectangles[j - gap].Height > temp.Height)
                {
                    while (isPaused()) await Task.Delay(100);

                    await highlight(j - gap, j);
                    rectangles[j].Height = rectangles[j - gap].Height;
                    j -= gap;

                    await Task.Delay(30);
                }

                rectangles[j].Height = temp.Height;
                await Task.Delay(30);
            }
        }
        Console.WriteLine("End of sort reached");
        setIsRunning?.Invoke(false);
    }
}