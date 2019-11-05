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
        private List<Wagon> _wagons;
        public IEnumerable<Wagon> Wagons //Is dit een veilige manier om onder de public list vandaan te komen?
        {
            get
            {
                return WagonsToIEnumerable();
            }
        }
        public Train()
        {
            _wagons = new List<Wagon>();
        }

        public void CorrectlyPlaceAnimals(List<Animal> inputAnimals)
        {
            List<Animal> sortedAnimals = SortAnimals(inputAnimals);//Kan ik er niet van uitgaan dat Carnivore altijd gesorteerd zijn
            PlaceInWagons(sortedAnimals);
        }

        private List<Animal> SortAnimals(List<Animal> animals)
        {
            return animals = animals.OrderBy(a => a.Diet).ThenBy(a => a.Size).ToList();
        }

        private void PlaceInWagons(List<Animal> receivedAnimals)
        {
            foreach(Animal animal in receivedAnimals)
            {
                GetAvailableWagon(animal).PlaceAnimal(animal);
            }
        }

        private Wagon GetAvailableWagon(Animal potentialAnimal)
        {
            foreach (Wagon wagon in _wagons) 
            {
                if (wagon.CanBePlaced(potentialAnimal))
                {
                    return wagon;
                }
            }
            return CreateNewWagonAndAddToList();
        }

        private IEnumerable<Wagon> WagonsToIEnumerable()
        {
            IEnumerable<Wagon> wagons = _wagons;
            return wagons;
        }

        private Wagon CreateNewWagonAndAddToList()
        {
            Wagon newWagon = new Wagon();
            _wagons.Add(newWagon);
            return newWagon;
        }
    }
}
