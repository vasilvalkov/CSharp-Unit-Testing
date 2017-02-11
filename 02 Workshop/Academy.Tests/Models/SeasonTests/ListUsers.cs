namespace Academy.Tests.Models.SeasonTests
{
    using Academy.Models;
    using Academy.Models.Contracts;
    using Academy.Models.Enums;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ListUsers
    {
        [Test]
        public void ListUsers_ShouldReturnTheListOfStudents_WhenInvoked()
        {
            // Arrange
            int validStartingYear = 2016;
            int validEndingYear = 2017;
            var season = new Season(validStartingYear, validEndingYear, Initiative.SoftwareAcademy);

            var studentMock = new Mock<IStudent>();
            studentMock.Setup(x => x.ToString()).Verifiable();
            season.Students.Add(studentMock.Object);
            // Act
            season.ListUsers();
            // Assert
            studentMock.Verify(x => x.ToString(), Times.Once);
        }

        [Test]
        public void ListUsers_ShouldReturnTheListOfTrainers_WhenInvoked()
        {
            // Arrange
            int validStartingYear = 2016;
            int validEndingYear = 2017;
            var season = new Season(validStartingYear, validEndingYear, Initiative.SoftwareAcademy);

            var trainerMock = new Mock<ITrainer>();
            trainerMock.Setup(x => x.ToString()).Verifiable();
            season.Trainers.Add(trainerMock.Object);
            // Act
            season.ListUsers();
            // Assert
            trainerMock.Verify(x => x.ToString(), Times.Once);
        }

        [Test]
        public void ListUsers_ShouldReturnNoUsersMessage_WhenNoLecturesPresent()
        {
            // Arrange
            int validStartingYear = 2016;
            int validEndingYear = 2017;
            var season = new Season(validStartingYear, validEndingYear, Initiative.SoftwareAcademy);
            // Act and Assert
            StringAssert.Contains("no users", season.ListUsers());
        }
    }
}
