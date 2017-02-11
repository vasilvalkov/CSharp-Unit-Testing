namespace Academy.Tests.Commands.Adding.AddStudentToCourseCommandTests
{
    using Academy.Commands.Adding;
    using Academy.Core.Contracts;
    using Academy.Models.Contracts;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class Execute
    {
        [TestCase("")]
        [TestCase("on-line")]
        [TestCase("free")]
        public void Execute_ShouldThrowArgumentException_WhenPassedCourseFormIsInvalid(string form)
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();
            var command = new AddStudentToCourseCommand(factoryStub.Object, engineStub.Object);

            var studentStub = new Mock<IStudent>();
            var seasonStub = new Mock<ISeason>();
            var courseStub = new Mock<ICourse>();

            studentStub.SetupGet(s => s.Username).Returns("Pesho");
            seasonStub.SetupGet(s => s.Students).Returns(new List<IStudent> { studentStub.Object });
            seasonStub.SetupGet(s => s.Courses).Returns(new List<ICourse> { courseStub.Object });

            engineStub.SetupGet(e => e.Students).Returns(new List<IStudent> { studentStub.Object });
            engineStub.SetupGet(e => e.Seasons).Returns(new List<ISeason> { seasonStub.Object });

            string validStudentUsername = "Pesho";
            string ValidSeasonId = "0";
            string ValidCourseId = "0";
            var parameters = new List<string> { validStudentUsername, ValidSeasonId, ValidCourseId, form };
            // Act and Assert
            Assert.Throws<ArgumentException>(() => command.Execute(parameters));
        }

        [TestCase("Online")]
        [TestCase("online")]
        [TestCase("Onsite")]
        [TestCase("onsite")]
        public void Execute_ShouldNotThrowArgumentException_WhenPassedCourseFormIsValid(string form)
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();
            var command = new AddStudentToCourseCommand(factoryStub.Object, engineStub.Object);

            var studentStub = new Mock<IStudent>();
            var seasonStub = new Mock<ISeason>();
            var courseStub = new Mock<ICourse>();

            studentStub.SetupGet(s => s.Username).Returns("Pesho");
            seasonStub.SetupGet(s => s.Students).Returns(new List<IStudent> { studentStub.Object });
            seasonStub.SetupGet(s => s.Courses).Returns(new List<ICourse> { courseStub.Object });
            courseStub.SetupGet(c => c.OnlineStudents).Returns(new List<IStudent>());
            courseStub.SetupGet(c => c.OnsiteStudents).Returns(new List<IStudent>());

            engineStub.SetupGet(e => e.Students).Returns(new List<IStudent> { studentStub.Object });
            engineStub.SetupGet(e => e.Seasons).Returns(new List<ISeason> { seasonStub.Object });

            string validStudentUsername = "Pesho";
            string validSeasonId = "0";
            string validCourseId = "0";
            var parameters = new List<string> { validStudentUsername, validSeasonId, validCourseId, form };
            // Act and Assert
            Assert.DoesNotThrow(() => command.Execute(parameters));
        }

        [Test]
        public void Execute_ShouldCorrectlyAddStudentIntoCourseInTheOnlineForm_WhenPassedCourseFormIsOnline()
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var command = new AddStudentToCourseCommand(factoryStub.Object, engineMock.Object);

            var studentStub = new Mock<IStudent>();
            var seasonStub = new Mock<ISeason>();
            var courseStub = new Mock<ICourse>();

            studentStub.SetupGet(s => s.Username).Returns("Pesho");

            seasonStub.SetupGet(s => s.Students).Returns(new List<IStudent> { studentStub.Object });
            seasonStub.SetupGet(s => s.Courses).Returns(new List<ICourse> { courseStub.Object });

            courseStub.SetupGet(c => c.OnlineStudents).Returns(new List<IStudent>());

            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent> { studentStub.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason> { seasonStub.Object });

            string validStudentUsername = "Pesho";
            string validSeasonId = "0";
            string validCourseId = "0";
            string validForm = "online";
            var parameters = new List<string> { validStudentUsername, validSeasonId, validCourseId, validForm };
            // Act 
            command.Execute(parameters);
            // Assert
            Assert.AreSame(studentStub.Object.Username, engineMock.Object.Seasons[0].Courses[0].OnlineStudents[0].Username);
        }

        [Test]
        public void Execute_ShouldCorrectlyAddStudentIntoCourseInTheOnsiteForm_WhenPassedCourseFormIsOnsite()
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var command = new AddStudentToCourseCommand(factoryStub.Object, engineMock.Object);

            var studentStub = new Mock<IStudent>();
            var seasonStub = new Mock<ISeason>();
            var courseStub = new Mock<ICourse>();

            studentStub.SetupGet(s => s.Username).Returns("Pesho");

            seasonStub.SetupGet(s => s.Students).Returns(new List<IStudent> { studentStub.Object });
            seasonStub.SetupGet(s => s.Courses).Returns(new List<ICourse> { courseStub.Object });

            courseStub.SetupGet(c => c.OnsiteStudents).Returns(new List<IStudent>());

            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent> { studentStub.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason> { seasonStub.Object });

            string validStudentUsername = "Pesho";
            string validSeasonId = "0";
            string validCourseId = "0";
            string validForm = "onsite";
            var parameters = new List<string> { validStudentUsername, validSeasonId, validCourseId, validForm };
            // Act 
            command.Execute(parameters);
            // Assert
            Assert.AreSame(studentStub.Object, engineMock.Object.Seasons[0].Courses[0].OnsiteStudents[0]);
        }

        [Test]
        public void Execute_ShouldCorrectlyFindStudentbyUsername_WhenPassedUsernameWithDifferentCasing()
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var command = new AddStudentToCourseCommand(factoryStub.Object, engineMock.Object);

            var studentStub = new Mock<IStudent>();
            var seasonStub = new Mock<ISeason>();
            var courseStub = new Mock<ICourse>();

            studentStub.SetupGet(s => s.Username).Returns("peShO");

            seasonStub.SetupGet(s => s.Students).Returns(new List<IStudent> { studentStub.Object });
            seasonStub.SetupGet(s => s.Courses).Returns(new List<ICourse> { courseStub.Object });

            courseStub.SetupGet(c => c.OnsiteStudents).Returns(new List<IStudent>());

            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent> { studentStub.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason> { seasonStub.Object });

            string validStudentUsername = "Pesho";
            string validSeasonId = "0";
            string validCourseId = "0";
            string validForm = "onsite";
            var parameters = new List<string> { validStudentUsername, validSeasonId, validCourseId, validForm };
            // Act 
            command.Execute(parameters);
            // Assert
            Assert.AreSame(studentStub.Object, engineMock.Object.Seasons[0].Courses[0].OnsiteStudents[0]);
        }

        [Test]
        public void Execute_ShouldReturnSuccessMessageContainingStudentUsernameAndSeasonId_WhenStudentIsAdded()
        {
            // Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var command = new AddStudentToCourseCommand(factoryStub.Object, engineMock.Object);

            var studentStub = new Mock<IStudent>();
            var seasonStub = new Mock<ISeason>();
            var courseStub = new Mock<ICourse>();

            studentStub.SetupGet(s => s.Username).Returns("Pesho");

            seasonStub.SetupGet(s => s.Students).Returns(new List<IStudent> { studentStub.Object });
            seasonStub.SetupGet(s => s.Courses).Returns(new List<ICourse> { courseStub.Object });

            courseStub.SetupGet(c => c.OnsiteStudents).Returns(new List<IStudent>());

            engineMock.SetupGet(e => e.Students).Returns(new List<IStudent> { studentStub.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason> { seasonStub.Object });

            string validStudentUsername = "Pesho";
            string validSeasonId = "0";
            string validCourseId = "0";
            string validForm = "onsite";
            var parameters = new List<string> { validStudentUsername, validSeasonId, validCourseId, validForm };
            // Act 
            string resultMessage = command.Execute(parameters);
            // Assert
            StringAssert.Contains(validStudentUsername, resultMessage);
            StringAssert.Contains(validSeasonId, resultMessage);
        }
    }
}
