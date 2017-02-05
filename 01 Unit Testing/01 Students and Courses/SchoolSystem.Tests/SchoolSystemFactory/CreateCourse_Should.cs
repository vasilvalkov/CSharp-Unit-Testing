namespace SchoolSystem.Tests.SchoolSystemFactory
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using SchoolSystem;
    using SchoolSystem.Providers;
    using Moq;

    [TestClass]
    public class CreateCourse_Should
    {
        [TestMethod]
        [DataRow("")]
        [DataRow("   ")]
        [DataRow("\r\n")]
        [DataRow(null)]
        public void ThrowArgumentException_WhenPassedInvalidParameter(string name)
        {   // Arrange
            byte validMaxStudentsCount = 42;
            var idProviderStub = new Mock<IIdProvider>().Object;
            var factory = new SchoolSystemFactory(idProviderStub);
            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => factory.CreateCourse(name, validMaxStudentsCount));
        }

        [TestMethod]
        public void CreateCourseCorrectly_WhenInvokedWithValidParameters()
        {   // Arrange
            string validName = "C# Unit Testing";
            byte validMaxStudentsCount = 42;
            var idProviderStub = new Mock<IIdProvider>().Object;
            var factory = new SchoolSystemFactory(idProviderStub);
            // Act and Assert
            Assert.IsInstanceOfType(factory.CreateCourse(validName, validMaxStudentsCount), typeof(ICourse));
        }
    }
}