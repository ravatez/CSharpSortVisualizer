using SortingVisualization;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System;
using System.Windows;
public class BubbleSort : ISortStrategy
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
            Console.WriteLine($"Outer loop i={i}");
            for (int j = 0; j < n - i - 1; j++)
            {
                Console.WriteLine($"  Inner loop j={j}");
                while (isPaused())
                    await Task.Delay(100);

                if (!isRunning()) return;

                await highlight(j, j + 1);

                if (rectangles[j].Height > rectangles[j + 1].Height)
                {
                    Console.WriteLine("Inside sorting");
                    await animateSwap(j, j + 1);
                }
                    
            }
        }
        Console.WriteLine("End of sort reached");
        setIsRunning?.Invoke(false);
    }
}
