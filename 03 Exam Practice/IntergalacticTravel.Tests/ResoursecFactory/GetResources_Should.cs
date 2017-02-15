using NUnit.Framework;
using System;

namespace IntergalacticTravel.Tests.ResoursecFactory
{
    [TestFixture]
    public class GetResources_Should
    {
        [Test]
        public void ReturnNewResoursesObject_WhenPassedValidCommand()
        {
            // Arrange
            var factory = new ResourcesFactory();
            string validCommand = "create resources gold(20) silver(30) bronze(40)";
            // Act
            var createdResources = factory.GetResources(validCommand);
            // Assert
            Assert.IsTrue(typeof(Resources).Equals(createdResources.GetType()));
        }

        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void ReturnNewResourcesObjectWithCorrectlySetProperties_WhenPassedValidCommand(string validCommand)
        {
            // Arrange
            var factory = new ResourcesFactory();
            // Act
            var resources = factory.GetResources(validCommand);
            // Assert
            Assert.AreEqual(resources.BronzeCoins, 40);
            Assert.AreEqual(resources.SilverCoins, 30);
            Assert.AreEqual(resources.GoldCoins, 20);
        }

        [TestCase("create resources x y z")]
        [TestCase("tansta resources a b")]
        [TestCase("absolutelyRandomStringThatMustNotBeAValidCommand")]
        [TestCase("bronze(40) silver(30) gold(20)")]
        public void ThrowInvalidOperationException_WhenInvalidCommandIsPassed(string invalidCommand)
        {
            // Arrange
            var factory = new ResourcesFactory();
            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => factory.GetResources(invalidCommand));
        }

        [Test]
        public void ThrowWithMessageContainingTheStringCommand_WhenInvalidCommandIsPassed()
        {
            // Arrange
            var factory = new ResourcesFactory();
            string invalidCommand = "create resources x y z";
            // Act and Assert
            try
            {
                factory.GetResources(invalidCommand);
            }
            catch (InvalidOperationException ex)
            {
                StringAssert.Contains("command", ex.Message);
            }
        }

        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        public void ThrowOverflowException_WhenValidCommandIsPassedButAnyOfTheValuesIsLagrerThanUintMaxValue(string overflowCommand)
        {
            // Arrange
            var factory = new ResourcesFactory();
            // Act and Assert
            Assert.Throws<OverflowException>(() => factory.GetResources(overflowCommand));
        }
    }
}
