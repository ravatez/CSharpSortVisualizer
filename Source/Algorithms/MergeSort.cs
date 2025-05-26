using SortingVisualization;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System;

public class MergeSort : ISortStrategy
{
    public async Task Sort(
        List<Rectangle> rectangles,
        Func<int, int, Task> animateSwap,
        Func<int, int, Task> highlight,
        Func<bool> isPaused,
        Func<bool> isRunning,
        Action<bool> setIsRunning)
    {
        await MergeSortRecursive(rectangles, 0, rectangles.Count - 1, animateSwap, highlight, isPaused, isRunning);

        Console.WriteLine("End of sort reached");
        setIsRunning?.Invoke(false);
    }

    private async Task MergeSortRecursive(
        List<Rectangle> arr,
        int left,
        int right,
        Func<int, int, Task> animateSwap,
        Func<int, int, Task> highlight,
        Func<bool> isPaused,
        Func<bool> isRunning)
    {
        if (left < right)
        {
            int middle = left + (right - left) / 2;
            await MergeSortRecursive(arr, left, middle, animateSwap, highlight, isPaused, isRunning);
            await MergeSortRecursive(arr, middle + 1, right, animateSwap, highlight, isPaused, isRunning);
            await Merge(arr, left, middle, right, animateSwap, highlight, isPaused, isRunning);
        }
    }

    private async Task Merge(
        List<Rectangle> arr,
        int left,
        int middle,
        int right,
        Func<int, int, Task> animateSwap,
        Func<int, int, Task> highlight,
        Func<bool> isPaused,
        Func<bool> isRunning)
    {
        List<Rectangle> temp = new List<Rectangle>();
        int i = left;
        int j = middle + 1;

        while (i <= middle && j <= right)
        {
            while (isPaused())
                await Task.Delay(100);

            await highlight(i, j);

            if (arr[i].Height <= arr[j].Height)
            {
                temp.Add(arr[i++]);
            }
            else
            {
                temp.Add(arr[j++]);
            }

            await Task.Delay(100);
        }

        while (i <= middle)
        {
            while (isPaused())
                await Task.Delay(100);

            temp.Add(arr[i++]);
        }

        while (j <= right)
        {
            while (isPaused())
                await Task.Delay(100);

            temp.Add(arr[j++]);
        }

        for (int k = 0; k < temp.Count; k++)
        {
            Rectangle source = temp[k];
            Rectangle target = arr[left + k];

            if (source != target)
            {
                int originalIndex = arr.IndexOf(source);
                int targetIndex = left + k;

                await animateSwap(originalIndex, targetIndex);
            }
        }
    }
}