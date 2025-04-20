using System;
using Sort.Base;

class Program
{
    static void Main(string[] args)
    {
        int MIN_RANGE = 1;
        int MAX_RANGE = 50;
        int ARRAY_LENGTH = 10;
        Base bubbleSort = new BubbleSort();
        SortContextManager contextManager = new();

        // Now add to your context
        contextManager.AddElements(Utils.GetArrayWithRandomNumbers(MIN_RANGE,MAX_RANGE,ARRAY_LENGTH));
        //contextManager.Display();
        contextManager.AddContext(bubbleSort);
        contextManager.Sort();
        contextManager.Display();
    }
}