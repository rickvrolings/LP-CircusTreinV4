using NUnit.Framework;
using LP_CircusTreinV4.Models;
using static LP_CircusTreinV4.Models.Enums;
using System.Collections;
using System.Collections.Generic;
using LP_CircusTreinV4;

namespace Tests
{
    public class TestTrain
    {
        List<Animal> animals = new List<Animal>();

        //TODO More tests? More data? Do i have to manually add data or is there a api or dataset somewhere?

        [SetUp]
        public void Setup()
        {
            animals.Clear();
            // Own reasoning concludes that optimal would be if these could be place in 5 wagons
            animals.Add(new Animal(Diet.Carnivore, Size.Small));
            animals.Add(new Animal(Diet.Carnivore, Size.Large));
            animals.Add(new Animal(Diet.Herbivore, Size.Medium));
            animals.Add(new Animal(Diet.Herbivore, Size.Medium));
            animals.Add(new Animal(Diet.Carnivore, Size.Medium));
            animals.Add(new Animal(Diet.Herbivore, Size.Medium));
            animals.Add(new Animal(Diet.Herbivore, Size.Large));
            animals.Add(new Animal(Diet.Herbivore, Size.Large));
            animals.Add(new Animal(Diet.Herbivore, Size.Large));
            animals.Add(new Animal(Diet.Carnivore, Size.Large));
            
        }

        [Test]
        public void PlaceAnimals()
        {
            Train train = new Train();
            train.CorrectlyPlaceAnimals(animals);
            int count = 0;
            foreach(Wagon w in train.Wagons)
            {
                count++;
            }
            Assert.AreEqual(5, count);
        }
    }
}