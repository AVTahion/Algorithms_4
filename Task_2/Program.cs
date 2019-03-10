using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  2. Решить задачу о нахождении длины максимальной подпоследовательности с помощью матрицы.
    3. ***Требуется обойти конём шахматную доску размером N × M, пройдя через все поля доски по одному разу. 
        Здесь алгоритм решения такой же, как и в задаче о 8 ферзях. Разница только в проверке положения коня.

    Александр Кушмилов
*/

namespace Task_2
{
    class Program
    {
        /// <summary>
        /// Метод находит максимальную длинну подпоследовательности с помощью матрицы
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        static int[,] LCS(char[] A, char[] B)
        {
            int[,] arrLCS = new int [A.Length + 1, B.Length + 1];
            for (int k = 0; k < arrLCS.GetLength(1); k++)
            {
                arrLCS[0, k] = 0;
            }
            for (int i = 1; i < arrLCS.GetLength(0); i++)
            {
                arrLCS[i, 0] = 0;

                for (int j = 1; j < arrLCS.GetLength(1); j++)
                {
                    if (i < 2 && j < 2)
                    {
                        arrLCS[i, j] = (A[i - 1] == B[j - 1]) ? Math.Max(arrLCS[i - 1, j], arrLCS[i, j - 1]) + 1 : Math.Max(arrLCS[i - 1, j], arrLCS[i, j - 1]);
                    }
                    else
                    {
                        arrLCS[i, j] = ((A[i - 1] == B[j - 1]) && (A[i - 2] == B[j - 2])) || ((A[i - 1] == B[j - 1]) && (A[i - 1] != A[i - 2]) && (B[j - 1] != B[j - 2]))? Math.Max(arrLCS[i - 1, j], arrLCS[i, j - 1]) + 1 : Math.Max(arrLCS[i - 1, j], arrLCS[i, j - 1]);
                    }
                }
            }


            return arrLCS;
        }

        /// <summary>
        /// Метод выводит в консоль последовательности и массив наибольшей длинны подпоследовательностей
        /// </summary>
        /// <param name="arr">Массив LCS</param>
        /// <param name="A">Последовательность A</param>
        /// <param name="B">Последовательность B</param>
        static void Print(int[,] arr, char[] A, char[] B)
        {
            Console.Write("        ");
            for (int i = 0; i < arr.GetLength(1) - 1; i++)
            {
                Console.Write($"{B[i], 4}");
            }
            Console.WriteLine();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (i == 0) Console.Write("    ");
                if (i > 0) Console.Write($"{A[i-1], 4}");
                for (int k = 0; k < arr.GetLength(1); k++)
                {
                    Console.Write($"{ arr[i, k],4}");
                }
                Console.WriteLine();
            }
        }


        static void Main(string[] args)
        {
            char[] a = new char[] { 'g', 'e', 'e', 'k', 'b', 'r', 'a', 'i', 'n', 's' };
            char[] b = new char[] { 'g', 'e', 'e', 'k', 'm', 'i', 'n', 'd', 's' };
            int[,] lcs = LCS(a, b);
            Print(lcs, a, b);
            Console.ReadKey();
        }
    }
}
