using System;
using System.ComponentModel;
using BuhuZoo.Models;

namespace BuhuZoo.Views
{
    class ZooKeeperView
    {
        public void Show(Object xyz)
        {
            Console.WriteLine("*** SHOW ZOO KEEPER ***");
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(xyz))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(xyz);
                Console.WriteLine($"{name}: {value}");
            }
        }

        public ZooKeeper AddZooKeeper()
        {
            ZooKeeper zooKeeper = new ZooKeeper();
            Console.WriteLine("ADD NEW ZOO KEEPER");
            Console.Write("Name: ");
            zooKeeper.Name = Tools.cr();
            Console.Write("Email: ");
            zooKeeper.Email = Tools.cr();

            foreach (var gender in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine((int)gender + " " + gender.ToString());
            }
            Console.Write("Gender: ");
            Gender g = new Gender();
            while (!Enum.TryParse(Tools.cr(), out g))
            { Console.WriteLine("Wrong input, please try again."); }
            zooKeeper.Gender = g;

            Console.Write("Date of Birth (dd-mm-yyyy): ");
            
            zooKeeper.DateOfBirth = Tools.String2Datetime(Tools.cr());
            return zooKeeper;
        }
    }
}
