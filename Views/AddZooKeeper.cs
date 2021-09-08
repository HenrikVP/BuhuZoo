using System;
using BuhuZoo.Models;

namespace BuhuZoo.Views
{
    class AddZooKeeper
    {
        public ZooKeeper GetInput()
        {
            ZooKeeper zooKeeper= new ZooKeeper();
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
            Enum.TryParse(Tools.cr(), out g);
            zooKeeper.Gender = g;

            return zooKeeper;
        }




    }
}
