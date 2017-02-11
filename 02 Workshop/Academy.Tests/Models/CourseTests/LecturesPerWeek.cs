namespace Academy.Tests.Models.CourseTests
{
    using Academy.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class LecturesPerWeek
    {
        [Test]
        public void LecturesPerWeekGetter_ShouldReturnLecturesPerWeekCountCorreclty()
        {
            // Arrange
            string validCourseName = "C# Unit Testing";
            int validLecturesCount = 3;
            DateTime validStartDate = new DateTime(2017, 2, 10);
            DateTime validEndDate = new DateTime(2017, 3, 20);
            var course = new Course(validCourseName, validLecturesCount, validStartDate, validEndDate);
            // Act and Assert
            Assert.AreEqual(validLecturesCount, course.LecturesPerWeek);
        }

        [Test]
        public void LecturesPerWeekSetter_ShouldAssignCorrectly_WhenPassedValidValue()
        {
            // Arrange
            string validCourseName = "C# Unit Testing";
            int validLecturesCount = 3;
            int newValidLecturesCount = 4;
            DateTime validStartDate = new DateTime(2017, 2, 10);
            DateTime validEndDate = new DateTime(2017, 3, 20);
            var course = new Course(validCourseName, validLecturesCount, validStartDate, validEndDate);
            // Act
            course.LecturesPerWeek = newValidLecturesCount;
            // Assert
            Assert.AreEqual(newValidLecturesCount, course.LecturesPerWeek);
        }

        [Test]
        public void LecturesPerWeekSetter_ShouldNotThrow_WhenPassedValidValue()
        {
            // Arrange
            string validCourseName = "C# Unit Testing";
            int validLecturesCount = 3;
            int newValidLecturesCount = 4;
            DateTime validStartDate = new DateTime(2017, 2, 10);
            DateTime validEndDate = new DateTime(2017, 3, 20);
            var course = new Course(validCourseName, validLecturesCount, validStartDate, validEndDate);
            // Act and Assert
            Assert.DoesNotThrow(
                () => course.LecturesPerWeek = newValidLecturesCount);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(8)]
        public void LecturesPerWeekSetter_ShouldThrowArgumentException_WhenPassedOutOfRangeValue(int invalidValue)
        {
            // Arrange
            string validCourseName = "C# Unit Testing";
            int validLecturesCount = 3;
            DateTime validStartDate = new DateTime(2017, 2, 10);
            DateTime validEndDate = new DateTime(2017, 3, 20);
            var course = new Course(validCourseName, validLecturesCount, validStartDate, validEndDate);
            // Act and Assert
            Assert.Throws<ArgumentException>(
                () => course.LecturesPerWeek = invalidValue);
        }
    }
}
