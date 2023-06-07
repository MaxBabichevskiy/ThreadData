using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер массива данных: ");
            int size = int.Parse(Console.ReadLine());

            int[] data = new int[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                data[i] = random.Next(100);
            }

            Thread[] threads = new Thread[size];

            object lockObject = new object();

            int sum = 0;

            for (int i = 0; i < size; i++)
            {
                int index = i; 

                threads[i] = new Thread(() =>
                {
                    int processedValue = data[index] * 2;

                    lock (lockObject)
                    {
                        sum += processedValue;
                    }
                });

                threads[i].Start();
            }

            for (int i = 0; i < size; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine("Обработка массива данных завершена.");
            Console.WriteLine("Сумма всех обработанных элементов: " + sum);

            Console.ReadLine();
        }
    }

