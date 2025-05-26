using SortingVisualization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Shapes;
public class TimSort : ISortStrategy
{
    private const int RUN = 32;

    public async Task Sort(
        List<Rectangle> rectangles,
        Func<int, int, Task> animateSwap,
        Func<int, int, Task> highlight,
        Func<bool> isPaused,
        Func<bool> isRunning, Action<bool> setIsRunning)
    {
        int n = rectangles.Count;

        // Step 1: Sort small runs using Insertion Sort
        for (int i = 0; i < n; i += RUN)
            await InsertionSort(rectangles, i, Math.Min(i + RUN - 1, n - 1), animateSwap, highlight, isPaused);

        // Step 2: Merge runs
        for (int size = RUN; size < n; size *= 2)
        {
            for (int left = 0; left < n; left += 2 * size)
            {
                int mid = left + size - 1;
                int right = Math.Min(left + 2 * size - 1, n - 1);

                if (mid < right)
                    await Merge(rectangles, left, mid, right, animateSwap, highlight, isPaused);
            }
        }
        Console.WriteLine("End of sort reached");
        setIsRunning?.Invoke(false);
    }

    private async Task InsertionSort(
        List<Rectangle> rects, int left, int right,
        Func<int, int, Task> animateSwap, Func<int, int, Task> highlight, Func<bool> isPaused)
    {
        for (int i = left + 1; i <= right; i++)
        {
            int j = i;
            while (j > left && rects[j - 1].Height > rects[j].Height)
            {
                while (isPaused())
                    await Task.Delay(100);

                await highlight(j - 1, j);
                await animateSwap(j - 1, j);
                j--;
            }
        }
    }

    private async Task Merge(
        List<Rectangle> rects, int l, int m, int r,
        Func<int, int, Task> animateSwap, Func<int, int, Task> highlight, Func<bool> isPaused)
    {
        var left = new List<Rectangle>();
        var right = new List<Rectangle>();

        for (int i = l; i <= m; i++) left.Add(rects[i]);
        for (int i = m + 1; i <= r; i++) right.Add(rects[i]);

        int i1 = 0, i2 = 0, k = l;

        while (i1 < left.Count && i2 < right.Count)
        {
            while (isPaused())
                await Task.Delay(100);

            await highlight(k, k);

            if (left[i1].Height <= right[i2].Height)
            {
                rects[k].Height = left[i1++].Height;
            }
            else
            {
                rects[k].Height = right[i2++].Height;
            }

            k++;
            await Task.Delay(50);
        }

        while (i1 < left.Count)
        {
            rects[k++].Height = left[i1++].Height;
            await Task.Delay(30);
        }

        while (i2 < right.Count)
        {
            rects[k++].Height = right[i2++].Height;
            await Task.Delay(30);
        }
    }
}