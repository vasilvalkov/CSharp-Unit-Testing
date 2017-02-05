namespace SchoolSystem.Tests.Course
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using SchoolSystem;
    using Fakes;

    [TestClass]
    public class Ctor_Should
    {
        [TestMethod]
        [DataRow("", (byte)20)]
        [DataRow("   ", (byte)20)]
        [DataRow("\r\n", (byte)20)]
        [DataRow(null, (byte)20)]
        public void ThrowArgumentException_WhenPassedInvalidStringForName(string invalidName, byte validMaxStudents)
        {   // Arrange, Act and Assert
            Assert.ThrowsException<ArgumentException>(() => new Course(invalidName, validMaxStudents));
        }

        [TestMethod]
        public void AssignName_WhenPassedValidStringForName()
        {   // Arrange
            string validName = "C# Unit Testing";
            byte validMaxStudents = 30;
            // Act
            var course = new Course(validName, validMaxStudents);
            // Assert
            Assert.AreEqual(validName, course.Name);
        }

        [TestMethod]
        public void CreateNewHashSetForStudents_WhenInvoked()
        {   // Arrange
            string validName = "C# Unit Testing";
            byte validMaxStudents = 30;
            // Act
            var course = new Course(validName, validMaxStudents);
            Assert.IsNotNull(course.Students);
        }

        [TestMethod]
        public void CreateEmptyHashSetForStudents_WhenInvoked()
        {   // Arrange
            string validName = "C# Unit Testing";
            byte validMaxStudents = 30;
            int expected = 0;
            // Act
            var course = new Course(validName, validMaxStudents);
            Assert.AreEqual(expected, course.Students.Count);
        }

        [TestMethod]
        public void AssignMaxStudentsToField_WhenInvoked()
        {   // Arrange
            string validName = "C# Unit Testing";
            byte validMaxStudents = 30;
            // Act
            var course = new CourseFake(validName, validMaxStudents);
            //Assert
            Assert.AreEqual(validMaxStudents, course.MaxStudents);
        }
    }
}