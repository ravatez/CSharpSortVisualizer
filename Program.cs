using System;
using Sort.Base;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 34, 7, 23, 32, 5, 62 };
        Base bubbleSort = new BubbleSort();
        bubbleSort.AddElements(array);
        bubbleSort.Sort();
        bubbleSort.Display();
    }
}