namespace Academy.Tests.Models.SeasonTests
{
    using Academy.Models;
    using Academy.Models.Contracts;
    using Academy.Models.Enums;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ListCourses
    {
        [Test]
        public void ListCourses_ShouldReturnTheListOfCourses_WhenInvoked()
        {
            // Arrange
            int validStartingYear = 2016;
            int validEndingYear = 2017;
            var season = new Season(validStartingYear, validEndingYear, Initiative.SoftwareAcademy);

            var courseMock = new Mock<ICourse>();
            courseMock.Setup(x => x.ToString()).Verifiable();
            season.Courses.Add(courseMock.Object);
            // Act
            season.ListCourses();
            // Assert
            courseMock.Verify(x => x.ToString(), Times.Once);
        }

        [Test]
        public void ListCourses_ShouldReturnNoCoursesMessage_WhenNoCoursesPresent()
        {
            // Arrange
            int validStartingYear = 2016;
            int validEndingYear = 2017;
            var season = new Season(validStartingYear, validEndingYear, Initiative.SoftwareAcademy);
            // Act and Assert
            StringAssert.Contains("no courses", season.ListCourses());
        }
    }
}
