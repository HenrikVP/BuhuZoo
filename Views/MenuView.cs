using BuhuZoo.Controllers;
using BuhuZoo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuhuZoo.Views
{
    class MenuView
    {
        public void Menu()
        {
            Console.WriteLine(
    "\n*** MAIN MENU ***" +
    "1 Add Animal\n" +
    "2 Show All Animals\n" +
    "3 Search for Animal\n" +
    "4 Add ZooKeeper\n" +
    "5 Show All ZooKeepers\n" +
    "6 Search for ZooKeeper\n");
            string str = Console.ReadLine();

            switch (str)
            {
                case "1":
                    AddAnimal();
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    ZooKeeperView zkv = new ZooKeeperView();
                    zkv.Show(zkv.AddZooKeeper());
                    break;
                case "5":
                    break;
                case "6":
                    break;
                default:
                    break;
            }

        }

        private void AddAnimal()
        {
            AnimalView av = new AnimalView();
            Animal animal = av.AddAnimal();
            int? id = Sql.Insert(animal);
            if (id != null)
            {
                animal.Id = (int)id;
                av.ShowAnimal(animal);
            }
            else Console.WriteLine("Something went wrong!!!");
        }
    }
}
