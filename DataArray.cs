using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeapSort_OP
{
    abstract class DataArray
    {

        protected int length;
        public int Length { get { return length; } }
        public abstract double this[int index] { get; set; }

        public void Print(int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(" {0:F5} ", this[i]);

            Console.WriteLine();
        }

    }
}
