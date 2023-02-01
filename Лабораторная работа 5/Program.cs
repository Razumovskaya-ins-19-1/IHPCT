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
        static void Main(string[] args)
        {
            Action method = Parity;
            Thread[] tmas = new Thread[5];
            for (int i=0; i<tmas.Length; i++)
            {
                tmas[i] = new Thread(Parity);
                tmas[i].Start();
            }
            Console.ReadKey();
        }

        static void Parity()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("Поток {0}. Создание массива...", threadId);
            int N = 30;
            int[] mas = new int[N];
            Console.WriteLine("Поток {0}. Инициализация элементов массива...", threadId);
            Random rnd = new Random(threadId);
            for(int i=0; i<mas.Length; i++)
            {
                mas[i] = rnd.Next(1000);
            }
            Console.WriteLine("Поток {0}. Подсчёт чётных и нечётных элементов...", threadId);
            int p = 0, n = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] % 2 == 0) p += 1;
                else n += 1;
            }
            Console.WriteLine("Поток {0}. Чётных элементов элемент = {1}    Нечётных элементов = {2}", threadId, p, n);
        }

    }
}
