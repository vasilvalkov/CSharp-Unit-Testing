using IntergalacticTravel.Contracts;
using IntergalacticTravel.Tests.Fakes;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace IntergalacticTravel.Tests.TeleportStationTests
{
    [TestFixture]
    public class PayProfits_Should
    {
        [Test]
        public void ThrowUnauthorizedAccessException_WhenPassedActualOwnerOfTheService()
        {
            // Arrange
            var stationOwnerStub = new Mock<IBusinessOwner>();
            var otherOwnerStub = new Mock<IBusinessOwner>();
            var stationLocationMock = new Mock<ILocation>();
            var stationMapStub = new List<IPath> { new Mock<IPath>().Object };

            stationOwnerStub.SetupGet(so => so.IdentificationNumber).Returns(1);
            otherOwnerStub.SetupGet(oo => oo.IdentificationNumber).Returns(2);

            var teleport = new TeleportStation(stationOwnerStub.Object, stationMapStub, stationLocationMock.Object);
            // Act and Assert
            Assert.Throws<UnauthorizedAccessException>(() => teleport.PayProfits(otherOwnerStub.Object));
        }

        [Test]
        public void ReturnTotalAmountOfResourcesGeneratedUsingTeleportService_WhenPassedActualOwnerOfTheService()
        {
            // Arrange
            var stationOwnerStub = new Mock<IBusinessOwner>();
            var stationLocationMock = new Mock<ILocation>();
            var stationMapStub = new List<IPath> { new Mock<IPath>().Object };

            var teleport = new TeleportStationFake(stationOwnerStub.Object, stationMapStub, stationLocationMock.Object);

            teleport.ResoursesExposed.BronzeCoins = 20;
            teleport.ResoursesExposed.SilverCoins = 20;
            teleport.ResoursesExposed.GoldCoins = 20;       
            // Act
            var totalAmount = teleport.PayProfits(stationOwnerStub.Object);
            // Assert
            Assert.AreEqual(20, totalAmount.BronzeCoins);
            Assert.AreEqual(20, totalAmount.SilverCoins);
            Assert.AreEqual(20, totalAmount.GoldCoins);
        }
    }
}
