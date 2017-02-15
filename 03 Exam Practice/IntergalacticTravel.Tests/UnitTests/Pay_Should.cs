using IntergalacticTravel.Contracts;
using IntergalacticTravel.Tests.Fakes;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace IntergalacticTravel.Tests.UnitTests
{
    [TestFixture]
    public class Pay_Should
    {
        [Test]
        public void ThrowNullReferenceException_WhenPassedObjectIsNull()
        {
            // Arrange
            int validIdentificationNumber = 1;
            string validNickname = "Pesho";

            var unit = new Unit(validIdentificationNumber, validNickname);
            // Act and Assert
            Assert.Throws<NullReferenceException>(() => unit.Pay(null));
        }

        [Test]
        public void DecreaseUnitResourcesByTheAmountOfTheCost_WhenPassedValidCost()
        {
            // Arrange
            int validIdentificationNumber = 1;
            string validNickname = "Pesho";

            var unit = new Unit(validIdentificationNumber, validNickname);
            unit.Resources.BronzeCoins = 40;
            unit.Resources.SilverCoins = 40;
            unit.Resources.GoldCoins = 40;

            var costStub = new Mock<IResources>();
            costStub.SetupGet(c => c.BronzeCoins).Returns(20);
            costStub.SetupGet(c => c.SilverCoins).Returns(20);
            costStub.SetupGet(c => c.GoldCoins).Returns(20);
            // Act
            unit.Pay(costStub.Object);
            // Assert
            Assert.AreEqual(40 - 20, unit.Resources.BronzeCoins);
            Assert.AreEqual(40 - 20, unit.Resources.SilverCoins);
            Assert.AreEqual(40 - 20, unit.Resources.GoldCoins);
        }

        [Test]
        public void ReturnNewResourcesObject_WhenPassedValidCost()
        {
            // Arrange
            int validIdentificationNumber = 1;
            string validNickname = "Pesho";
            var unit = new Unit(validIdentificationNumber, validNickname);
            var costStub = new Mock<IResources>();
            // Act
            var result = unit.Pay(costStub.Object);
            // Assert
            Assert.IsTrue(typeof(Resources).Equals(result.GetType()));
        }

        [Test]
        public void ReturnResourcesObjectWithTheAmountOfResourcesOfTheCost_WhenPassedValidCost()
        {
            // Arrange
            int validIdentificationNumber = 1;
            string validNickname = "Pesho";

            var unit = new Unit(validIdentificationNumber, validNickname);
            unit.Resources.BronzeCoins = 40;
            unit.Resources.SilverCoins = 40;
            unit.Resources.GoldCoins = 40;

            var costStub = new Mock<IResources>();
            costStub.SetupGet(c => c.BronzeCoins).Returns(20);
            costStub.SetupGet(c => c.SilverCoins).Returns(20);
            costStub.SetupGet(c => c.GoldCoins).Returns(20);
            // Act
            var result = unit.Pay(costStub.Object);
            // Assert
            Assert.AreEqual(costStub.Object.BronzeCoins, result.BronzeCoins);
            Assert.AreEqual(costStub.Object.SilverCoins, result.SilverCoins);
            Assert.AreEqual(costStub.Object.GoldCoins, result.GoldCoins);
        }
    }
}
