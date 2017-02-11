namespace Academy.Tests.Models.CourseTests
{
    using Academy.Models;
    using Academy.Models.Contracts;
    using Moq;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ToString
    {
        [Test]
        public void ToString_ShouldReturnTheListOfLectures_WhenInvoked()
        {
            // Arrange
            string validCourseName = "C# Unit Testing";
            int validLecturesCount = 3;
            DateTime validStartDate = new DateTime(2017, 2, 10);
            DateTime validEndDate = new DateTime(2017, 3, 10);
            var course = new Course(validCourseName, validLecturesCount, validStartDate, validEndDate);

            var lectureMock = new Mock<ILecture>();
            lectureMock.Setup(x => x.ToString()).Verifiable();
            course.Lectures.Add(lectureMock.Object);
            // Act
            course.ToString();
            // Assert
            lectureMock.Verify(x => x.ToString(), Times.Once);            
        }

        [Test]
        public void ToString_ShouldReturnTheMessageNoLectures_WhenNoLecturesPresent()
        {
            // Arrange
            string validCourseName = "C# Unit Testing";
            int validLecturesCount = 3;
            DateTime validStartDate = new DateTime(2017, 2, 10);
            DateTime validEndDate = new DateTime(2017, 3, 20);
            var course = new Course(validCourseName, validLecturesCount, validStartDate, validEndDate);
            // Act and Assert
            StringAssert.Contains("no lectures", course.ToString());
        }
    }
}
