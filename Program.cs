using BuhuZoo.Views;
using System;

namespace BuhuZoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Zoo-World!");
            while (true)
                new MenuView().Menu();
        }
    }
}