using NUnit.Framework;
using LP_CircusTreinV4.Models;
using static LP_CircusTreinV4.Models.Enums;

namespace Tests
{
    public class TestAnimal
    {
        Diet diet;
        Size size;
        Animal animal;

        [SetUp]
        public void Setup()
        {
            diet = Diet.Herbivore;
            size = Size.Large;
            animal = new Animal(diet, size);
        }

        [Test]
        public void CorrectyInstantiate()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(animal.Diet, diet);
                Assert.AreEqual(animal.Size, size);
            });
        }

        //[Test]
        //public void CorrectToString()
        //{
        //    string correctFormat = animal.Diet.ToString() + ", " + animal.Size.ToString();
        //    Assert.AreEqual(correctFormat, animal.ToString());
        //}
    }
}