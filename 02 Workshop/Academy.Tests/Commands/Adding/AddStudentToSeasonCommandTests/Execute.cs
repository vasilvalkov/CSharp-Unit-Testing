namespace Academy.Tests.Commands.Adding.AddStudentToSeasonCommandTests
{
    using Academy.Commands.Adding;
    using Academy.Core.Contracts;
    using Academy.Models.Contracts;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class Execute
    {
        [Test]
        public void Execute_ShouldThrowArgumentException_WhenStudentUsernameExistsInTheSeason()
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();
            var command = new AddStudentToSeasonCommand(factoryStub.Object, engineStub.Object);

            var studentStub = new Mock<IStudent>();
            var seasonStub = new Mock<ISeason>();

            studentStub.SetupGet(s => s.Username).Returns("Pesho");
            seasonStub.SetupGet(s => s.Students).Returns(new List<IStudent> { studentStub.Object });

            engineStub.SetupGet(e => e.Students).Returns(new List<IStudent> { studentStub.Object });
            engineStub.SetupGet(e => e.Seasons).Returns(new List<ISeason> { seasonStub.Object });

            string validStudentUsername = "Pesho";
            string validSeasonId = "0";
            var parameters = new List<string> { validStudentUsername, validSeasonId };
            // Act and Assert
            Assert.Throws<ArgumentException>(() => command.Execute(parameters));
        }

        [Test]
        public void Execute_ShouldCorrectlyAddStudentIntoSpecifiedSeason_WhenStudentUsernameDoesNotExistInTheSpecifiedSeason()
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var command = new AddStudentToSeasonCommand(factoryStub.Object, engineMock.Object);

            var studentStub = new Mock<IStudent>();
            var seasonStub = new Mock<ISeason>();
            studentStub.SetupGet(s => s.Username).Returns("Pesho");
            seasonStub.SetupGet(s => s.Students).Returns(new List<IStudent>());

            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent> { studentStub.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason> { seasonStub.Object });

            string validStudentUsername = "Pesho";
            string validSeasonId = "0";
            var parameters = new List<string> { validStudentUsername, validSeasonId };
            // Act
            command.Execute(parameters);
            // Assert
            Assert.AreSame(engineMock.Object.Students[0], engineMock.Object.Seasons[0].Students[0]);
        }

        [Test]
        public void Execute_ShouldCorrectlyFindStudentbyUsername_WhenPassedSameUsernameWithDifferentCasing()
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var command = new AddStudentToSeasonCommand(factoryStub.Object, engineMock.Object);

            var studentStub = new Mock<IStudent>();
            var seasonStub = new Mock<ISeason>();
            studentStub.SetupGet(s => s.Username).Returns("pESHo");
            seasonStub.SetupGet(s => s.Students).Returns(new List<IStudent> { studentStub.Object });

            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent> { studentStub.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason> { seasonStub.Object });

            string validStudentUsername = "Pesho";
            string validSeasonId = "0";
            var parameters = new List<string> { validStudentUsername, validSeasonId };
            // Act and Assert
            Assert.Throws<ArgumentException>(() => command.Execute(parameters));
        }

        [Test]
        public void Execute_ShouldReturnSuccessMessageContainingStudentUsernameAndSeasonId_WhenStudentIsAddedIntoSpecifiedSeason()
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var command = new AddStudentToSeasonCommand(factoryStub.Object, engineMock.Object);

            var studentStub = new Mock<IStudent>();
            var seasonStub = new Mock<ISeason>();
            studentStub.SetupGet(s => s.Username).Returns("Pesho");
            seasonStub.SetupGet(s => s.Students).Returns(new List<IStudent>());

            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent> { studentStub.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason> { seasonStub.Object });

            string validStudentUsername = "Pesho";
            string validSeasonId = "0";
            var parameters = new List<string> { validStudentUsername, validSeasonId };
            // Act
            string resultMessage = command.Execute(parameters);
            // Assert
            StringAssert.Contains(validStudentUsername, resultMessage);
            StringAssert.Contains(validSeasonId, resultMessage);
        }
    }
}
