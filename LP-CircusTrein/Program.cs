using LP_CircusTreinV4.Models;
using System;
using System.Collections.Generic;
using static LP_CircusTreinV4.Models.Enums;

namespace LP_CircusTreinV4
{
    class Program
    {
        static List<Animal> que;
        static void Main(string[] args)
        {
            que = FillerData();
            Train train = new Train();
            PrintAnimals(train.SortAnimals(que));
            Console.WriteLine(" ");
            train.CorrectlyPlaceAnimals(que);
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
                Console.WriteLine(" ");
            }
        }
        static void PrintAnimals(List<Animal> animals)
        {
            foreach(Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
        static List<Animal> FillerData()
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
    }
}
 