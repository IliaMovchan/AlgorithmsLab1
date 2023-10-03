using System;
namespace AlgorithmTest
{
	public class Generate
	{
		public Generate()
		{
            
		}

        //Згенерувати масив пар (ключі int - значення bool)
        public static KeyValuePair<int, bool>[] KeyValuePair(int min = 0, int max = 100)
        {
            int length = max - min + 1;
            int index = 0;

            KeyValuePair<int, bool>[] keyValuePairs = new KeyValuePair<int, bool>[length];

            for (int i = min; i <= max; i++)
            {
                keyValuePairs[index] = new KeyValuePair<int, bool>(i, true);
                index++;
            }

            return keyValuePairs;
        }

        //Згенерувати bool-масив
        public static bool[] BoolArray(int length)
        {
            bool[] boolArr = new bool[length];

            for (int i = 0; i < length; i++)
            {
                boolArr[i] = true;
            }

            return boolArr;
        }
        
        //Згенерувати масив випадкових чисел
        public static int[] IntArray(int length, int min = int.MinValue, int max = int.MaxValue)
        {
            Random random = new Random();

            int[] generatedArr = new int[length];

            for (int i = 0; i <= length - 1; i++)
            {
                generatedArr[i] = random.Next(min, max);
            }

            return generatedArr;
        }

        

    }
}

