namespace SchoolSystem.Tests.Course
{
    using SchoolSystem;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class Name_Should
    {
        [TestMethod]
        public void ThrowArgumentException_WhenPassedNullOrEmptyString()
        {   // Arrange, Act and Assert
            Assert.ThrowsException<ArgumentException>(() => new Course("", 29));
        }
        [TestMethod]
        public void CreateCourseCorrectly_WhenPassedValidString()
        {   // Arrange
            string courseName = "C# Unit Testing";
            byte maxStudents = 29;
            // Act
            var course = new Course(courseName, maxStudents);
            // Assert
            Assert.AreEqual(course.Name, courseName);
        }
    }
}
