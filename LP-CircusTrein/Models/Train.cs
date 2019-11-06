using LP_CircusTreinV4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LP_CircusTreinV4
{
    public class Train
    {
        private List<Wagon> _wagons;
        public IEnumerable<Wagon> Wagons 
        {
            get
            {
                return _wagons;
            }
        }

        public Train()
        {
            _wagons = new List<Wagon>();
        }

        public void CorrectlyPlaceAnimals(List<Animal> inputAnimals)
        {
            foreach (Animal animal in inputAnimals.OrderBy(a => a.Diet).ThenBy(a => a.Size).ToList())
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

            Wagon newWagon = new Wagon();
            _wagons.Add(newWagon);
            return newWagon;
        }
    }
}
