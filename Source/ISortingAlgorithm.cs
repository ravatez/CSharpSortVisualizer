using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace SortingVisualization
{
    //public abstract class Base
    //{
    //    public abstract void Sort(int[] elements);
    //    protected void Swap(int[] elements, int swapIndexA, int swapIndexB)
    //    {
    //        if (swapIndexA < 0 || swapIndexA >= elements.Length || swapIndexB < 0 || swapIndexB >= elements.Length)// Bounds checking
    //        {
    //            Console.WriteLine("Swap Index not in bounds");
    //            return;
    //        }

    //        int temp = elements[swapIndexA];
    //        elements[swapIndexA] = elements[swapIndexB];
    //        elements[swapIndexB] = temp;
    //    }
    //}

    public interface ISortStrategy
    {
        Task Sort(
            List<Rectangle> rectangles,
            Func<int, int, Task> animateSwap,
            Func<int, int, Task> highlight,
            Func<bool> isPaused,
            Func<bool> isRunning,
            Action<bool> setIsRunning); 
    }
}
