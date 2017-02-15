using IntergalacticTravel.Exceptions;
using NUnit.Framework;
using System;

namespace IntergalacticTravel.Tests.UnitsFactoryTests
{
    [TestFixture]
    public class GetUnit_Should
    {
        [TestCase("create unit Procyon Gosho 1", typeof(Procyon))]
        [TestCase("create unit Luyten Pesho 2", typeof(Luyten))]
        [TestCase("create unit Lacaille Tosho 3", typeof(Lacaille))]
        public void ReturnNewUnit_WhenValidCorrespondingCommandIsPassed(string validCommand, Type expectedType)
        {
            // Arrange
            var factory = new UnitsFactory();
            // Act
            var createdResource = factory.GetUnit(validCommand);
            // Assert
            Assert.IsTrue(expectedType.Equals(createdResource.GetType()));
        }

        [TestCase("create unit Gosho Procyon 1")]
        [TestCase("create")]
        [TestCase("create Luyten Pesho 2")]
        [TestCase("Luyten Pesho 2")]
        public void ThrowInvalidUnitCreationCommandException_WhenInvalidCommandIsPassed(string invalidCommand)
        {
            // Arrange
            var factory = new UnitsFactory();
            // Act and Assert
            Assert.Throws<InvalidUnitCreationCommandException>(() => factory.GetUnit(invalidCommand));
        }
    }    
}
