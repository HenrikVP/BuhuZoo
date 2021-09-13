using BuhuZoo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BuhuZoo.Views
{
    class AnimalView
    {
        public void ShowAllAnimals(List<Animal> animalList)
        {
            Console.WriteLine("\n*** SHOW ALL ANIMALS ***");
            foreach (var animal in animalList)
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(animal))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(animal);
                    Console.WriteLine($"{name}: {value}");
                }
            }
        }

        public void ShowAnimal(Animal animal)
        {
            Console.WriteLine("\n*** SHOW ANIMAL ***");
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(animal))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(animal);
                Console.WriteLine($"{name}: {value}");
            }
        }

        public Animal AddAnimal()
        {
            Animal animal = new Animal();
            Console.WriteLine("\n*** ADD NEW ANIMAL ***");
            Console.Write("Name: ");
            animal.Name = Tools.cr();
            Console.Write("Race: ");
            animal.Race = Tools.cr();

            GetColor(animal);
            GetGender(animal);

            bool isDateOk = false;
            do
            {
                try
                {
                    Console.Write("Date of Birth (dd-mm-yyyy): ");
                    animal.DateOfBirth = Tools.String2Datetime(Tools.cr());
                    isDateOk = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: " + e.GetType() + " " + e.Message);
                }
            } while (!isDateOk);


            return animal;
        }

        private void GetGender(Animal animal)
        {
            foreach (var gender in Enum.GetValues(typeof(Gender)))
            { Console.WriteLine((int)gender + " " + gender.ToString()); }
            Console.Write("Gender: ");
            Gender g = new Gender();
            while (!Enum.TryParse(Tools.cr(), out g))
            { Console.WriteLine("Wrong input, please try again."); }
            animal.Gender = g;
        }

        private void GetColor(Animal animal)
        {
            foreach (var color in Enum.GetValues(typeof(Color)))
            { Console.WriteLine((int)color + " " + color.ToString()); }
            Console.Write("Color: ");
            Color c = new Color();
            while (!Enum.TryParse(Tools.cr(), out c))
            { Console.WriteLine("Wrong input, please try again."); }
            animal.Color = c;
        }
    }
}
