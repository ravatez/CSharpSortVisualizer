using SortingVisualization;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Shapes;
public class CountingSort : ISortStrategy
{
    public async Task Sort(
        List<Rectangle> rectangles,
        Func<int, int, Task> animateSwap,
        Func<int, int, Task> highlight,
        Func<bool> isPaused,
        Func<bool> isRunning, Action<bool> setIsRunning)
    {
        int n = rectangles.Count;
        int max = rectangles.Max(r => (int)r.Height);
        int min = rectangles.Min(r => (int)r.Height);
        int range = max - min + 1;

        int[] count = new int[range];
        Rectangle[] output = new Rectangle[n];

        // Counting occurrences
        foreach (var rect in rectangles)
        {
            while (isPaused()) await Task.Delay(100);
            count[(int)rect.Height - min]++;
        }

        // Cumulative counts
        for (int i = 1; i < count.Length; i++)
        {
            while (isPaused()) await Task.Delay(100);
            count[i] += count[i - 1];
        }

        // Build output array (stable)
        for (int i = n - 1; i >= 0; i--)
        {
            while (isPaused()) await Task.Delay(100);

            int height = (int)rectangles[i].Height;
            int pos = count[height - min] - 1;

            await highlight(i, pos);

            // Place rectangle at output[pos]
            output[pos] = new Rectangle
            {
                Height = rectangles[i].Height,
                Width = rectangles[i].Width,
                Fill = rectangles[i].Fill,
                Stroke = rectangles[i].Stroke,
                StrokeThickness = rectangles[i].StrokeThickness
            };

            count[height - min]--;
            await Task.Delay(50);
        }

        // Copy back to original list with animation
        for (int i = 0; i < n; i++)
        {
            while (isPaused()) await Task.Delay(100);

            rectangles[i].Height = output[i].Height;
            await animateSwap(i, i); // Swap with self to animate the update
            await Task.Delay(30);
        }
        Console.WriteLine("End of sort reached");
        setIsRunning?.Invoke(false);
    }
}