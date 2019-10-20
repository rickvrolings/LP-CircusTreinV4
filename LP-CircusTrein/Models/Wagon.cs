using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static LP_CircusTreinV4.Models.Enums;

namespace LP_CircusTreinV4.Models
{
    public class Wagon
    {
        static private int _wagonCount = 0;
        private int _wagonIndex;

        const int maxCapicity = 10;
        public List<Animal> SeatedAnimals { get; private set; }

        public Wagon()
        {
            _wagonCount++;
            _wagonIndex = _wagonCount;
            this.SeatedAnimals = new List<Animal>();
        }

        public void PlaceAnimal(Animal animal)
        {
            if (this.CanBePlaced(animal))
            {
                SeatedAnimals.Add(animal);
            }
        }

        public bool CanBePlaced(Animal potentialAnimal)
        {
            return IsSpaceAvailable(potentialAnimal) && IsSafe(potentialAnimal);
        }

        private bool IsSafe(Animal potentialAnimal)
        {
            int carinvoreSize = 0;
            foreach(Animal animal in SeatedAnimals)
            {
                if(animal.Diet == Diet.Carnivore && (int)animal.Size > carinvoreSize)
                {
                    carinvoreSize = (int)animal.Size;
                }
            }
            return (int)potentialAnimal.Size > carinvoreSize;
        }

        private bool IsSpaceAvailable(Animal animal)
        {
            return CalSeatedSize() + (int)animal.Size <= maxCapicity;
        }

        private int CalSeatedSize()
        {
            int CumulativeSize = 0;
            foreach (Animal animal in SeatedAnimals)
            {
                CumulativeSize += (int)animal.Size;
            }
            return CumulativeSize;
        }

        public override string ToString()
        {
            return "Wagon: " + _wagonIndex.ToString();
        }

    }
}
