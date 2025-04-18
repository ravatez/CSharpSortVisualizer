using System;
using Sort.Base;

class SortContextManager
{
    private int[] elements = Array.Empty<int>();
    private Base currentSortContext = null;
    public void AddContext(Base sortContext) =>  currentSortContext = sortContext;
    public void AddElements(int[] elements) => this.elements = elements;
    public void Sort() => currentSortContext.Sort(ref elements);
    public void Display()
    {
        if(elements.length > 0)
        {
          elements.ToList().ForEach(n=> Console.WriteLine(n));          
        }
    } 
}