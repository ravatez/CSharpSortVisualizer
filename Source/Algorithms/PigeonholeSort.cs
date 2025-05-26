//using SortingVisualization;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Windows.Shapes;

//public class PigeonholeSort : ISortStrategy
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

//        // Find min and max based on rectangle heights
//        double min = rectangles.Min(r => r.Height);
//        double max = rectangles.Max(r => r.Height);
//        int range = (int)(max - min) + 1;

//        List<int>[] holes = new List<int>[range];
//        for (int i = 0; i < range; i++)
//            holes[i] = new List<int>();

//        // Put elements into holes
//        for (int i = 0; i < n; i++)
//        {
//            while (isPaused())
//                await Task.Delay(100);

//            if (!isRunning()) return;

//            int holeIndex = (int)(rectangles[i].Height - min);
//            holes[holeIndex].Add(i); // store index, not height

//            // Optional: highlight the current element being placed
//            await highlight(i, i);
//        }

//        int idx = 0;
//        // Collect elements back from holes in order
//        foreach (var hole in holes)
//        {
//            foreach (var rectIndex in hole)
//            {
//                while (isPaused())
//                    await Task.Delay(100);

//                if (!isRunning()) return;

//                if (idx != rectIndex)
//                {
//                    await animateSwap(idx, rectIndex);

//                    // Swap heights of rectangles[idx] and rectangles[rectIndex]
//                    double temp = rectangles[idx].Height;
//                    rectangles[idx].Height = rectangles[rectIndex].Height;
//                    rectangles[rectIndex].Height = temp;
//                }

//                idx++;
//            }
//        }
//        Console.WriteLine("End of sort reached");
//        setIsRunning?.Invoke(false);
//    }
//}