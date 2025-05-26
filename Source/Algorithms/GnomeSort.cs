//using SortingVisualization;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System.Windows.Shapes;
//using System;

//public class GnomeSort : ISortStrategy
//{
//    public async Task Sort(
//        List<Rectangle> rectangles,
//        Func<int, int, Task> animateSwap,
//        Func<int, int, Task> highlight,
//        Func<bool> isPaused,
//        Func<bool> isRunning, Action<bool> setIsRunning)
//    {
//        int index = 0;
//        int n = rectangles.Count;

//        while (index < n)
//        {
//            while (isPaused())
//                await Task.Delay(100);

//            if (index == 0 || rectangles[index].Height >= rectangles[index - 1].Height)
//            {
//                index++;
//            }
//            else
//            {
//                await highlight(index, index - 1);
//                await animateSwap(index, index - 1);

//                // Swap the heights
//                double temp = rectangles[index].Height;
//                rectangles[index].Height = rectangles[index - 1].Height;
//                rectangles[index - 1].Height = temp;

//                index--;
//            }
//        }
//        Console.WriteLine("End of sort reached");
//        setIsRunning?.Invoke(false);
//    }
//}