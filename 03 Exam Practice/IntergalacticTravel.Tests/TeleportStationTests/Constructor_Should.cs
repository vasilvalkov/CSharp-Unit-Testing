using IntergalacticTravel.Contracts;
using IntergalacticTravel.Tests.Fakes;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace IntergalacticTravel.Tests.TeleportStationTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void SetAllProvidedFields_WhenPassedValidParameters()
        {
            // Arrange
            var ownerStub = new Mock<IBusinessOwner>();
            var mapStub = new List<IPath> { new Mock<IPath>().Object };
            var locationStub = new Mock<ILocation>();
            // Act
            var teleportFake = new TeleportStationFake(ownerStub.Object, mapStub, locationStub.Object);
            // Assert
            Assert.AreSame(ownerStub.Object, teleportFake.OwnerExposed);
            Assert.AreSame(mapStub, teleportFake.GalacticMapExposed);
            Assert.AreSame(locationStub.Object, teleportFake.LocationExposed);
        }
    }
}
