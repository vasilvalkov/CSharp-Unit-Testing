namespace SchoolSystem.Tests.SchoolSystemFactory
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using SchoolSystem;
    using SchoolSystem.Providers;
    using Moq;

    [TestClass]
    public class CreateStudent_Should
    {
        [TestMethod]
        [DataRow("")]
        [DataRow("   ")]
        [DataRow("\r\n")]
        [DataRow(null)]
        public void ThrowArgumentException_WhenPassedInvalidParameter(string name)
        {   // Arrange
            var idProviderStub = new Mock<IIdProvider>().Object;
            var factory = new SchoolSystemFactory(idProviderStub);
            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => factory.CreateStudent(name));
        }

        [TestMethod]
        public void CreateStudentCorrectly_WhenInvokedWithValidParameter()
        {   // Arrange
            string validName = "Pesho Goshov";
            var idProviderStub = new Mock<IIdProvider>().Object;
            var factory = new SchoolSystemFactory(idProviderStub);
            // Act and Assert
            Assert.IsInstanceOfType(factory.CreateStudent(validName), typeof(IStudent));
        }
    }
}
