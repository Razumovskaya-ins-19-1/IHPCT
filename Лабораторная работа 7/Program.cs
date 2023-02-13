using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Лабораторная_работа_7
{

    // Метод находит количество вхождений заданного 
    //элемента в матрице вещественных чисел
    //Класс описывает 
    //случайную матрицу и
   // искомое число
    class MassItem
    {
        public double Chislo;
        public double [,] matrix;
        public int count;
    }
    class MassData
    {
        private List<MassItem> massive;
        public MassData()
        {
            massive = new List<MassItem>(10);
        }
        public void Add(MassItem newElement)
        {
            massive.Add(newElement);
            ThreadPool.QueueUserWorkItem(MethodForThread, newElement);
        }
        protected static void MethodForThread(object ob)
        {
            MassItem item = (MassItem)ob;
            double ch = item.Chislo;
            Console.WriteLine("Поток {0}. Получен  элемент {1}",
                Thread.CurrentThread.ManagedThreadId, item.Chislo);
            int kol = 0; // количество вхождений
            Random rnd = new Random();
            Random r = new Random();
            double [,] matr = new double[r.Next(100), r.Next(100)];
            item.matrix = matr;
            for (int i=0; i<item.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < item.matrix.GetLength(1); j++)
                {
                    item.matrix[i, j] = Math.Round((rnd.NextDouble()*100), 2);
                    if (item.matrix[i, j] == ch) kol += 1;
                }
                Thread.Sleep(1000);
                Console.WriteLine("Поток {0}. Вычисление! Количество вхождений элемента {1} в матрицу равно {2}",
                 Thread.CurrentThread.ManagedThreadId, item.Chislo, item.count);
            }
            item.count = kol;
            Console.WriteLine("Поток {0}. Вычисление завершено! Количество вхождений элемента {1} в матрицу равно {2}",
                 Thread.CurrentThread.ManagedThreadId, item.Chislo, item.count);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int MaxWorkThread;
            int MaxIOThread;
            ThreadPool.GetMaxThreads(out MaxWorkThread, out MaxIOThread);
            Console.WriteLine("Максимальное количество рабочих потоков: {0}. " +
                "Максимальное количество потоков ввода-вывода {1}",
                MaxWorkThread, MaxIOThread);
            MassData myData = new MassData();
            Random rnd = new Random();
            for (int i=0; i<10; i++)
            {
                myData.Add(new MassItem() {Chislo = Math.Round((rnd.NextDouble()*100), 2)});
            }
            Console.ReadKey();
        }
    }
}
