using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  1. *Количество маршрутов с препятствиями. Реализовать чтение массива с препятствием и нахождение количество маршрутов.
        Карта для примера:
            1 1 1
            0 1 0
            0 1 0
    2. Решить задачу о нахождении длины максимальной подпоследовательности с помощью матрицы.
    3. ***Требуется обойти конём шахматную доску размером N × M, пройдя через все поля доски по одному разу. 
        Здесь алгоритм решения такой же, как и в задаче о 8 ферзях. Разница только в проверке положения коня.

    Александр Кушмилов
*/


namespace Algorithms_4
{
    class Program
    {
        /// <summary>
        /// Метод выводит массив[,] в консоль
        /// </summary>
        /// <param name="arr"></param>
        static void Print(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int k = 0; k < arr.GetLength(1); k++)
                {
                    Console.Write($"{ arr[i, k],4}");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод заполняет массив кол-вом маршрутов(при возможном движении вниз и вправо)
        /// </summary>
        /// <param name="arr">Массив с кол-вом маршрутов</param>
        static void NumberOfRoutes(ref int[,] arr)
        {
            for (int k = 0; k < arr.GetLength(1); k++)
            {
                arr[0, k] = 1;
            }
            for (int i = 1; i < arr.GetLength(0); i++)
            {
                arr[i, 0] = 1;
                for (int j = 1; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = arr[i, j - 1] + arr[i - 1, j];
                }
            }
            Print(arr);
        }

        /// <summary>
        /// Метод заполняет массив кол-вом маршрутов с учетом препятствий(при возможном движении вниз и вправо)
        /// </summary>
        /// <param name="arr">Массив с кол-вом маршрутов</param>
        /// <param name="arrObstacles">Массив с препятствиями (0 - препятствие, 1 - свободный маршрут)</param>
        static void NORWithObstacles(ref int[,] arr, int[,] arrObstacles)
        {
            for (int k = 0; k < arr.GetLength(1); k++)
            {
                arr[0, k] = arrObstacles[0, k] == 1 ? 1 : 0;
            }
            for (int i = 1; i < arr.GetLength(0); i++)
            {
                arr[i, 0] = arrObstacles[i, 0] == 1 ? 1 : 0;
                for (int j = 1; j < arr.GetLength(1); j++)
                {
                    if (arrObstacles[i, j] == 1)
                        arr[i, j] = arr[i, j - 1] + arr[i - 1, j];
                    else
                        arr[i, j] = 0;
                }
            }
            Print(arr);
        }

        static void Main(string[] args)
        {
            int[,] routes = new int[5, 5];
            NumberOfRoutes(ref routes);
            Console.WriteLine();
            int[,] obstacles = new int[,] { { 1, 1, 1, 0, 1 }, {1, 1, 1, 1, 1 }, {1, 1, 1, 1, 1 }, {1, 0, 1, 0, 1 }, {1, 0, 1, 0, 1} };
            Print(obstacles);
            Console.WriteLine();
            NORWithObstacles(ref routes, obstacles);
            Console.ReadKey();
        }
    }
}
