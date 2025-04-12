using System;
using System.Linq;

namespace Sort.Base
{
    public abstract class Base
    {
        protected int[] elements;
        public virtual void Sort(); 
        public bool IsEmpty() => elements.Length <= 0;

        protected void Swap(int swapIndexA,int swapIndexB)
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

        public void Display()
        {
            if(IsEmpty())
            {
                Console.WriteLine("Array is Empty");
                return;
            }

            elements.ToList().ForEach(n=> Console.WriteLine(n));
        }     
    }
}
