using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Лабораторная_работа_6
{
    // Метод находит среднее арифметическое элементов 
    //матрицы случайных чисел
    //Два параметра: размер матрицы
    public class MyThread
    {
        private int a,b;
        public MyThread(int pa, int pb)
        {
            this.a = pa;
            this.b = pb;
        }
        public void ThreadMain()
        {
            int[,] matrix = new int[a,b];
            Random rnd = new Random();
            double mid=0;
            for (int i=0; i<a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    matrix[i, j] = rnd.Next(1000);
                    Console.Write(matrix[i,j] + "   ");
                    mid += Convert.ToDouble(matrix[i, j]);
                }
                Console.Write(" \n  ");
            }
               Console.Write("Среднее арифметическое: {0}", mid/matrix.Length);          
            
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
            var obj = new MyThread(5, 5);
            var t3 = new Thread(obj.ThreadMain);
            t3.Start();

            Console.ReadKey();
        }
    }

  
}
