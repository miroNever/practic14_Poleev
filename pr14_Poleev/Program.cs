using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr14_Poleev
{
    class Program
    {
        static int CheckNum()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int res))
                {
                    if (res <= 1)
                        Console.WriteLine("Введи число больше 1");
                    else
                        return res;
                }
                else
                    Console.WriteLine("Вы ввели не число");
            }
        }
        static void Zadanie1()
        {
            Stack<int> number = new Stack<int>();
            Console.Write
                ("Введите число n: ");
            int n = CheckNum();
            for (int i = 1; i <= n; i++)
            {
                number.Push(i);
            }
            Console.WriteLine($"Размерность стека: {number.Count}");
            Console.WriteLine($"Верхний элемент стека: {number.Peek()}");
            Console.Write("Содержимое стека: ");
            while (true)
            {
                Console.Write($"{number.Pop()} ");
                if (number.Count == 0)
                    break;
            }
            Console.WriteLine($"\nНовая размерность стека = {number.Count}");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Zadanie1();
        }
    }
}
