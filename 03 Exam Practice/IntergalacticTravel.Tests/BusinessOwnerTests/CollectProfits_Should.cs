using IntergalacticTravel.Contracts;
using IntergalacticTravel.Tests.Fakes;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace IntergalacticTravel.Tests.BusinessOwnerTests
{
    [TestFixture]
    public class CollectProfits_Should
    {
        [Test]
        public void IncreaseTheOwnerResourcesByTheTotalAmountOfProfitsFromTheirStations_WhenInvoked()
        {
            // Arrange
            int validIdentificationNumber = 1;
            string validNickName = "Pesho";
            var stationsList = new List<ITeleportStation>();

            var stationOwner = new BusinessOwner(validIdentificationNumber, validNickName, stationsList);
            stationOwner.Resources.BronzeCoins = 20;
            stationOwner.Resources.SilverCoins = 20;
            stationOwner.Resources.GoldCoins = 20;

            var stationMapStub = new List<IPath>();
            var stationLocationStub = new Mock<ILocation>();
            var teleportStationFake = new TeleportStationFake(stationOwner,stationMapStub, stationLocationStub.Object);

            teleportStationFake.ResoursesExposed.BronzeCoins = 20;
            teleportStationFake.ResoursesExposed.SilverCoins = 20;
            teleportStationFake.ResoursesExposed.GoldCoins = 20;

            stationOwner.TeleportStations.Add(teleportStationFake);
            // Act
            stationOwner.CollectProfits();
            // Assert
            Assert.AreEqual(40, stationOwner.Resources.BronzeCoins);
            Assert.AreEqual(40, stationOwner.Resources.SilverCoins);
            Assert.AreEqual(40, stationOwner.Resources.GoldCoins);
        }
    }
}
