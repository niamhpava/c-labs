using System.Xml.Linq;
using Zoo;

namespace ZooTests
{

    [TestFixture]
    public class Tests
    {
        [Test]
        public void DefaultConstructorAnimalNameTest()
        {
            //Arrange
            string expectedName = "Anonymous";

            //Act
            Animal a = new Animal();

            //Assert
            Assert.AreEqual(expectedName, a.Name);
        }

        [Test]
        public void DefaultConstructorAnimalLimbCountTest()
        {
            //Arrange
            string expectedName = "Anonymous";
            int expectedLimbCount = 6;

            //Act
            Animal a = new Animal(expectedName);

            //Assert
            Assert.AreEqual(expectedLimbCount, a.LimbCount);
        }


        [Test]
        public void DefaultConstructorAnimalColourCountTest()
        {
            //Arrange
            string expectedName = "Anonymous";
            string expectedColour = "Brown";

            //Act
            Animal a = new Animal(expectedName);

            //Assert
            Assert.AreEqual(expectedColour, a.Colour);
        }


        [Test]
        public void NonDefaultConstructorAnimalColourCountTest()
        {
            //Arrange
            string expectedName = "Fido";
            int expectedLimbCount = 3;
            string expectedColour = "Pink";

            //Act
            Animal a = new Animal(expectedName, expectedLimbCount, expectedColour);

            //Assert
            Assert.AreEqual(expectedName, a.Name);
            Assert.AreEqual(expectedLimbCount, a.LimbCount);
            Assert.AreEqual(expectedColour, a.Colour);
        }


        [Test]
        public void ConstructorAnimalEatTest()
        {
            //Arrange
            string expectedName = "Daisy";
            int expectedLimbCount = 5;
            string expectedColour = "Pink";
            string food = "Cheese";
            string expectedMessage = $"I'm an animal called {expectedName} using some of my {expectedLimbCount} limbs to eat {food}";

            //Act
            Animal a = new Animal(expectedName, expectedLimbCount, expectedColour);
            string result = a.Eat(food);

            //Assert
            Assert.AreEqual(expectedMessage, result);
        }

        [Test]
        public void IllegalLimbCountTest()
        {
            //Arrange
            string expectedName = "Anonymous";
            int expectedLimbCount = 0;
            int proposedlimbCount = -1;

            //Act
            Animal a = new Animal(expectedName);

            a.LimbCount = proposedlimbCount;
            //a.SetLimbCount(limbCount);

            //Assert
            Assert.AreEqual(expectedLimbCount, a.LimbCount);
            //Assert.AreEqual(expectedLimbCount, a.GetLimbCount());
        }
    }
}
