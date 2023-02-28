using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Лабораторная_работа_9
{
    class Program
    {
        // 3 задачи:
        // расчет суммы нечетных элементов, делящихся на 7;
        // поиск максимума среди элементов, делящихся на 2;
        // вывод матрицы в консоль.

        static void Main(string[] args)
        {
            int N = 10;
            int[,] matrix = new int[N, N];
            Task tBase = new Task(
                () =>
                {
                    Console.WriteLine("Основная задача - вывод матрицы. Начало");
                   
                    Random rnd = new Random();
                    for (int i=0; i<N; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            matrix[i,j] = rnd.Next(10000);
                            Console.Write(matrix[i, j] + "   ");
                        }
                        Console.WriteLine("\n");
                    }
                    Thread.Sleep(3000);
                    Console.WriteLine("Основная задача. Оканчание");
                });
            Task tContine1 = tBase.ContinueWith(
                base_task =>
                {
                    Console.WriteLine("Задача продолжения - расчет суммы нечетных элементов, делящихся на 7. Начало.");
                    int res1=0;
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            if (((i*10+j) % 2 != 0) && (matrix[i, j] % 7 == 0))
                                res1 += matrix[i, j];
                        }
                    }
                    Thread.Sleep(3000);
                    Console.WriteLine("Расчет суммы нечетных элементов, делящихся на 7 = {0}.", res1);
                    Console.WriteLine("Задача продолжения. Окончание.");
                });
            Task tContine2 = tBase.ContinueWith(
               base_task =>
               {
                   Console.WriteLine("Задача продолжения - поиск максимума среди элементов, делящихся на 2. Начало.");
                   int max = matrix[0, 0];
                   for (int i = 0; i < N; i++)
                   {
                       for (int j = 0; j < N; j++)
                       {
                           if (matrix[i, j] % 2 == 0)
                                max = matrix[i, j];
                       }
                   }
                   Thread.Sleep(3000);
                   Console.WriteLine("Расчет поиск максимума среди элементов, делящихся на 2 = {0}.", max);
                   Console.WriteLine("Задача продолжения. Окончание.");
               });
            tBase.Start();
            Console.ReadKey();
        }
    }
}
