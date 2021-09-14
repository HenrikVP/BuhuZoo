using System;
using System.Collections.Generic;
using System.ComponentModel;
using BuhuZoo.Models;

namespace BuhuZoo.Views
{
    class ZooKeeperView
    {
        public void Show(Object zooKeeper)
        {
            Console.WriteLine("*** SHOW ZOO KEEPER ***");
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(zooKeeper))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(zooKeeper);
                Console.WriteLine($"{name}: {value}");
            }
        }

        public void Show(List<ZooKeeper> objectList)
        {
            Console.WriteLine("*** SHOW ALL ZOO KEEPERS ***");
            foreach (var zooKeeper in objectList)
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(zooKeeper))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(zooKeeper);
                    Console.WriteLine($"{name}: {value}");
                }
                new AnimalView().ShowAllAnimals(zooKeeper.AnimalList);
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
