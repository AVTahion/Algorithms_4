using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  3. ***Требуется обойти конём шахматную доску размером N × M, пройдя через все поля доски по одному разу. 
        Здесь алгоритм решения такой же, как и в задаче о 8 ферзях. Разница только в проверке положения коня.

    Александр Кушмилов
*/

namespace Task_3
{
    class Program
    {
        /// <summary>
        /// Метод проверяет шахматную доску.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        static int CheckBoard(int[,] board)
        {
            int lastMove = board.Cast<int>().Max();
            if (lastMove == 0 || lastMove == 1) return 1;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == lastMove)
                    {
                        if (CheckHorse(board, i, j, lastMove) == 0) return 0;
                    }
                }
            }
            return 1;
        }

        /// <summary>
        /// Метод определяет может ли кон сделать ход в текущую клетку
        /// </summary>
        /// <param name="board">шахматное поле</param>
        /// <param name="x">абцисса проверяемого хода</param>
        /// <param name="y">ордината проверяемого хода</param>
        /// <param name="lastMove">№ проверяемого хода</param>
        /// <returns></returns>
        private static int CheckHorse(int[,] board, int x, int y, int lastMove)
        {
            int previousMove = lastMove - 1;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == previousMove)
                    {
                        if ((x == i + 2 || x == i - 2) && (y == j + 1 || y == j - 1)) return 1;
                        if ((x == i + 1 || x == i - 1) && (y == j + 2 || y == j - 2)) return 1;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// Метод очищает шахматную доску.
        /// </summary>
        /// <param name="board"></param>
        static void Zero(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = 0;
                }
            }
        }

        /// <summary>
        /// Метод выводит шахматную доску в консоль.
        /// </summary>
        /// <param name="board"></param>
        static void Print(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write($"{board[i,j],3}");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод рекурсивно ищет маршрут коня проходящий 1 раз по всем клеткам поля
        /// </summary>
        /// <param name="v">№ хода</param>
        /// <param name="board">шахматное поле</param>
        /// <returns></returns>
        static int SearchSolution(int v, int[,] board)
        {
            // Если проверка доски возвращает 0, то эта расстановка не подходит
            if (CheckBoard(board) == 0) return 0;
            // Если кол-во ходов == кол-ву клеток - решение найдено
            if (v == board.Length + 1) return 1;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 0)
                    {
                        board[i, j] = v;
                        if (SearchSolution(v + 1, board) == 1) return 1;
                        board[i, j] = 0;
                    }
                }
            }
            return 0;
        }

        static void Main(string[] args)
        {
            int[,] board = new int[5, 5];
            Zero(board);
            SearchSolution(1, board);
            Print(board);
            Console.ReadKey();
        }
    }
}
