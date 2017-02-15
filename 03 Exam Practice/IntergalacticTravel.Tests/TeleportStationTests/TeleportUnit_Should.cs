using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
using IntergalacticTravel.Tests.Fakes;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace IntergalacticTravel.Tests.TeleportStationTests
{
    [TestFixture]
    public class TeleportUnit_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenUnitToTeleportIsNull()
        {
            // Arrange
            var stationOwnerStub = new Mock<IBusinessOwner>();
            var stationMapStub = new List<IPath> { new Mock<IPath>().Object };
            var stationLocationStub = new Mock<ILocation>();
            var teleport = new TeleportStation(stationOwnerStub.Object, stationMapStub, stationLocationStub.Object);
            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => teleport.TeleportUnit(null, stationLocationStub.Object));
        }

        [Test]
        public void ThrowWithMessageContainingTheStringUnitToTeleport_WhenUnitToTeleportIsNull()
        {
            // Arrange
            var stationOwnerStub = new Mock<IBusinessOwner>();
            var stationMapStub = new List<IPath> { new Mock<IPath>().Object };
            var stationLocationStub = new Mock<ILocation>();
            var teleport = new TeleportStation(stationOwnerStub.Object, stationMapStub, stationLocationStub.Object);
            // Act and Assert
            try
            {
                teleport.TeleportUnit(null, stationLocationStub.Object);
            }
            catch (ArgumentNullException ex)
            {
                StringAssert.Contains("unitToTeleport", ex.Message);
            }
        }

        [Test]
        public void ThrowArgumentNullException_WhenLocationIsNull()
        {
            // Arrange
            var stationOwnerStub = new Mock<IBusinessOwner>();
            var stationMapStub = new List<IPath> { new Mock<IPath>().Object };
            var stationLocationStub = new Mock<ILocation>();
            var teleport = new TeleportStation(stationOwnerStub.Object, stationMapStub, stationLocationStub.Object);

            var unitToTeleportStub = new Mock<IUnit>();
            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => teleport.TeleportUnit(unitToTeleportStub.Object, null));
        }

        [Test]
        public void ThrowWithMessageContainingTheStringDestination_WhenLocationIsNull()
        {
            // Arrange
            var stationOwnerStub = new Mock<IBusinessOwner>();
            var stationMapStub = new List<IPath> { new Mock<IPath>().Object };
            var stationLocationStub = new Mock<ILocation>();
            var teleport = new TeleportStation(stationOwnerStub.Object, stationMapStub, stationLocationStub.Object);

            var unitToTeleportStub = new Mock<IUnit>();
            // Act and Assert
            try
            {
                teleport.TeleportUnit(unitToTeleportStub.Object, null);
            }
            catch (ArgumentNullException ex)
            {
                StringAssert.Contains("destination", ex.Message);
            }
        }

        [Test]
        public void ThrowTeleportOutOfRangeException_WhenUnitTriesToUseTeleportFromDifferentPlanet()
        {
            // Arrange
            var stationOwnerStub = new Mock<IBusinessOwner>();
            var stationMapStub = new List<IPath> { new Mock<IPath>().Object };
            var stationLocationStub = new Mock<ILocation>();
            stationLocationStub.SetupGet(l => l.Planet.Galaxy.Name).Returns("Milky way");
            stationLocationStub.SetupGet(l => l.Planet.Name).Returns("Earth");

            var teleport = new TeleportStation(stationOwnerStub.Object, stationMapStub, stationLocationStub.Object);

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.SetupGet(d => d.Planet.Galaxy.Name).Returns("Andromeda");
            targetLocationStub.SetupGet(d => d.Planet.Name).Returns("Kobe");

            var unitToTeleportStub = new Mock<IUnit>();
            unitToTeleportStub.Setup(u => u.CurrentLocation).Returns(targetLocationStub.Object);
            // Act and Assert
            Assert.Throws<TeleportOutOfRangeException>(
                () => teleport.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object));
        }

        [Test]
        public void ThrowWithMessageContainingTheStringUnitToTeleportCurrentLocation_WhenUnitTriesToUseTeleportFromDifferentPlanetOrGalaxy()
        {
            // Arrange
            var stationOwnerStub = new Mock<IBusinessOwner>();
            var stationMapStub = new List<IPath> { new Mock<IPath>().Object };
            var stationLocationStub = new Mock<ILocation>();
            stationLocationStub.SetupGet(l => l.Planet.Galaxy.Name).Returns("Milky way");
            stationLocationStub.SetupGet(l => l.Planet.Name).Returns("Earth");

            var teleport = new TeleportStation(stationOwnerStub.Object, stationMapStub, stationLocationStub.Object);

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.SetupGet(d => d.Planet.Galaxy.Name).Returns("Andromeda");
            targetLocationStub.SetupGet(d => d.Planet.Name).Returns("Kobe");

            var unitToTeleportStub = new Mock<IUnit>();
            unitToTeleportStub.Setup(u => u.CurrentLocation).Returns(targetLocationStub.Object);

            try
            {   // Act
                teleport.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object);
            }
            catch (TeleportOutOfRangeException ex)
            {   // Assert
                StringAssert.Contains("unitToTeleport.CurrentLocation", ex.Message);
            }
        }

        [Test]
        public void ThrowInvalidTeleportationLocationException_WhenTryToTeleportUnitToLocationWhichAnotherUnitHasAlreadyTaken()
        {
            // Arrange
            var stationOwnerStub = new Mock<IBusinessOwner>();

            var stationLocationStub = new Mock<ILocation>();
            stationLocationStub.SetupGet(l => l.Planet.Galaxy.Name).Returns("Milky way");
            stationLocationStub.SetupGet(l => l.Planet.Name).Returns("Earth");
            stationLocationStub.SetupGet(l => l.Coordinates.Latitude).Returns(94.00);
            stationLocationStub.SetupGet(l => l.Coordinates.Longtitude).Returns(17.00);

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.SetupGet(d => d.Planet.Galaxy.Name).Returns("Andromeda");
            targetLocationStub.SetupGet(d => d.Planet.Name).Returns("Kobe");
            targetLocationStub.SetupGet(d => d.Coordinates.Latitude).Returns(94.00);
            targetLocationStub.SetupGet(d => d.Coordinates.Longtitude).Returns(17.00);

            var unitAlreadyAtTargetLocationStub = new Mock<IUnit>();
            unitAlreadyAtTargetLocationStub.Setup(u => u.CurrentLocation).Returns(targetLocationStub.Object);

            var pathStub = new Mock<IPath>();
            pathStub.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns("Andromeda");
            pathStub.SetupGet(p => p.TargetLocation.Planet.Name).Returns("Kobe");
            pathStub.SetupGet(p => p.TargetLocation.Planet.Units).Returns(new List<IUnit> { unitAlreadyAtTargetLocationStub.Object });

            var stationMapStub = new List<IPath> { pathStub.Object };

            var teleport = new TeleportStation(stationOwnerStub.Object, stationMapStub, stationLocationStub.Object);

            var unitToTeleportStub = new Mock<IUnit>();
            unitToTeleportStub.Setup(u => u.CurrentLocation).Returns(stationLocationStub.Object);
            // Act and Assert
            Assert.Throws<InvalidTeleportationLocationException>(
                () => teleport.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object));
        }

        [Test]
        public void ThrowWithMessageContainingTheStringUnitsWillOverlap_WhenTryToTeleportUnitToLocationWhichAnotherUnitHasAlreadyTaken()
        {
            // Arrange
            var stationOwnerStub = new Mock<IBusinessOwner>();

            var stationLocationStub = new Mock<ILocation>();
            stationLocationStub.SetupGet(l => l.Planet.Galaxy.Name).Returns("Milky way");
            stationLocationStub.SetupGet(l => l.Planet.Name).Returns("Earth");
            stationLocationStub.SetupGet(l => l.Coordinates.Latitude).Returns(94.00);
            stationLocationStub.SetupGet(l => l.Coordinates.Longtitude).Returns(17.00);

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.SetupGet(d => d.Planet.Galaxy.Name).Returns("Andromeda");
            targetLocationStub.SetupGet(d => d.Planet.Name).Returns("Kobe");
            targetLocationStub.SetupGet(d => d.Coordinates.Latitude).Returns(94.00);
            targetLocationStub.SetupGet(d => d.Coordinates.Longtitude).Returns(17.00);

            var unitAlreadyAtTargetLocationStub = new Mock<IUnit>();
            unitAlreadyAtTargetLocationStub.Setup(u => u.CurrentLocation).Returns(targetLocationStub.Object);

            var pathStub = new Mock<IPath>();
            pathStub.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns("Andromeda");
            pathStub.SetupGet(p => p.TargetLocation.Planet.Name).Returns("Kobe");
            pathStub.SetupGet(p => p.TargetLocation.Planet.Units).Returns(new List<IUnit> { unitAlreadyAtTargetLocationStub.Object });

            var stationMapStub = new List<IPath> { pathStub.Object };

            var teleport = new TeleportStation(stationOwnerStub.Object, stationMapStub, stationLocationStub.Object);

            var unitToTeleportStub = new Mock<IUnit>();
            unitToTeleportStub.Setup(u => u.CurrentLocation).Returns(stationLocationStub.Object);
            try
            {   // Act
                teleport.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object);
            }
            catch (InvalidTeleportationLocationException ex)
            {   // Assert
                StringAssert.Contains("units will overlap", ex.Message);
            }
        }

        [Test]
        public void ThrowLocationNotFoundException_WhenTryToTeleportUnitToGalaxyWhichIsNotInTheStaionMap()
        {
            // Arrange
            var stationOwnerStub = new Mock<IBusinessOwner>();

            var stationLocationStub = new Mock<ILocation>();
            stationLocationStub.SetupGet(l => l.Planet.Galaxy.Name).Returns("Milky way");

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.SetupGet(d => d.Planet.Galaxy.Name).Returns("Andromeda");

            var pathStub = new Mock<IPath>();
            pathStub.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns("Orion");

            var stationMapStub = new List<IPath> { pathStub.Object };

            var teleport = new TeleportStation(stationOwnerStub.Object, stationMapStub, stationLocationStub.Object);

            var unitToTeleportStub = new Mock<IUnit>();
            unitToTeleportStub.Setup(u => u.CurrentLocation).Returns(stationLocationStub.Object);
            // Act and Assert
            Assert.Throws<LocationNotFoundException>(
                () => teleport.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object));
        }

        [Test]
        public void ThrowWithMessageContainingStingGalaxy_WhenTryToTeleportUnitToGalaxyWhichIsNotInTheStaionMap()
        {
            // Arrange
            var stationOwnerStub = new Mock<IBusinessOwner>();

            var stationLocationStub = new Mock<ILocation>();
            stationLocationStub.SetupGet(l => l.Planet.Galaxy.Name).Returns("Milky way");

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.SetupGet(d => d.Planet.Galaxy.Name).Returns("Andromeda");

            var pathStub = new Mock<IPath>();
            pathStub.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns("Orion");

            var stationMapStub = new List<IPath> { pathStub.Object };

            var teleport = new TeleportStation(stationOwnerStub.Object, stationMapStub, stationLocationStub.Object);

            var unitToTeleportStub = new Mock<IUnit>();
            unitToTeleportStub.Setup(u => u.CurrentLocation).Returns(stationLocationStub.Object);

            try
            {   // Act
                teleport.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object);
            }
            catch (LocationNotFoundException ex)
            {   // Assert
                StringAssert.Contains("Galaxy", ex.Message);
            }
        }

        [Test]
        public void ThrowLocationNotFoundException_WhenTryToTeleportUnitToPlanetWhichIsNotInTheStaionMap()
        {
            // Arrange
            var stationOwnerStub = new Mock<IBusinessOwner>();

            var stationLocationStub = new Mock<ILocation>();
            stationLocationStub.SetupGet(l => l.Planet.Galaxy.Name).Returns("Milky way");
            stationLocationStub.SetupGet(l => l.Planet.Name).Returns("Earth");

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.SetupGet(d => d.Planet.Galaxy.Name).Returns("Andromeda");
            targetLocationStub.SetupGet(d => d.Planet.Name).Returns("Kobe");

            var pathStub = new Mock<IPath>();
            pathStub.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns("Andromeda");
            pathStub.SetupGet(p => p.TargetLocation.Planet.Name).Returns("Sirius");

            var stationMapStub = new List<IPath> { pathStub.Object };

            var teleport = new TeleportStation(stationOwnerStub.Object, stationMapStub, stationLocationStub.Object);

            var unitToTeleportStub = new Mock<IUnit>();
            unitToTeleportStub.Setup(u => u.CurrentLocation).Returns(stationLocationStub.Object);
            // Act and Assert
            Assert.Throws<LocationNotFoundException>(
                () => teleport.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object));
        }

        [Test]
        public void ThrowWithMessageContainingStingPlanet_WhenTryToTeleportUnitToPlanetWhichIsNotInTheStaionMap()
        {
            // Arrange
            var stationOwnerStub = new Mock<IBusinessOwner>();

            var stationLocationStub = new Mock<ILocation>();
            stationLocationStub.SetupGet(l => l.Planet.Galaxy.Name).Returns("Milky way");
            stationLocationStub.SetupGet(l => l.Planet.Name).Returns("Earth");

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.SetupGet(d => d.Planet.Galaxy.Name).Returns("Andromeda");
            targetLocationStub.SetupGet(d => d.Planet.Name).Returns("Kobe");

            var pathStub = new Mock<IPath>();
            pathStub.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns("Andromeda");
            pathStub.SetupGet(p => p.TargetLocation.Planet.Name).Returns("Sirius");

            var stationMapStub = new List<IPath> { pathStub.Object };

            var teleport = new TeleportStation(stationOwnerStub.Object, stationMapStub, stationLocationStub.Object);

            var unitToTeleportStub = new Mock<IUnit>();
            unitToTeleportStub.Setup(u => u.CurrentLocation).Returns(stationLocationStub.Object);

            try
            {   // Act
                teleport.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object);
            }
            catch (LocationNotFoundException ex)
            {   // Assert
                StringAssert.Contains("Planet", ex.Message);
            }
        }

        [Test]
        public void ThrowInsufficientResourcesException_WhenTryToTeleportUnitWithInsuficientResources()
        {
            // Arrange
            var stationOwnerStub = new Mock<IBusinessOwner>();

            var stationLocationStub = new Mock<ILocation>();
            stationLocationStub.SetupGet(l => l.Planet.Galaxy.Name).Returns("Milky way");
            stationLocationStub.SetupGet(l => l.Planet.Name).Returns("Earth");

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.SetupGet(d => d.Planet.Galaxy.Name).Returns("Andromeda");
            targetLocationStub.SetupGet(d => d.Planet.Name).Returns("Kobe");

            var pathStub = new Mock<IPath>();
            pathStub.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns("Andromeda");
            pathStub.SetupGet(p => p.TargetLocation.Planet.Name).Returns("Kobe");
            pathStub.SetupGet(p => p.TargetLocation.Planet.Units).Returns(new List<IUnit>());

            var stationMapStub = new List<IPath> { pathStub.Object };

            var teleport = new TeleportStation(stationOwnerStub.Object, stationMapStub, stationLocationStub.Object);

            var unitToTeleportStub = new Mock<IUnit>();
            unitToTeleportStub.Setup(u => u.CurrentLocation).Returns(stationLocationStub.Object);
            unitToTeleportStub.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(false);
            // Act and Assert
            Assert.Throws<InsufficientResourcesException>(
                () => teleport.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object));
        }

        [Test]
        public void ThrowWithMessageContainingStingFreeLunch_WhenTryToTeleportUnitWithInsuficientResources()
        {
            // Arrange
            var stationOwnerStub = new Mock<IBusinessOwner>();

            var stationLocationStub = new Mock<ILocation>();
            stationLocationStub.SetupGet(l => l.Planet.Galaxy.Name).Returns("Milky way");
            stationLocationStub.SetupGet(l => l.Planet.Name).Returns("Earth");

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.SetupGet(d => d.Planet.Galaxy.Name).Returns("Andromeda");
            targetLocationStub.SetupGet(d => d.Planet.Name).Returns("Kobe");

            var pathStub = new Mock<IPath>();
            pathStub.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns("Andromeda");
            pathStub.SetupGet(p => p.TargetLocation.Planet.Name).Returns("Kobe");
            pathStub.SetupGet(p => p.TargetLocation.Planet.Units).Returns(new List<IUnit>());

            var stationMapStub = new List<IPath> { pathStub.Object };

            var teleport = new TeleportStation(stationOwnerStub.Object, stationMapStub, stationLocationStub.Object);

            var unitToTeleportStub = new Mock<IUnit>();
            unitToTeleportStub.Setup(u => u.CurrentLocation).Returns(stationLocationStub.Object);
            unitToTeleportStub.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(false);

            try
            {   // Act
                teleport.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object);
            }
            catch (InsufficientResourcesException ex)
            {   // Assert
                StringAssert.Contains("FREE LUNCH", ex.Message);
            }
        }

        [Test]
        public void CauseTeleportStationToRequirePaymentFromUnitToTeleport_WhenAllValidationsPassSuccessfully()
        {
            // Arrange
            var stationOwnerStub = new Mock<IBusinessOwner>();
            var unitToTeleportStub = new Mock<IUnit>();

            var stationLocationStub = new Mock<ILocation>();
            stationLocationStub.SetupGet(l => l.Planet.Galaxy.Name).Returns("Milky way");
            stationLocationStub.SetupGet(l => l.Planet.Name).Returns("Earth");
            stationLocationStub.SetupGet(l => l.Planet.Units).Returns(new List<IUnit> { unitToTeleportStub.Object });

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.SetupGet(d => d.Planet.Galaxy.Name).Returns("Andromeda");
            targetLocationStub.SetupGet(d => d.Planet.Name).Returns("Kobe");

            var pathStub = new Mock<IPath>();
            pathStub.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns("Andromeda");
            pathStub.SetupGet(p => p.TargetLocation.Planet.Name).Returns("Kobe");
            pathStub.SetupGet(p => p.TargetLocation.Planet.Units).Returns(new List<IUnit>());
            pathStub.SetupGet(p => p.Cost).Returns(new Mock<IResources>().Object);

            var stationMapStub = new List<IPath> { pathStub.Object };

            var teleport = new TeleportStation(stationOwnerStub.Object, stationMapStub, stationLocationStub.Object);

            unitToTeleportStub.Setup(u => u.CurrentLocation).Returns(stationLocationStub.Object);
            unitToTeleportStub.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportStub.Setup(u => u.Pay(It.IsAny<IResources>())).Returns(new Mock<IResources>().Object);
            // Act
            teleport.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object);
            // Assert
            unitToTeleportStub.Verify(u => u.Pay(It.IsAny<IResources>()), Times.Once);
        }

        [Test]
        public void CauseTeleportStationToObtainPaymentFromUnitToTeleport_WhenAllValidationsPassSuccessfully()
        {
            // Arrange
            var stationOwnerStub = new Mock<IBusinessOwner>();
            var unitToTeleportStub = new Mock<IUnit>();

            var stationLocationStub = new Mock<ILocation>();
            stationLocationStub.SetupGet(l => l.Planet.Galaxy.Name).Returns("Milky way");
            stationLocationStub.SetupGet(l => l.Planet.Name).Returns("Earth");
            stationLocationStub.SetupGet(l => l.Planet.Units).Returns(new List<IUnit> { unitToTeleportStub.Object });

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.SetupGet(d => d.Planet.Galaxy.Name).Returns("Andromeda");
            targetLocationStub.SetupGet(d => d.Planet.Name).Returns("Kobe");

            var pathCostsStub = new Mock<IResources>();
            pathCostsStub.SetupGet(r => r.BronzeCoins).Returns(20);
            pathCostsStub.SetupGet(r => r.SilverCoins).Returns(20);
            pathCostsStub.SetupGet(r => r.GoldCoins).Returns(20);

            var pathStub = new Mock<IPath>();
            pathStub.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns("Andromeda");
            pathStub.SetupGet(p => p.TargetLocation.Planet.Name).Returns("Kobe");
            pathStub.SetupGet(p => p.TargetLocation.Planet.Units).Returns(new List<IUnit>());
            pathStub.SetupGet(p => p.Cost).Returns(pathCostsStub.Object);

            var stationMapStub = new List<IPath> { pathStub.Object };

            var teleport = new TeleportStationFake(stationOwnerStub.Object, stationMapStub, stationLocationStub.Object);

            teleport.ResoursesExposed.BronzeCoins = 0;
            teleport.ResoursesExposed.SilverCoins = 0;
            teleport.ResoursesExposed.GoldCoins = 0;

            unitToTeleportStub.Setup(u => u.CurrentLocation).Returns(stationLocationStub.Object);
            unitToTeleportStub.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportStub.Setup(u => u.Pay(It.IsAny<IResources>())).Returns(pathCostsStub.Object);
            unitToTeleportStub.Setup(u => u.Resources).Returns(pathCostsStub.Object);
            // Act
            teleport.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object);
            // Assert
            Assert.AreEqual(teleport.ResoursesExposed.BronzeCoins, 20);
            Assert.AreEqual(teleport.ResoursesExposed.SilverCoins, 20);
            Assert.AreEqual(teleport.ResoursesExposed.GoldCoins, 20);
        }

        [Test]
        public void SetUnitToTeleportCurrentLocationToTargetLocation_WhenAllValidationsPassSuccessfullyAndUnitIsTeleported()
        {
            // Arrange
            var stationOwnerStub = new Mock<IBusinessOwner>();
            var unitToTeleportMock = new Mock<IUnit>();

            var stationLocationStub = new Mock<ILocation>();
            stationLocationStub.SetupGet(l => l.Planet.Galaxy.Name).Returns("Milky way");
            stationLocationStub.SetupGet(l => l.Planet.Name).Returns("Earth");
            stationLocationStub.SetupGet(l => l.Planet.Units).Returns(new List<IUnit> { unitToTeleportMock.Object });

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.SetupGet(d => d.Planet.Galaxy.Name).Returns("Andromeda");
            targetLocationStub.SetupGet(d => d.Planet.Name).Returns("Kobe");

            var pathStub = new Mock<IPath>();
            pathStub.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns("Andromeda");
            pathStub.SetupGet(p => p.TargetLocation.Planet.Name).Returns("Kobe");
            pathStub.SetupGet(p => p.TargetLocation.Planet.Units).Returns(new List<IUnit>());
            pathStub.SetupGet(p => p.Cost).Returns(new Mock<IResources>().Object);

            var stationMapStub = new List<IPath> { pathStub.Object };

            var teleport = new TeleportStation(stationOwnerStub.Object, stationMapStub, stationLocationStub.Object);

            unitToTeleportMock.SetupProperty(u => u.CurrentLocation, stationLocationStub.Object);
            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(u => u.Pay(It.IsAny<IResources>())).Returns(new Mock<IResources>().Object);
            // Act
            teleport.TeleportUnit(unitToTeleportMock.Object, targetLocationStub.Object);
            // Assert
            unitToTeleportMock.VerifySet(u => u.CurrentLocation = targetLocationStub.Object);
        }

        [Test]
        public void SetUnitToTeleportPreviousLocationToCurrentLocation_WhenAllValidationsPassSuccessfullyAndUnitIsBeingTeleported()
        {
            // Arrange
            var stationOwnerStub = new Mock<IBusinessOwner>();
            var unitToTeleportMock = new Mock<IUnit>();

            var stationLocationStub = new Mock<ILocation>();
            stationLocationStub.SetupGet(l => l.Planet.Galaxy.Name).Returns("Milky way");
            stationLocationStub.SetupGet(l => l.Planet.Name).Returns("Earth");
            stationLocationStub.SetupGet(l => l.Planet.Units).Returns(new List<IUnit> { unitToTeleportMock.Object });

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.SetupGet(d => d.Planet.Galaxy.Name).Returns("Andromeda");
            targetLocationStub.SetupGet(d => d.Planet.Name).Returns("Kobe");

            var pathStub = new Mock<IPath>();
            pathStub.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns("Andromeda");
            pathStub.SetupGet(p => p.TargetLocation.Planet.Name).Returns("Kobe");
            pathStub.SetupGet(p => p.TargetLocation.Planet.Units).Returns(new List<IUnit>());
            pathStub.SetupGet(p => p.Cost).Returns(new Mock<IResources>().Object);

            var stationMapStub = new List<IPath> { pathStub.Object };

            var teleport = new TeleportStation(stationOwnerStub.Object, stationMapStub, stationLocationStub.Object);

            unitToTeleportMock.SetupProperty(u => u.CurrentLocation, stationLocationStub.Object);
            unitToTeleportMock.SetupProperty(u => u.PreviousLocation);
            unitToTeleportMock.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(u => u.Pay(It.IsAny<IResources>())).Returns(new Mock<IResources>().Object);
            // Act
            teleport.TeleportUnit(unitToTeleportMock.Object, targetLocationStub.Object);
            // Assert
            unitToTeleportMock.VerifySet(u => u.PreviousLocation = stationLocationStub.Object);
        }

        [Test]
        public void AddUnitToTeleportToListOfUnitsOfTargetLocation_WhenAllValidationsPassSuccessfullyAndUnitIsBeingTeleported()
        {
            // Arrange
            var stationOwnerStub = new Mock<IBusinessOwner>();
            var unitToTeleportStub = new Mock<IUnit>();

            var stationLocationStub = new Mock<ILocation>();
            stationLocationStub.SetupGet(l => l.Planet.Galaxy.Name).Returns("Milky way");
            stationLocationStub.SetupGet(l => l.Planet.Name).Returns("Earth");
            stationLocationStub.Setup(l => l.Planet.Units).Returns(new List<IUnit> { unitToTeleportStub.Object });

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.SetupGet(d => d.Planet.Galaxy.Name).Returns("Andromeda");
            targetLocationStub.SetupGet(d => d.Planet.Name).Returns("Kobe");

            var pathMock = new Mock<IPath>();
            pathMock.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns("Andromeda");
            pathMock.SetupGet(p => p.TargetLocation.Planet.Name).Returns("Kobe");
            pathMock.SetupGet(p => p.TargetLocation.Planet.Units).Returns(new List<IUnit>());
            pathMock.SetupGet(p => p.Cost).Returns(new Mock<IResources>().Object);

            var stationMapStub = new List<IPath> { pathMock.Object };

            var teleport = new TeleportStation(stationOwnerStub.Object, stationMapStub, stationLocationStub.Object);

            unitToTeleportStub.SetupProperty(u => u.CurrentLocation, stationLocationStub.Object);
            unitToTeleportStub.SetupProperty(u => u.PreviousLocation);
            unitToTeleportStub.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportStub.Setup(u => u.Pay(It.IsAny<IResources>())).Returns(new Mock<IResources>().Object);
            // Act
            teleport.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object);
            // Assert
            CollectionAssert.Contains(pathMock.Object.TargetLocation.Planet.Units, unitToTeleportStub.Object);
        }

        [Test]
        public void RemoveUnitToTeleportFromListOfUnitsOfCurrentLocation_WhenAllValidationsPassSuccessfullyAndUnitIsBeingTeleported()
        {
            // Arrange
            var stationOwnerStub = new Mock<IBusinessOwner>();
            var unitToTeleportStub = new Mock<IUnit>();

            var stationLocationMock = new Mock<ILocation>();
            stationLocationMock.SetupGet(l => l.Planet.Galaxy.Name).Returns("Milky way");
            stationLocationMock.SetupGet(l => l.Planet.Name).Returns("Earth");
            stationLocationMock.Setup(l => l.Planet.Units).Returns(new List<IUnit> { unitToTeleportStub.Object });

            var targetLocationStub = new Mock<ILocation>();
            targetLocationStub.SetupGet(d => d.Planet.Galaxy.Name).Returns("Andromeda");
            targetLocationStub.SetupGet(d => d.Planet.Name).Returns("Kobe");

            var pathStub = new Mock<IPath>();
            pathStub.SetupGet(p => p.TargetLocation.Planet.Galaxy.Name).Returns("Andromeda");
            pathStub.SetupGet(p => p.TargetLocation.Planet.Name).Returns("Kobe");
            pathStub.SetupGet(p => p.TargetLocation.Planet.Units).Returns(new List<IUnit>());
            pathStub.SetupGet(p => p.Cost).Returns(new Mock<IResources>().Object);

            var stationMapStub = new List<IPath> { pathStub.Object };

            var teleport = new TeleportStation(stationOwnerStub.Object, stationMapStub, stationLocationMock.Object);

            unitToTeleportStub.SetupProperty(u => u.CurrentLocation, stationLocationMock.Object);
            unitToTeleportStub.SetupProperty(u => u.PreviousLocation);
            unitToTeleportStub.Setup(u => u.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportStub.Setup(u => u.Pay(It.IsAny<IResources>())).Returns(new Mock<IResources>().Object);
            // Act
            teleport.TeleportUnit(unitToTeleportStub.Object, targetLocationStub.Object);
            // Assert
            CollectionAssert.DoesNotContain(stationLocationMock.Object.Planet.Units, unitToTeleportStub.Object);
        }
    }
}
