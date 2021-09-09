using BuhuZoo.Models;
using System;
using System.ComponentModel;

namespace BuhuZoo.Views
{
    class AnimalView
    {
        public void ShowAnimal(Animal animal)
        {
            Console.WriteLine("*** SHOW ANIMAL ***");
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
            Console.WriteLine("*** ADD NEW ANIMAL ***");
            Console.Write("Name: ");
            animal.Name = Tools.cr();
            Console.Write("Race: ");
            animal.Race = Tools.cr();

            GetColor(animal);
            GetGender(animal);

            Console.Write("Date of Birth (dd-mm-yyyy): ");
            animal.DateOfBirth = Tools.String2Datetime(Tools.cr());
            return animal;
        }

        private static void GetGender(Animal animal)
        {
            foreach (var gender in Enum.GetValues(typeof(Gender)))
            { Console.WriteLine((int)gender + " " + gender.ToString()); }
            Console.Write("Gender: ");
            Gender g = new Gender();
            while (!Enum.TryParse(Tools.cr(), out g))
            { Console.WriteLine("Wrong input, please try again."); }
            animal.Gender = g;
        }

        private static void GetColor(Animal animal)
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
