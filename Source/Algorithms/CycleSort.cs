//using SortingVisualization;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System.Windows.Shapes;
//using System;

//public class CycleSort : ISortStrategy
//{
//    public async Task Sort(
//        List<Rectangle> rectangles,
//        Func<int, int, Task> animateSwap,
//        Func<int, int, Task> highlight,
//        Func<bool> isPaused,
//        Func<bool> isRunning, Action<bool> setIsRunning)
//    {
//        int n = rectangles.Count;
//        if (n == 0) return;

//        for (int cycleStart = 0; cycleStart <= n - 2; cycleStart++)
//        {
//            while (isPaused())
//                await Task.Delay(100);
//            if (!isRunning()) return;

//            double itemHeight = rectangles[cycleStart].Height;
//            int pos = cycleStart;

//            // Find position where item should go
//            for (int i = cycleStart + 1; i < n; i++)
//            {
//                if (rectangles[i].Height < itemHeight)
//                    pos++;
//            }

//            if (pos == cycleStart)
//                continue;

//            // Skip duplicates
//            while (pos < n && rectangles[pos].Height == itemHeight)
//                pos++;

//            if (pos != cycleStart)
//            {
//                await animateSwap(cycleStart, pos);
//                SwapHeights(rectangles, cycleStart, pos);
//                itemHeight = rectangles[pos].Height;
//            }

//            while (pos != cycleStart)
//            {
//                pos = cycleStart;
//                for (int i = cycleStart + 1; i < n; i++)
//                {
//                    if (rectangles[i].Height < itemHeight)
//                        pos++;
//                }

//                while (pos < n && rectangles[pos].Height == itemHeight)
//                    pos++;

//                if (itemHeight != rectangles[pos].Height)
//                {
//                    await animateSwap(cycleStart, pos);
//                    SwapHeights(rectangles, cycleStart, pos);
//                    itemHeight = rectangles[pos].Height;
//                }
//            }
//        }
//        Console.WriteLine("End of sort reached");
//        setIsRunning?.Invoke(false);
//    }

//    private void SwapHeights(List<Rectangle> rectangles, int i, int j)
//    {
//        double temp = rectangles[i].Height;
//        rectangles[i].Height = rectangles[j].Height;
//        rectangles[j].Height = temp;
//    }
//}