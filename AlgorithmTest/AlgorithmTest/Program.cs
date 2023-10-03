using System;
using System.Diagnostics;

namespace AlgorithmTest
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arr = Generate.IntArray(10000, 0, 100);

            //int[] arr = { 5, 3, -8, 15, 3, -12, 5, 0 };

            //foreach (int element in finishedArr) Console.WriteLine(element);

            Console.WriteLine("Insert sort: " + ArraySort.MeasureExecutionTime(ArraySort.InsertSort, arr));

            Console.WriteLine("Bubble sort: " + ArraySort.MeasureExecutionTime(ArraySort.BubbleSort, arr));

        }
    }
}
