using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Лабораторная_работа_4
{

    // лямбдавыражение
    // Метод возвращает 
    // логическое значение, указывающее существует ли заданный символ в строке
    // Два параметра: строка и искомый символ
    // делегат

    class Program
    {
        public delegate bool TakesAWhileDelegate (string stroka, char simbol);
        static void Main(string[] args)
        {
           TakesAWhileDelegate dl = (st, ch) =>
            {
                Thread.Sleep(500);
                return st.Contains(ch);
            };
            Console.WriteLine("Введите строку >");
            string nstr = Console.ReadLine();
            Console.WriteLine("Введите символ >");
            char nsim = Convert.ToChar(Console.ReadLine());
            dl.BeginInvoke(nstr, nsim, TaskIsCompleted, dl);
            for (int i = 0; i < 100; i++)
            {
                Console.Write(".");
                Thread.Sleep(50);
            }

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

        static void TaskIsCompleted (IAsyncResult ar)
        {
            if (ar == null) throw new ArgumentNullException("ar");
                TakesAWhileDelegate dl = ar.AsyncState as TakesAWhileDelegate;
                Trace.Assert(dl != null, "Invalid object type");
                bool result = dl.EndInvoke(ar);
                Console.WriteLine("result {0}", result);
                Console.ReadLine();
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
