using System;
using System.Linq;

namespace Sort.Base
{
    public abstract class Base
    {
        public abstract void Sort(int[] elements);
        protected void Swap(int[] elements,int swapIndexA,int swapIndexB)
        {
            if(swapIndexA <0 || swapIndexA >= elements.Length || swapIndexB <0 || swapIndexB >= elements.Length)// Bounds checking
            {
                Console.WriteLine("Swap Index not in bounds");
                return;
            }

            int temp = elements[swapIndexA];
            elements[swapIndexA] = elements[swapIndexB];
            elements[swapIndexB] = temp;
        }  
    }
}
