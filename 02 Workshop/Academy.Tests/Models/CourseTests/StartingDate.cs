namespace Academy.Tests.Models.CourseTests
{
    using Academy.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class StartingDate
    {
        [Test]
        public void StartingDateGetter_ShouldReturnStartingDateCorreclty()
        {
            // Arrange
            string validCourseName = "C# Unit Testing";
            int validLecturesCount = 3;
            DateTime validStartDate = new DateTime(2017, 2, 10);
            DateTime validEndDate = new DateTime(2017, 3, 20);
            var course = new Course(validCourseName, validLecturesCount, validStartDate, validEndDate);
            // Act and Assert
            Assert.AreEqual(validStartDate, course.StartingDate);
        }

        [Test]
        public void StartingDateSetter_ShouldAssignCorrectly_WhenPassedValidDate()
        {
            // Arrange
            string validCourseName = "C# Unit Testing";
            int validLecturesCount = 3;
            DateTime validStartDate = new DateTime(2017, 2, 10);
            DateTime validEndDate = new DateTime(2017, 3, 20);
            var course = new Course(validCourseName, validLecturesCount, validStartDate, validEndDate);

            DateTime newValidStartDate = new DateTime(2017, 2, 15);
            // Act
            course.StartingDate = newValidStartDate;
            // Assert
            Assert.AreEqual(newValidStartDate, course.StartingDate);
        }

        [Test]
        public void StartingDateSetter_ShouldThrowArgumentNullException_WhenPassedNullDate()
        {
            // Arrange
            string validCourseName = "C# Unit Testing";
            int validLecturesCount = 3;
            DateTime validStartDate = new DateTime(2017, 2, 10);
            DateTime validEndDate = new DateTime(2017, 3, 20);
            var course = new Course(validCourseName, validLecturesCount, validStartDate, validEndDate);
            // Act and Assert
            Assert.Throws<ArgumentNullException>(
                () => course.StartingDate = null);
        }

        [Test]
        public void StartingDateSetter_ShouldNotThrow_WhenPassedValidDate()
        {
            // Arrange
            string validCourseName = "C# Unit Testing";
            int validLecturesCount = 3;
            DateTime validStartDate = new DateTime(2017, 2, 10);
            DateTime validEndDate = new DateTime(2017, 3, 20);
            var course = new Course(validCourseName, validLecturesCount, validStartDate, validEndDate);

            DateTime newValidStartDate = new DateTime(2017, 2, 15);
            // Act and Assert
            Assert.DoesNotThrow(
                () => course.StartingDate = newValidStartDate);
        }
    }
}
