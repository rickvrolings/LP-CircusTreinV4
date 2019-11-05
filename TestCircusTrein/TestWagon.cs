using NUnit.Framework;
using LP_CircusTreinV4.Models;
using static LP_CircusTreinV4.Models.Enums;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Tests
{
    public class TestWagon
    {
        Animal[][] animalMatrix = 
        {
            new Animal[] //animalMatrix[0]
            { 
                new Animal(Diet.Carnivore, Size.Small), //animal 0
                new Animal(Diet.Carnivore, Size.Medium), //animal 1
                new Animal(Diet.Carnivore, Size.Large), //animal 2
                new Animal(Diet.Herbivore, Size.Small), //animal 3
                new Animal(Diet.Herbivore, Size.Medium),//animal 4
                new Animal(Diet.Herbivore, Size.Large) //animal 5
            },
            new Animal[] //animalMatrix[1]: Crossreference array
            {
                new Animal(Diet.Carnivore, Size.Small),
                new Animal(Diet.Carnivore, Size.Medium),
                new Animal(Diet.Carnivore, Size.Large),
                new Animal(Diet.Herbivore, Size.Small),
                new Animal(Diet.Herbivore, Size.Medium),
                new Animal(Diet.Herbivore, Size.Large)
            }
        };

        bool[][] expectedBoolMatrix = //animal[x] vs Crossreference animals excpected results 
        {
            new bool[] //expectedBoolMatrix[0] animal 0 vs Crossreference 
            {
                false,  false, false, false, true, true 
            },
            new bool[] //expectedBoolMatrix[1] animal 1 vs Crossreference 
            {
                false,  false, false, false, false, true
            },
            new bool[] //expectedBoolMatrix[2] animal 2 vs Crossreference 
            {
                false,  false, false, false, false, false
            },
            new bool[] //expectedBoolMatrix[3] animal 3 vs Crossreference 
            {
                false,  false, false, true, true, true
            },
            new bool[] //expectedBoolMatrix[4] animal 4 vs Crossreference 
            {
                true,  false, false, true, true, true
            },
            new bool[] //expectedBoolMatrix[5] animal 5 vs Crossreference 
            {
                true,  true, false, true, true, true
            },

        };


        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CrossRefering()
        { 
            Assert.Multiple(() =>
            {
                for(int x = 0; x < animalMatrix[0].Length; x++)
                {
                    Wagon wagon = new Wagon();
                    wagon.PlaceAnimal(animalMatrix[0][x]);

                    for(int y = 0; y < animalMatrix[1].Length; y++)
                    {
                        Assert.AreEqual(expectedBoolMatrix[x][y], wagon.CanBePlaced(animalMatrix[1][y]));
                    }
                }
            });
        }

        [Test]
        public void PlaceAnimals()
        {
            //Arrange
            Wagon wagon = new Wagon();
            List<Animal> animals = new List<Animal>()
            {
                new Animal(Diet.Carnivore, Size.Small),
                new Animal(Diet.Herbivore, Size.Medium),
                new Animal(Diet.Herbivore, Size.Large),
                new Animal(Diet.Herbivore, Size.Large), //this last one is expected to NOT be placed. 
            };

            //Act
            foreach(Animal animal in animals)
            {
                wagon.PlaceAnimal(animal);
            }

            List<Animal> placedAnimals = wagon.SeatedAnimals.ToList();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue(placedAnimals.Count == 3);
                for(int i = 0; i < placedAnimals.Count; i++)
                {
                    Assert.IsTrue(animals[i].Placed);
                }
                Assert.IsFalse(animals[placedAnimals.Count].Placed);
            });
        }

        [Test]
        public void CalculateSeatedSize()
        {
            //Arrange
            List<Animal> animals = new List<Animal>()
            {
                new Animal(Diet.Carnivore, Size.Small), //size 1
                new Animal(Diet.Herbivore, Size.Medium),//size 3
                new Animal(Diet.Herbivore, Size.Large)  //size 5
            };

            int expectedResult = 0;
            Wagon wagon = new Wagon();

            //Act
            foreach(Animal animal in animals)
            {
                expectedResult += (int)animal.Size; // In methode calculating the combined size of the placed animals. 
                wagon.PlaceAnimal(animal);
            }

            //Assert
            Assert.AreEqual(expectedResult, wagon.CalculateSeatedSize());
        }
    }
}