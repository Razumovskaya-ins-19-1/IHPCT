using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Лабораторная_работа_4
{

    // пользовательский
    //  Метод возвращает 
    //  количество нечетных элементов в матрице случайных чисел
    // Два параметра: размер матрицы
    // делегат



    class Program
    {
        public delegate int TakesAWhileDelegate (int a, int b);
        static void Main(string[] args)
        {
            TakesAWhileDelegate dl = Task;
            Console.WriteLine("Введите размер матрицы >");
            int  ma= Convert.ToInt32(Console.ReadLine());
            int mb = Convert.ToInt32(Console.ReadLine());
            dl.BeginInvoke(ma, mb, TaskIsCompleted, dl);
            for (int i = 0; i < 100; i++)
            {
                Console.Write(".");
                Thread.Sleep(50);
            }
            Console.ReadLine();

            //dl.BeginInvoke(1, 3000, ar=>
            //{
            //    int result = dl.EndInvoke(ar);
            //    Console.WriteLine("result {0}", result);
            //}, null);
            //for (int i=0; i<100; i++)
            //{
            //    Console.Write(".");
            //    Thread.Sleep(50);
            //}
        }

        static int Task (int a, int b)
        {
            int[,] matrix = new int[a, b];
            int k = 0;
            Random rnd = new Random();
            for(int i=0; i<a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    matrix[i, j] = rnd.Next(100);
                    Console.Write(matrix[i, j] + "   ");
                    if (matrix[i, j] % 2 != 0) k += 1;
                }
                Console.Write("\n");
            }
            return k;
        }
        static void TaskIsCompleted (IAsyncResult ar)
        {
            if (ar == null) throw new ArgumentNullException("ar");
                TakesAWhileDelegate dl = ar.AsyncState as TakesAWhileDelegate;
                Trace.Assert(dl != null, "Invalid object type");
                int result = dl.EndInvoke(ar);
                Console.WriteLine("result {0}", result);
            
        }

        //static void TakesAWhileCompleted (IAsyncResult ar)
        //{
        //    if (ar == null) throw new ArgumentNullException("ar");
        //    TakesAWhileDelegate dl = ar.AsyncState as TakesAWhileDelegate;
        //    Trace.Assert(dl != null, "Invalid object type");
        //    int result = dl.EndInvoke(ar);
        //    Console.WriteLine("result {0}", result);
        //    Console.ReadLine();
        //}

        //static int TakesAWhile (int data, int ms)
        //{
        //    Console.WriteLine("TakesAWhile запущен");
        //    Thread.Sleep(ms);
        //    Console.WriteLine("TakesAWhile завершен");
        //    return ++data;

        //}
    }
}
