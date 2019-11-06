using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LP_CircusTreinV4.Models
{
    public class Wagon
    {
        const int _maxCapacity = 10;
        private List<Animal> _seatedAnimals;

        private Animal biggestCarnivore = null;
        private Animal biggestHerbivore = null;

        public IEnumerable<Animal> SeatedAnimals 
        { 
            get 
            { 
                return _seatedAnimals; 
            } 
        }

        public Wagon()
        {
            _seatedAnimals = new List<Animal>();
        }

        public void PlaceAnimal(Animal animal)
        {
            if (this.CanBePlaced(animal))
            {
                _seatedAnimals.Add(animal);
                UpdateBiggestAnimals();
                animal.Placed = true; 
            }
        }

        public bool CanBePlaced(Animal potentialAnimal)
        {
            return IsSpaceAvailable(potentialAnimal) && InputAnimalWontBeEaten(potentialAnimal);
        }

        private bool InputAnimalWontBeEaten(Animal inputAnimal) 
        {
            if (inputAnimal.Diet == Diet.Herbivore)
            {
                return biggestCarnivore == null || (int)inputAnimal.Size > (int)biggestCarnivore.Size;
            }
            else 
            {
                return (biggestHerbivore == null || (int)inputAnimal.Size < (int)biggestHerbivore.Size)
                        && biggestCarnivore == null;
            }
        }

        private void UpdateBiggestAnimals()
        {
            foreach (Animal animal in _seatedAnimals)
            {
                CompareSizeFromInputAndBiggest(animal);                
            }
        }

        private void CompareSizeFromInputAndBiggest(Animal animal)
        {
            if (animal.Diet == Diet.Carnivore)
            {
                biggestCarnivore = animal;
            }
            else if(biggestHerbivore == null || (int)biggestHerbivore.Size < (int)animal.Size)
            { 
                biggestHerbivore = animal;
            }
        }

        private bool IsSpaceAvailable(Animal animal)
        {
            return CalculateSeatedSize() + (int)animal.Size <= _maxCapacity;
        }

        public int CalculateSeatedSize()
        {
            return _seatedAnimals.Sum(a => (int)a.Size);
        }

        public override string ToString()
        {
            return "Wagon: ";
        }

    }
}
