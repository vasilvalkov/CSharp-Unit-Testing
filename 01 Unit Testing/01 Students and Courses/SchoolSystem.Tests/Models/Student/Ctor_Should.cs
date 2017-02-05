namespace SchoolSystem.Tests.Student
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using SchoolSystem;

    [TestClass]
    public class Ctor_Should
    {
        [TestMethod]
        [DataRow("", 1U)]
        [DataRow("   ", 1U)]
        [DataRow("\r\n", 1U)]
        [DataRow(null, 1U)]
        public void ThrowArgumentException_WhenPassedInvalidStringForName(string invalidName, uint validId)
        {   // Arrange, Act and Assert
            Assert.ThrowsException<ArgumentException>(() => new Student(invalidName, validId));
        }

        [TestMethod]
        public void AssignName_WhenPassedValidStringForName()
        {   // Arrange
            string validName = "Pesho Goshov";
            uint validId = 1U;
            // Act
            var student = new Student(validName, validId);
            // Assert
            Assert.AreEqual(validName, student.Name);
        }

        [TestMethod]
        public void AssignID_WhenPassedValidID()
        {   // Arrange
            string validName = "Pesho Goshov";
            uint validId = 1U;
            // Act
            var student = new Student(validName, validId);
            // Assert
            Assert.AreEqual(validId, student.ID);
        }
    }
}