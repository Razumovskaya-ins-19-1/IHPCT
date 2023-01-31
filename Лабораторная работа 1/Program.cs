using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_1
{
    class Program
    {

        static void Main(string[] args)
        {

            Func<Action<bool>, float, float> func = Sum;
            Action<bool> action = Lot;
            Console.WriteLine(func(action, 1.2f));
            func = Subtraction;
            Console.WriteLine(func(action, 0.5f));
            Console.ReadLine();
        }

        public static void Lot(bool par) // Метод сообщения о состоянии счёта
        {
            {
                if (par)
                    Console.WriteLine("Ваш счёт был изменён ");
                else Console.WriteLine("Ваш счёт остался неизменным");
                Console.WriteLine("Внесённые изменения: ");
            };
        }

        public static float Sum (Action<bool> action, float f)    // Метод пополняющий счет с добавлением прорцентов
        {
            Random random = new Random();
            var rb = random.Next(2) == 1;          
            action(rb);
            float result = 0;
            if (rb)
            {
                result = 100000 * (0.01f * f);
                Console.WriteLine("Ваш счёт пополнен: ");
            }
            return result;
        }

        public static float Subtraction (Action<bool> action, float f)  // Метод списания средств с прорцентами
        {
            Random random = new Random();
            var rb = random.Next(2) == 1;
            action(rb);
            float result = 0;
            if (rb)
            {
                result = 1000 * (1.01f * f);
                Console.WriteLine("С вашего счёта списано: " );
            }
            return result;
        }
    }
}
