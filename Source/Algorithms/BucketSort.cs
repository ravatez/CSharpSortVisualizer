//using SortingVisualization;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Windows.Shapes;

//public class BucketSort : ISortStrategy
//{
//    public async Task Sort(
//        List<Rectangle> rectangles,
//        Func<int, int, Task> animateSwap,
//        Func<int, int, Task> highlight,
//        Func<bool> isPaused,
//        Func<bool> isRunning, Action<bool> setIsRunning)
//    {
//        if (rectangles == null || rectangles.Count == 0)
//            return;

//        double max = rectangles.Max(r => r.Height);
//        int bucketCount = 10;
//        List<List<int>> buckets = new List<List<int>>(bucketCount);
//        for (int i = 0; i < bucketCount; i++)
//            buckets.Add(new List<int>());

//        // Fill buckets
//        for (int i = 0; i < rectangles.Count; i++)
//        {
//            int bucketIndex = (int)(rectangles[i].Height * bucketCount / (max + 1));
//            buckets[bucketIndex].Add(i); // Store the index instead of value
//        }

//        List<int> sortedIndices = new List<int>();

//        // Sort each bucket using Bubble Sort-like animation
//        foreach (var bucket in buckets)
//        {
//            for (int i = 0; i < bucket.Count - 1; i++)
//            {
//                for (int j = 0; j < bucket.Count - i - 1; j++)
//                {
//                    while (isPaused()) await Task.Delay(100);
//                    await highlight(bucket[j], bucket[j + 1]);

//                    if (rectangles[bucket[j]].Height > rectangles[bucket[j + 1]].Height)
//                    {
//                        await animateSwap(bucket[j], bucket[j + 1]);

//                        // Swap index references to keep bucket in logical sync
//                        (bucket[j], bucket[j + 1]) = (bucket[j + 1], bucket[j]);
//                    }
//                }
//            }
//            //sortedIndices.AddRange(bucket); // Append sorted bucket
//        }
//        Console.WriteLine("End of sort reached");
//        setIsRunning?.Invoke(false);
//        // Optionally: rearrange rectangles list based on sortedIndices if logical order matters
//        // But usually your animateSwap updates the list, so this may not be needed
//    }
//}