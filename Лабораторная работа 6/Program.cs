using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Лабораторная_работа_6
{
    public class MyThread
    {
        private int N;
        public MyThread(int n)
        {
            this.N = n;
        }
        public void ThreadMain()
        {
            int[] mas = new int[N];
            Random rnd = new Random();
            List<int> result = new List<int>();
            for (int i=0; i<mas.Length; i++)
            {
                mas[i] = rnd.Next(1000);
                if (mas[i] % 6 == 0) result.Add(mas[i]);
                Console.Write(mas[i] + "   ");
            }
            if (result != null)
            {
                Console.WriteLine(" \n Полученное подмножество:");
                for (int i = 0; i < result.Count; i++)
                {
                    Console.Write(result[i] + "   ");
                }
            }
            else Console.WriteLine(" \n Элементов, кратных 6, нет");
        }
    }
    class Program
    {
        //public struct Data
        //{
        //    public string Message;
        //}

        //static void ThreadMainWithParameters(object o)
        //{
        //    Data d = (Data)o;
        //    Console.WriteLine("Выполняется в потоке, получено {0}", d.Message);
        //    Console.ReadKey();
        //}

        static void Main(string[] args)
        {
            //var d = new Data { Message = "Info" };
            //var t2 = new Thread(ThreadMainWithParameters);
            //t2.Start(d);
            var obj = new MyThread(5);
            var t3 = new Thread(obj.ThreadMain);
            t3.Start();

            Console.ReadKey();
        }
    }

  
}
