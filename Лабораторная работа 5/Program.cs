using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Лабораторная_работа_5
{
    class Program
    {
        // Метод преобразования матрицы случайных чисел: нечетные 
        //элементы заменяются суммой тангенса и котангенса
    //соответствующего элемента матрицы.
        static void Main(string[] args)
        {
            Action method = Parity;
            Thread[] tmas = new Thread[5];
            for (int i=0; i<tmas.Length; i++)
            {
                tmas[i] = new Thread(Parity);
                tmas[i].Start();
                Thread.Sleep(100);
            }
            Console.ReadKey();
        }

        static void Parity()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("Поток {0}. Создание матрицы...", threadId);
            int N = 5;
            double[,] mas = new double[N, N];
            Console.WriteLine("Поток {0}. Инициализация элементов матрицы...", threadId);
            Random rnd = new Random(threadId);
            for(int i=0; i<N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    mas[i,j] = rnd.Next(1000);
                }
            }
            Console.WriteLine("Поток {0}. Преобразование нечётных элементов...", threadId);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (mas[i, j] % 2 != 0)
                        mas[i, j] = Math.Tan((mas[i, j]))+ (1/Math.Tan((mas[i, j])));
                }
            }
            Console.WriteLine("Поток {0} Новая матрица: \n", threadId);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(mas[i, j] + "   ");
                }
                Console.Write(" \n  ");
            }
        }

    }
}
