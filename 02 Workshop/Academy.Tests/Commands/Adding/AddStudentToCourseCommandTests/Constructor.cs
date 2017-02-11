namespace Academy.Tests.Commands.Adding.AddStudentToCourseCommandTests
{
    using Academy.Commands.Adding;
    using Academy.Core.Contracts;
    using Fakes;
    using Moq;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Constructor
    {
        [Test]
        public void Ctor_ShouldThrowArgumentNullException_WhenPassedNullFactory()
        {
            // Arrange
            var engineStub = new Mock<IEngine>().Object;
            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(null, engineStub));
        }

        [Test]
        public void Ctor_ShouldThrowArgumentNullException_WhenPassedNullEngine()
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>().Object;
            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(factoryStub, null));
        }

        [Test]
        public void Ctor_ShouldAssignFactoryToField_WhenPassedValidFactory()
        {
            // Arrange
            var validFactoryStub = new Mock<IAcademyFactory>().Object;
            var validEngineStub = new Mock<IEngine>().Object;
            // Act
            var command = new AddStudentToCourseCommandFake(validFactoryStub, validEngineStub);
            // Assert
            Assert.AreSame(validFactoryStub, command.Factory);
        }

        [Test]
        public void Ctor_ShouldAssignEngineToField_WhenPassedValidEngine()
        {
            // Arrange
            var validFactoryStub = new Mock<IAcademyFactory>().Object;
            var validEngineStub = new Mock<IEngine>().Object;
            // Act
            var command = new AddStudentToCourseCommandFake(validFactoryStub, validEngineStub);
            // Assert
            Assert.AreSame(validEngineStub, command.Engine);
        }
    }
}
