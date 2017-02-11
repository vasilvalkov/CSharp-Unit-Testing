namespace Academy.Tests.Models.CourseTests
{
    using Academy.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class EndingDate
    {
        [Test]
        public void EndingDateGetter_ShouldReturnEndingDateCorreclty()
        {
            // Arrange
            string validCourseName = "C# Unit Testing";
            int validLecturesCount = 3;
            DateTime validStartDate = new DateTime(2017, 2, 10);
            DateTime validEndDate = new DateTime(2017, 3, 20);
            var course = new Course(validCourseName, validLecturesCount, validStartDate, validEndDate);
            // Act and Assert
            Assert.AreEqual(validEndDate, course.EndingDate);
        }

        [Test]
        public void EndingDateSetter_ShouldAssignCorrectly_WhenPassedValidDate()
        {
            // Arrange
            string validCourseName = "C# Unit Testing";
            int validLecturesCount = 3;
            DateTime validStartDate = new DateTime(2017, 2, 10);
            DateTime validEndDate = new DateTime(2017, 3, 20);
            var course = new Course(validCourseName, validLecturesCount, validStartDate, validEndDate);

            DateTime newValidEndtDate = new DateTime(2017, 4, 15);
            // Act
            course.EndingDate = newValidEndtDate;
            // Assert
            Assert.AreEqual(newValidEndtDate, course.EndingDate);
        }

        [Test]
        public void EndingDateSetter_ShouldThrowArgumentNullException_WhenPassedNullDate()
        {
            // Arrange
            string validCourseName = "C# Unit Testing";
            int validLecturesCount = 3;
            DateTime validStartDate = new DateTime(2017, 2, 10);
            DateTime validEndDate = new DateTime(2017, 3, 20);
            var course = new Course(validCourseName, validLecturesCount, validStartDate, validEndDate);
            // Act and Assert
            Assert.Throws<ArgumentNullException>(
                () => course.EndingDate = null);
        }

        [Test]
        public void EndingDateSetter_ShouldNotThrow_WhenPassedValidDate()
        {
            // Arrange
            string validCourseName = "C# Unit Testing";
            int validLecturesCount = 3;
            DateTime validStartDate = new DateTime(2017, 2, 10);
            DateTime validEndDate = new DateTime(2017, 3, 20);
            var course = new Course(validCourseName, validLecturesCount, validStartDate, validEndDate);

            DateTime newValidEndDate = new DateTime(2017, 2, 15);
            // Act and Assert
            Assert.DoesNotThrow(
                () => course.EndingDate = newValidEndDate);
        }
    }
}
