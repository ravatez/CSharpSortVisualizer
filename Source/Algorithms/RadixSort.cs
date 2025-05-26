using SortingVisualization;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Shapes;

public class RadixSort : ISortStrategy
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

        for (int exp = 1; max / exp > 0; exp *= 10)
        {
            await CountSort(rectangles, exp, animateSwap, highlight, isPaused);
        }
        Console.WriteLine("End of sort reached");
        setIsRunning?.Invoke(false);
    }

    private async Task CountSort(
        List<Rectangle> rectangles,
        int exp,
        Func<int, int, Task> animateSwap,
        Func<int, int, Task> highlight,
        Func<bool> isPaused)
    {
        int n = rectangles.Count;
        Rectangle[] output = new Rectangle[n];
        int[] count = new int[10];

        // Count frequencies
        for (int i = 0; i < n; i++)
        {
            while (isPaused()) await Task.Delay(100);
            int digit = ((int)rectangles[i].Height / exp) % 10;
            count[digit]++;
        }

        // Cumulative count
        for (int i = 1; i < 10; i++)
        {
            while (isPaused()) await Task.Delay(100);
            count[i] += count[i - 1];
        }

        // Build output array (stable sort)
        for (int i = n - 1; i >= 0; i--)
        {
            while (isPaused()) await Task.Delay(100);

            int digit = ((int)rectangles[i].Height / exp) % 10;
            int pos = count[digit] - 1;

            await highlight(i, pos);

            output[pos] = new Rectangle
            {
                Height = rectangles[i].Height,
                Width = rectangles[i].Width,
                Fill = rectangles[i].Fill,
                Stroke = rectangles[i].Stroke,
                StrokeThickness = rectangles[i].StrokeThickness
            };

            count[digit]--;
            await Task.Delay(50);
        }

        // Copy back to rectangles list with animation
        for (int i = 0; i < n; i++)
        {
            while (isPaused()) await Task.Delay(100);

            rectangles[i].Height = output[i].Height;
            await animateSwap(i, i); // Animate update
            await Task.Delay(30);
        }
    }
}