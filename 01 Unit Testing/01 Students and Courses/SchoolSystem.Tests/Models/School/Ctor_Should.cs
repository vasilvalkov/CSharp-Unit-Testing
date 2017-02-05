namespace SchoolSystem.Tests.School
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using SchoolSystem;

    [TestClass]
    public class Ctor_Should
    {
        [TestMethod]
        [DataRow("")]
        [DataRow("   ")]
        [DataRow("\r\n")]
        [DataRow(null)]
        public void ThrowArgumentException_WhenPassedInvalidStringForName(string invalidName)
        {   // Arrange, Act and Assert
            Assert.ThrowsException<ArgumentException>(() => new School(invalidName));
        }

        [TestMethod]
        public void SetName_WhenPassedValidStringForName()
        {   // Arrange and Act
            string validName = "Vasil Levski";
            var school = new School(validName);
            // Assert
            Assert.AreEqual(validName, school.Name);
        }

        [TestMethod]
        public void CreateNewListOfCourses_WhenInvoked()
        {   // Arrange and Act
            string validName = "Vasil Levski";
            var school = new School(validName);
            // Assert
            Assert.IsNotNull(school.Courses);
        }
    }
}
