using NUnit.Framework;
using LP_CircusTreinV4.Models;

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
    }
}