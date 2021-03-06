using BuhuZoo.Controllers;
using BuhuZoo.Models;
using System;
using System.Collections.Generic;

namespace BuhuZoo.Views
{
    class MenuView
    {
        public void Menu()
        {
            Console.WriteLine(
    "\n*** MAIN MENU ***\n" +
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
                    ShowAllAnimals(); 
                    break;
                case "3":
                    break;
                case "4":
                    AddZooKeeper();
                    break;
                case "5":

                    var list = new ZooKeeperCRUD(Tools.ConnectionString).Select();
                    new ZooKeeperView().Show(list);
                    break;
                case "6":
                    break;
                default:
                    break;
            }

        }

        private static void AddZooKeeper()
        {
            ZooKeeperView zkv = new ZooKeeperView();
            ZooKeeper zooKeeper = zkv.AddZooKeeper();
            int? id = new ZooKeeperCRUD(Tools.ConnectionString).Insert(zooKeeper);
            if (id != null)
            {
                zooKeeper.Id = (int)id;
                zkv.Show(zooKeeper);
            }
            else Console.WriteLine("Something went wrong!!!");
        }

        private void ShowAllAnimals()
        {
            AnimalCRUD sql = new AnimalCRUD();
            List<Animal> animalList = sql.Select();
            AnimalView av = new AnimalView();
            av.ShowAllAnimals(animalList);
            //eller...
            //new AnimalView().ShowAllAnimals(new Sql().Select());
        }

        private void AddAnimal()
        {
            AnimalView av = new AnimalView();
            Animal animal = av.AddAnimal();
            int? id = AnimalCRUD.Insert(animal);
            if (id != null)
            {
                animal.Id = (int)id;
                av.ShowAnimal(animal);
            }
            else Console.WriteLine("Something went wrong!!!");
        }
    }
}
