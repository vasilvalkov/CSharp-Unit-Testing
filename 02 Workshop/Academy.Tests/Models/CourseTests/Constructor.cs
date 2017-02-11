namespace Academy.Tests.Models.CourseTests
{
    using Academy.Models;
    using Academy.Models.Contracts;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class Constructor
    {
        [Test]
        public void Ctor_ShouldSetPassedParametersCorrectly_WhenParametersAreValid()
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
            Assert.AreEqual(validLecturesCount, course.LecturesPerWeek);
            Assert.AreEqual(validStartDate, course.StartingDate);
            Assert.AreEqual(validEndDate, course.EndingDate);
        }

        [Test]
        public void Ctor_ShouldInitializeLecturesWithNewEmptyList_WhenCreatingNewCourseObject()
        {
            // Arrange
            string validCourseName = "C# Unit Testing";
            int validLecturesCount = 3;
            DateTime validStartDate = new DateTime(2017, 2, 10);
            DateTime validEndDate = new DateTime(2017, 3, 20);
            var expected = new List<ILecture>();
            // Act
            var course = new Course(validCourseName, validLecturesCount, validStartDate, validEndDate);
            // Assert
            Assert.AreEqual(expected, course.Lectures);
        }

        [Test]
        public void Ctor_ShouldInitializeOnlineStudentsWithNewEmptyList_WhenCreatingNewCourseObject()
        {
            // Arrange
            string validCourseName = "C# Unit Testing";
            int validLecturesCount = 3;
            DateTime validStartDate = new DateTime(2017, 2, 10);
            DateTime validEndDate = new DateTime(2017, 3, 20);
            var expected = new List<IStudent>();
            // Act
            var course = new Course(validCourseName, validLecturesCount, validStartDate, validEndDate);
            // Assert
            Assert.AreEqual(expected, course.OnlineStudents);
        }

        [Test]
        public void Ctor_ShouldInitializeOnsiteStudentsWithNewEmptyList_WhenCreatingNewCourseObject()
        {
            // Arrange
            string validCourseName = "C# Unit Testing";
            int validLecturesCount = 3;
            DateTime validStartDate = new DateTime(2017, 2, 10);
            DateTime validEndDate = new DateTime(2017, 3, 20);
            var expected = new List<IStudent>();
            // Act
            var course = new Course(validCourseName, validLecturesCount, validStartDate, validEndDate);
            // Assert
            Assert.AreEqual(expected, course.OnsiteStudents);
        }
    }
}
