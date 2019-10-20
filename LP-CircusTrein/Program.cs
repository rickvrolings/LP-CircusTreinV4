using LP_CircusTreinV4.Models;
using System;
using System.Collections.Generic;
using static LP_CircusTreinV4.Models.Enums;

namespace LP_CircusTreinV4
{
    class Program
    {
        static void Main(string[] args)
        {
            Train train = new Train();
            train.CorrectlyPlaceAnimals(FillerDataOne());
            PrintWagonsFromTrain(train);

            Console.ReadKey();
        }
        
        static void PrintWagonsFromTrain(Train train)
        {
            PrintWagons(train.Wagons);
        }

        static void PrintWagons(List<Wagon> wagons)
        {
            foreach(Wagon wagon in wagons)
            {
                Console.WriteLine(wagon);
                PrintAnimals(wagon.SeatedAnimals);               
            }
        }
        static void PrintAnimals(List<Animal> animals)
        {
            foreach(Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
            Console.WriteLine(" ");
        }
        static List<Animal> FillerDataOne()
        {
            List<Animal> returnData = new List<Animal>()
            {
                new Animal(Diet.Herbivore, Size.Medium),
                new Animal(Diet.Herbivore, Size.Large),
                new Animal(Diet.Herbivore, Size.Large),
                new Animal(Diet.Carnivore, Size.Small),
                new Animal(Diet.Herbivore, Size.Medium),
                new Animal(Diet.Herbivore, Size.Medium),
                new Animal(Diet.Carnivore, Size.Large)
            };
            return returnData;
        }

        static List<Animal> FillerDataTwo()
        {
            return new List<Animal>()
            {
                new Animal(Diet.Herbivore, Size.Small),
                new Animal(Diet.Herbivore, Size.Large),
                new Animal(Diet.Carnivore, Size.Small),
                new Animal(Diet.Carnivore, Size.Large)
            };
        }
    }
}
 