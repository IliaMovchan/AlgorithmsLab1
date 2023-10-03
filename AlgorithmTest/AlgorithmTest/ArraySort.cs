using System;
using System.Diagnostics;

namespace AlgorithmTest
{
	public class ArraySort
	{
		public ArraySort()
		{

		}

		public static int[] BubbleSort(int[] originalArr)
		{
            int[] arr = originalArr.ToArray();

			for (int j = 0; j < arr.Length - 1; j++)
			{
				bool swapped = false;
				for (int i = 0; i < arr.Length - j - 1; i++)
				{
					if (arr[i] > arr[i + 1])
					{
						int tmp = arr[i];
						arr[i] = arr[i + 1];
						arr[i + 1] = tmp;
						swapped = true;
					}
				}
                if (!swapped) return arr;
            }

			return arr;
		}

		public static int[] InsertSort(int[] originalArr)
		{
            int[] arr = originalArr.ToArray();

			for (int j = 0; j < arr.Length; j++)
			{
                int minIndex = j;

                for (int i = j; i < arr.Length; i++)
                {
                    if (arr[minIndex] > arr[i])
                    {
                        minIndex = i;
                    }
                }

                int tmp = arr[j];
                arr[j] = arr[minIndex];
                arr[minIndex] = tmp;
            }

            return arr;
        }

        public static long MeasureExecutionTime(SortingMethod method, int[] arr)
        {
            var watch = Stopwatch.StartNew();

            method(arr);

            watch.Stop();
            return watch.ElapsedTicks;
        }

        public delegate int[] SortingMethod(int[] arr);
    }
}

