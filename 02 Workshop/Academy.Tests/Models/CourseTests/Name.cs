namespace Academy.Tests.Models.CourseTests
{
    using Academy.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Name
    {
        [Test]
        public void NameGetter_ShouldReturnCourseName_WhenInvoked()
        {
            // Arrange
            string validCourseName = "C# Unit Testing";
            int validLecturesCount = 3;
            DateTime validStartDate = new DateTime(2017, 2, 10);
            DateTime validEndDate = new DateTime(2017, 3, 20);
            // Act
            var course = new Course(validCourseName, validLecturesCount, validStartDate, validEndDate);
            // Assert
            Assert.AreSame(validCourseName, course.Name);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("      ")]
        [TestCase("\r\n")]
        public void NameSetter_ShouldThrowArgumentException_WhenPassedNullOrWhitespaceString(string val)
        {
            // Arrange
            string invalidCourseName = val;
            int validLecturesCount = 3;
            DateTime validStartDate = new DateTime(2017, 2, 10);
            DateTime validEndDate = new DateTime(2017, 3, 20);
            // Act and Assert
            Assert.Throws<ArgumentException>(
                () => new Course(invalidCourseName, validLecturesCount, validStartDate, validEndDate));
        }

        [TestCase(2)]
        [TestCase(46)]
        public void NameSetter_ShouldThrowArgumentException_WhenPassedStringWithInvalidLength(int invalidLength)
        {
            // Arrange
            string courseNameWithInvalidLength = new string('c', invalidLength);
            int validLecturesCount = 3;
            DateTime validStartDate = new DateTime(2017, 2, 10);
            DateTime validEndDate = new DateTime(2017, 3, 20);
            // Act and Assert
            Assert.Throws<ArgumentException>(
                () => new Course(courseNameWithInvalidLength, validLecturesCount, validStartDate, validEndDate));
        }

        [Test]
        public void NameSetter_ShouldNotThrow_WhenPassedValidString()
        {
            // Arrange
            string validCourseName = "C# Unit Testing";
            string newValidCourseName = "C# Unit Testing with Moq and NUnit";
            int validLecturesCount = 3;
            DateTime validStartDate = new DateTime(2017, 2, 10);
            DateTime validEndDate = new DateTime(2017, 3, 20);
            var course = new Course(validCourseName, validLecturesCount, validStartDate, validEndDate);
            // Act and Assert
            Assert.DoesNotThrow(
                () => course.Name = newValidCourseName);
        }

        [Test]
        public void Namesetter_ShouldAssignCorrectly_WhenPassedValidString()
        {
            // Arrange
            string validCourseName = "C# Unit Testing";
            string newValidCourseName = "C# Unit Testing with Moq and NUnit";
            int validLecturesCount = 3;
            DateTime validStartDate = new DateTime(2017, 2, 10);
            DateTime validEndDate = new DateTime(2017, 3, 20);
            var course = new Course(validCourseName, validLecturesCount, validStartDate, validEndDate);
            // Act
            course.Name = newValidCourseName;
            // Assert
            Assert.AreSame(newValidCourseName, course.Name);
        }
    }
}
