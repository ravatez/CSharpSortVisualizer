using System;
using Sort.Base;

class Program
{
    static void Main(string[] args)
    {
        Base bubbleSort = new BubbleSort();

        SortContextManager contextManager = new();

        var random = new Random();
        int[] shuffledArray = Enumerable.Range(1, 100).OrderBy(_ => random.Next()).ToArray();

        // Now add to your context
        contextManager.AddElements(shuffledArray);
        //contextManager.Display();
        contextManager.AddContext(bubbleSort);
        contextManager.Sort();
        contextManager.Display();
    }
}