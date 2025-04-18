using System;
using Sort.Base;

class Program
{
    static void Main(string[] args)
    {
        Base bubbleSort = new BubbleSort();

        SortContextManager contextManager = new();
        contextManager.AddElements(new[] { 34, 7, 23, 32, 5, 62 });
        contextManager.AddContext(bubbleSort);
        contextManager.Sort();
        contextManager.Display();
    }
}