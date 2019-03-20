using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeapSort_OP
{
    class MyDataArray : DataArray
    {

        double[] data;

        public MyDataArray(int n, int seed)
        {
            data = new double[n];
            length = n;
            Random rand = new Random(seed);

            for (int i = 0; i < length; i++)
            {
                data[i] = rand.NextDouble();
            }

        }

        public override double this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }

    }
}
