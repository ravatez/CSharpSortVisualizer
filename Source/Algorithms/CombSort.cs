//using SortingVisualization;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System.Windows.Shapes;
//using System;

//public class CombSort : ISortStrategy
//{
//    public async Task Sort(
//        List<Rectangle> rectangles,
//        Func<int, int, Task> animateSwap,
//        Func<int, int, Task> highlight,
//        Func<bool> isPaused,
//        Func<bool> isRunning, Action<bool> setIsRunning)
//    {
//        int n = rectangles.Count;
//        int gap = n;
//        bool swapped = true;

//        while (gap != 1 || swapped)
//        {
//            while (isPaused())
//                await Task.Delay(100);

//            gap = GetNextGap(gap);
//            swapped = false;

//            for (int i = 0; i < n - gap; i++)
//            {
//                if (!isRunning()) return;

//                await highlight(i, i + gap);

//                if (rectangles[i].Height > rectangles[i + gap].Height)
//                {
//                    await animateSwap(i, i + gap);

//                    // Swap heights
//                    double temp = rectangles[i].Height;
//                    rectangles[i].Height = rectangles[i + gap].Height;
//                    rectangles[i + gap].Height = temp;

//                    swapped = true;
//                }
//            }
//        }
//        Console.WriteLine("End of sort reached");
//        setIsRunning?.Invoke(false);
//    }

//    private int GetNextGap(int gap)
//    {
//        gap = (gap * 10) / 13;
//        return (gap < 1) ? 1 : gap;
//    }
//}