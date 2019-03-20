using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;

namespace HeapSort_OP
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = 10;
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;

            MyDataArray myArray = new MyDataArray(n, seed);
            Console.WriteLine("\n ARRAY \n");
            myArray.Print(n);
            HeapSort(myArray);
            myArray.Print(n);

            MyDataList myList = new MyDataList(n, seed);
            Console.WriteLine("\n LIST \n");
            myList.Print(n);
            HeapSort(myList);
            myList.Print(n);

            //SpeedTest();
        }

        //private static void SpeedTest()
        //{
        //    Stopwatch stopWatch = new Stopwatch();

        //    MyDataArray myArray;
        //    MyDataList myList;

        //    int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;

        //    int[] numbers = { 1000, 2000, 4000, 8000, 16000, 32000, 64000 };

        //    Console.WriteLine("MEMORY ARRAY MERGE SORT");
        //    Console.WriteLine("|---------------------------|");
        //    Console.WriteLine("|  N          |  Run time   |");
        //    Console.WriteLine("|---------------------------|");
        //    foreach (int number in numbers)
        //    {
        //        //speed test for array
        //        myArray = new MyDataArray(number, seed);
        //        stopWatch.Start();
        //        HeapSort(myArray);
        //        stopWatch.Stop();

        //        Console.WriteLine("|  {0,-9}  |  {1,2}:{2,2}:{3,3}  |", number,
        //            stopWatch.Elapsed.Minutes, stopWatch.Elapsed.Seconds, stopWatch.Elapsed.Milliseconds);

        //        //reseting stop watch
        //        stopWatch.Reset();
        //    }
        //    Console.WriteLine("|---------------------------|\n");

        //    Console.WriteLine("MEMORY LIST MERGE SORT");
        //    Console.WriteLine("|---------------------------|");
        //    Console.WriteLine("|  N          |  Run time   |");
        //    Console.WriteLine("|---------------------------|");
        //    foreach (int number in numbers)
        //    {
        //        //speed test for list
        //        myList = new MyDataList(number, seed);
        //        stopWatch.Start();
        //        HeapSort(myList);
        //        stopWatch.Stop();

        //        Console.WriteLine("|  {0,-9}  |  {1,2}:{2,2}:{3,3}  |", number,
        //            stopWatch.Elapsed.Minutes, stopWatch.Elapsed.Seconds, stopWatch.Elapsed.Milliseconds);

        //        //reseting stop watch
        //        stopWatch.Reset();
        //    }
        //    Console.WriteLine("|---------------------------|");
        //}

        public static void HeapSort(DataArray items)
        {

            int n = items.Length;

            // Build heap (rearrange array) 
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(items, n, i);

            // One by one extract an element from heap 
            for (int i = n - 1; i >= 0; i--)
            {
                // Move current root to end 
                double temp = items[0];
                items[0] = items[i];
                items[i] = temp;

                // call max heapify on the reduced heap 
                heapify(items, i, 0);
            }

        }

        // To heapify a subtree rooted with node i which is 
        // an index in arr[]. n is size of heap 
        static void heapify(DataArray items, int n, int i)
        {
            int largest = i; // Initialize largest as root 
            int l = 2 * i + 1; // left = 2*i + 1 
            int r = 2 * i + 2; // right = 2*i + 2 

            // If left child is larger than root 
            if (l < n && items[l] > items[largest])
                largest = l;

            // If right child is larger than largest so far 
            if (r < n && items[r] > items[largest])
                largest = r;

            // If largest is not root 
            if (largest != i)
            {
                double temp = items[i];
                items[i] = items[largest];
                items[largest] = temp;

                // Recursively heapify the affected sub-tree 
                heapify(items, n, largest);
            }

        }

        public static void HeapSort(DataList items)
        {
            int n = items.Length;

            // Build heap (rearrange array) 
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(items, n, i);

            // One by one extract an element from heap 
            for (int i = n - 1; i > 0; i--)
            {
                // Move current root to end 
                items.Swap(0, i);

                // call max heapify on the reduced heap 
                heapify(items, i, 0);
            }

        }

        // To heapify a subtree rooted with node i which is 
        // an index in arr[]. n is size of heap 
        static void heapify(DataList items, int n, int i)
        {
            int largest = i; // Initialize largest as root 
            int l = 2 * i + 1; // left = 2*i + 1 
            int r = 2 * i + 2; // right = 2*i + 2 

            // If left child is larger than root 
            if (l < n && items.Value(l) > items.Value(largest))
                largest = l;

            // If right child is larger than largest so far 
            if (r < n && items.Value(r) > items.Value(largest))
                largest = r;

            // If largest is not root 
            if (largest != i)
            {
                items.Swap(i, largest);

                // Recursively heapify the affected sub-tree 
                heapify(items, n, largest);
            }

        } 

    }
}
