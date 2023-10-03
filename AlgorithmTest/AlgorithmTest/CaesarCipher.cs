
using System;
using System.Diagnostics;
using System.Text;
using static AlgorithmTest.Program;

namespace AlgorithmTest
{
	public class CaesarCipher
	{

        // Метод для виводу рез-тату
        public void Info(string message, int shift)
        {
            Console.WriteLine(message + '\n');

            Console.WriteLine("1st encryption method: " + MeasureExecutionTime(FirstEncryptionMethod, message, shift));
            Console.WriteLine(FirstEncryptionMethod(message, shift) + '\n');

            Console.WriteLine("2nd encryption method: " + MeasureExecutionTime(SecondEncryptionMethod, message, shift));
            Console.WriteLine(SecondEncryptionMethod(message, shift) + '\n');

            Console.WriteLine("2nd encryption method: " + MeasureExecutionTime(Decrypt, message, shift));
            Console.WriteLine(Decrypt(message, shift) + '\n');
        }


        // 1 Метод кодування
        public static string FirstEncryptionMethod(string message, int shift)
        {
            string result = "";

            foreach (char sym in message)
            {
                if (char.IsLetter(sym))
                {
                    char shiftedSym = (char)(sym + shift);

                    if ((char.IsLower(sym) && shiftedSym > 'z') || (char.IsUpper(sym) && shiftedSym > 'Z'))
                    {
                        shiftedSym = (char)(sym - (26 - shift));
                    }

                    result += shiftedSym;
                }
                else
                {
                    result += sym;
                }
            }

            return result;
        }


        // 2 Метод кодування
        public string SecondEncryptionMethod(string message, int shift)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in message)
            {
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsLower(c) ? 'a' : 'A';
                    int offset = c - baseChar;
                    int shiftedOffset = (offset + shift) % 26;
                    char shiftedChar = (char)(baseChar + shiftedOffset);
                    result.Append(shiftedChar);
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }



        // Розкодувати шифр Цезаря
        public string Decrypt(string message, int shift)
        {
            return SecondEncryptionMethod(message, -shift);
        }

        // Метод для заміру часу виконання 
        public long MeasureExecutionTime(MethodToMeasure method, string arg1, int arg2)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            method(arg1, arg2);

            stopwatch.Stop();
            return stopwatch.ElapsedTicks;
        }

        public delegate string MethodToMeasure(string arg1, int arg2);
    }
}

