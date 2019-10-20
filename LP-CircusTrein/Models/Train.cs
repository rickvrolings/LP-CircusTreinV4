using LP_CircusTreinV4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static LP_CircusTreinV4.Models.Enums;

namespace LP_CircusTreinV4
{
    public class Train
    {
        public List<Wagon> Wagons { get; private set; }

        public Train()
        {
            Wagons = new List<Wagon>();
        }

        public void CorrectlyPlaceAnimals(List<Animal> inputAnimals)
        {
            List<Animal> sortedAnimals = SortAnimals(inputAnimals);
            PlaceInWagons(sortedAnimals);
        }

        public List<Animal> SortAnimals(List<Animal> animals)
        {
            return animals = animals.OrderBy(a => a.Diet).ThenBy(a => a.Size).ToList();
        }

        public void PlaceInWagons(List<Animal> receivedAnimals)
        {
            foreach(Animal animal in receivedAnimals)
            {
                Wagon availableWagon = GetAvailableWagon(animal);
                availableWagon.PlaceAnimal(animal);
            }
        }

        public Wagon GetAvailableWagon(Animal potentialAnimal)
        {
            foreach (Wagon wagon in Wagons) 
            {
                if (wagon.CanBePlaced(potentialAnimal) && potentialAnimal.Diet != Diet.Carnivore)
                {
                    return wagon;
                }
            }
            return CreateNewWagonAndAddToList();
        }

        public Wagon CreateNewWagonAndAddToList()
        {
            Wagon newWagon = new Wagon();
            Wagons.Add(newWagon);
            return newWagon;
        }

        //Functions used for unit testing

        public void DirectlyAddWagon(Wagon wagon)
        {
            Wagons.Add(wagon);
        }

    }
}
