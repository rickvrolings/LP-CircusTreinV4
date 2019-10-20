using LP_CircusTreinV4;
using LP_CircusTreinV4.Models;
using NUnit.Framework;
using System.Collections.Generic;
using static LP_CircusTreinV4.Models.Enums;

namespace Tests
{
    public class TestTrain
    {
        [Test]
        public void SortAnimals()
        {
            //Arrange
            Train train = new Train();

            Animal animalOne = new Animal(Diet.Carnivore, Size.Small);
            Animal animalTwo = new Animal(Diet.Carnivore, Size.Large);
            Animal animalThree = new Animal(Diet.Herbivore, Size.Small);
            Animal animalFour = new Animal(Diet.Herbivore, Size.Large);

            List<Animal> unsortedAnimals = new List<Animal>()
            {
                animalFour, animalTwo, animalOne, animalThree
            };

            List<Animal> correctOrderCollectionAnimals = new List<Animal>()
            {
                animalOne, animalTwo, animalThree, animalFour
            };

            //Act
            List<Animal> sortedAnimals = train.SortAnimals(unsortedAnimals);

            //Assert
            Assert.AreEqual(correctOrderCollectionAnimals, sortedAnimals);
        }

        [Test]
        public void CorrectlyPlaceAnimals()
        {
            //Arrange
            Train manualTrain = new Train();

            List<Animal> animals = new List<Animal>()
            {
                new Animal(Diet.Carnivore, Size.Small),
                new Animal(Diet.Herbivore, Size.Medium),
                new Animal(Diet.Herbivore, Size.Medium),
                new Animal(Diet.Herbivore, Size.Medium),
                new Animal(Diet.Carnivore, Size.Large),
                new Animal(Diet.Herbivore, Size.Large),
                new Animal(Diet.Herbivore, Size.Large)
            };

            Wagon[] wagons =
            {
                new Wagon(),
                new Wagon(),
                new Wagon()
            };

            for (int i = 0; i <= 3; i++)
            {
                wagons[0].PlaceAnimal(animals[i]);
            }
            wagons[1].PlaceAnimal(animals[4]);

            for (int i = 5; i <= 6; i++)
            {
                wagons[2].PlaceAnimal(animals[i]);
            }

            foreach (Wagon wagon in wagons)
            {
                manualTrain.DirectlyAddWagon(wagon);
            }

            //Act
            Train functionalTrain = new Train();
            functionalTrain.CorrectlyPlaceAnimals(animals);

            //Assert

            Assert.Multiple(() =>
            {
                Assert.AreEqual(manualTrain.Wagons[0].SeatedAnimals, functionalTrain.Wagons[0].SeatedAnimals);
                Assert.AreEqual(manualTrain.Wagons[1].SeatedAnimals, functionalTrain.Wagons[1].SeatedAnimals);
                Assert.AreEqual(manualTrain.Wagons[2].SeatedAnimals, functionalTrain.Wagons[2].SeatedAnimals);
            });
        }
        
    }
}