using System;
using System.Diagnostics;

namespace AlgorithmTest
{
    public class EratosthenesSieve
    {
        public EratosthenesSieve()
        {
            random = new Random();
        }

        public static KeyValuePair<int, bool>[] FirstSieveMethod(KeyValuePair<int, bool>[] originalKvpArray)
        {
            KeyValuePair<int, bool>[] resultKvpArray = originalKvpArray.ToArray();

            for (int i = 0; i < resultKvpArray.Length; i++)
            {
                if (resultKvpArray[i].Key == 2 || resultKvpArray[i].Key == 3) resultKvpArray[i] = new KeyValuePair<int, bool>(originalKvpArray[i].Key, true);
                else if (resultKvpArray[i].Key < 2) resultKvpArray[i] = new KeyValuePair<int, bool>(originalKvpArray[i].Key, false);
                else if (resultKvpArray[i].Key % 2 == 0 || resultKvpArray[i].Key % 3 == 0 || resultKvpArray[i].Key % 5 == 0)
                {
                    resultKvpArray[i] = new KeyValuePair<int, bool>(originalKvpArray[i].Key, false);
                }
            }

            return resultKvpArray;
        }


        public static TimeSpan MeasureExecutionTime(MethodToMeasure method, KeyValuePair<int, bool>[] originalKvpArray)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            method(originalKvpArray);

            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        public delegate KeyValuePair<int, bool>[] MethodToMeasure(KeyValuePair<int, bool>[] originalKvpArray);

        //public bool[] Execute(bool[] arr)
        //{
        //    bool[] resultArr = arr.ToArray();

        //    resultArr[0] = false;
        //    resultArr[1] = false;


        //    for (int i = 0; i < resultArr.Length; i++)
        //    {
        //        if (i % 2 == 0 || i % 3 == 0 || i % 5 == 0) resultArr[i] = false;
        //    }

        //    return resultArr;
        //}

        Random random;
    }
}

