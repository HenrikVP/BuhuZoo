using BuhuZoo.Controllers;
using BuhuZoo.Models;
using BuhuZoo.Views;
using System;
using System.Collections.Generic;

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
