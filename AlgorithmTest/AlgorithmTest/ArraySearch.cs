using System;
using System.Diagnostics;

namespace AlgorithmTest
{
	public class ArraySearch
	{
		public ArraySearch()
		{
            random = new Random();
		}

        //Метод для виводу рез-тату
        public void Info(int[] simpleArr, int needle)
        {
            int[] sortedArr = simpleArr.ToArray();
            Array.Sort(sortedArr);

            //Вывод заданого массива
            Console.WriteLine("Generated array: ");
            foreach (int element in simpleArr) Console.WriteLine(element);
            Console.WriteLine('\n');


            //Вывод результата простого поиска в 2 типах массивов
            Console.WriteLine("SIMPLE SEARCH");
            Console.WriteLine("Simple array:" + SimpleSearch(simpleArr, needle));
            Console.WriteLine("Time: " + MeasureSearchExecutionTime(SimpleSearch, simpleArr, needle));

            Console.WriteLine("Sorted array:" + SimpleSearch(sortedArr, needle));
            Console.WriteLine("Time: " + MeasureSearchExecutionTime(SimpleSearch, sortedArr, needle));
            Console.WriteLine('\n');

            //Вывод результата бинарного поиска в 2 типах массивов
            Console.WriteLine("BINARY SEARCH");
            Console.WriteLine("Simple array:" + BinarySearch(simpleArr, needle));
            Console.WriteLine("Time: " + MeasureSearchExecutionTime(BinarySearch, simpleArr, needle));

            Console.WriteLine("Sorted array:" + BinarySearch(sortedArr, needle));
            Console.WriteLine("Time: " + MeasureSearchExecutionTime(BinarySearch, sortedArr, needle));
        }

        public static bool SimpleSearch(int[] stack, int needle, int start = 0, int end = -1)
        {
            if (end == -1) end = stack.Length - 1;

            for (int i = start; i <= end; i++)
            {
                if (stack[i] == needle) return true;
            }
            return false;
        }

        public static bool BinarySearch(int[] stack, int needle, int start = 0, int end = -1)
        {
            if (end == -1) end = stack.Length - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (stack[mid] == needle) return true;
                else if (stack[mid] < needle) start = mid + 1;
                else if (stack[mid] > needle) end = mid - 1;
            }

            return false;
        }

        // Метод для заміру часу виконання сортування
        public static long MeasureSearchExecutionTime(MethodToMeasure method, int[] stack, int needle, int start = 0, int end = -1)
        {
            var watch = Stopwatch.StartNew();

            method(stack, needle, start, end);

            watch.Stop();

            return watch.ElapsedTicks;
        }

        public delegate bool MethodToMeasure(int[] stack, int needle, int start, int end);

        Random random;
    }
}

