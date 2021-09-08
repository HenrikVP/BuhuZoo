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

            ZooKeeper zooKeeper = new ZooKeeper();

            AddZooKeeper azk = new AddZooKeeper();
            azk.GetInput();

            //If we use a list as a property we have to instantiate a new list
            //for each instance of ZooKeeper
            //List<Animal> list = new List<Animal>();
            //zooKeeper.AnimalListProperty = list;
            //zooKeeper.AnimalListProperty.Add(new Animal());

            //If we instantiate a new list in the zookeeper model, we will have
            //a ready list when zookeeper is instantiated.
            zooKeeper.AnimalList.Add(new Animal());
        }
    }
}
