using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Лабораторная_работа_2
{
    //  лямбда-выражение 
    // Метод возвращает подмножество 
    // элементов массива случайных чисел,
    // которые являются четными
    // Один параметр: 
    //размер исходного массива
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, List<int>> lambda = n =>
            {
                Random rnd = new Random();
                int[] ch = new int[n];
                List<int> res = new List<int>();
                for (int i = 0; i < n; i++)
                {
                    ch[i] = rnd.Next(1, 1000);
                    Console.Write(ch[i] + "  ");
                    if (ch[i] % 2 == 0)
                        res.Add(ch[i]);
                }
                Thread.Sleep(3000);
                return res;
            };
            Console.WriteLine("Введите количество элементов массива >");
            int N = Convert.ToInt32(Console.ReadLine());
            IAsyncResult ar = lambda.BeginInvoke(N, null, null);
            while (true)
            {
                Console.WriteLine("\n Загрузка!!! Подождите!!!");
                if (ar.AsyncWaitHandle.WaitOne(500, false))
                {
                            Console.WriteLine("Можно извлеч сейчас ");
                            break;
                }
                }
                List<int> list = lambda.EndInvoke(ar);
            Console.WriteLine("\n");
            if (list.Count != 0)
                for (int i = 0; i < list.Count; i++)
                {
                    Console.Write(list[i] + "  ");
                }
            else Console.Write("Чётных элементов нет");
            Console.ReadLine();
        }
    }
}
