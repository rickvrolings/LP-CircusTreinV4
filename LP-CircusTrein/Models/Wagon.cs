using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static LP_CircusTreinV4.Models.Enums;

namespace LP_CircusTreinV4.Models
{
    public class Wagon
    {
        static private int wagonCount = 0;
        private int wagonIndex;

        const int _maxCapacity = 10;
        private List<Animal> _seatedAnimals;

        private Animal biggestCarnivore = null;// needed for UpdateBiggestAnimals function
        private Animal biggestHerbivore = null;//

        public IEnumerable<Animal> SeatedAnimals  //Is dit een veilige manier om onder de public list vandaan te komen?
        { 
            get 
            { 
                return SeatedAnimalsToIEnumarable(); 
            } 
        }

        public Wagon()
        {
            wagonCount++;
            wagonIndex = wagonCount;
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
            return IsSpaceAvailable(potentialAnimal) && IsSafe(potentialAnimal);
        }

        private bool IsSafe(Animal inputAnimal) //it's not possible for two carnivores to be in the same wagon
        {
            if (inputAnimal.Diet == Diet.Herbivore)
            {
                return biggestCarnivore == null || (int)inputAnimal.Size > (int)biggestCarnivore.Size;
            }
            else //if(inputAnimal.Diet == Diet.Carnivore)
            {
                return (biggestHerbivore == null || (int)inputAnimal.Size < (int)biggestHerbivore.Size)
                        && biggestCarnivore == null;
            }
        //    else
        //    {
        //        return false;
        //    }
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
            else
            {
                if (biggestHerbivore == null || (int)biggestHerbivore.Size < (int)animal.Size)
                {
                    biggestHerbivore = animal;
                }
            }
        }

        private bool IsSpaceAvailable(Animal animal)
        {
            return CalculateSeatedSize() + (int)animal.Size <= _maxCapacity;
        }

        public int CalculateSeatedSize()
        {
            int cumulativeSize = 0;
            foreach (Animal animal in _seatedAnimals)
            {
                cumulativeSize += (int)animal.Size;
            }
            return cumulativeSize;
        }

        private IEnumerable<Animal> SeatedAnimalsToIEnumarable()
        {
            IEnumerable<Animal> animals = _seatedAnimals;
            return animals;
        }

        public override string ToString()
        {
            return "Wagon: " + wagonIndex.ToString();
        }

    }
}
