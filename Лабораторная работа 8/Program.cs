using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_8
{
    class Program
    {
        // Метод расчета модуля случайного вектора.
        static void Main(string[] args)
        {
            // Первый вариант запуска задачи
            Task t1 = new Task(ParallelTask);
            t1.Start();
            // Второй вариант запуска задачи
            TaskFactory tf = new TaskFactory();
            Task t2 = tf.StartNew(ParallelTask);
            // Третий вариант запуска задачи
            Task t3 = Task.Factory.StartNew(ParallelTask);
            Console.ReadKey();
        }

        public static void ParallelTask()
        {
            Console.WriteLine("Выполнение задачи {0}", Task.CurrentId);
            Random rnd = new Random();
            double a=0, b=0, c=0, result=0;
            a = Math.Round(rnd.NextDouble() * Math.Pow((-1), rnd.Next(1, 3)),2);
            b = Math.Round(rnd.NextDouble() * Math.Pow((-1), rnd.Next(1, 3)),2);
            c = Math.Round(rnd.NextDouble() * Math.Pow((-1), rnd.Next(1, 3)),2);
            result = Math.Round(Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2) + Math.Pow(c, 2)),2);
            Console.WriteLine("Модуль вектора {0}; {1}; {2} равен {3}", a, b, c, result);
        }
    }
}
