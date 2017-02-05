namespace SchoolSystem.Tests.Student
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SchoolSystem;
    using System;
    using System.Linq;

    [TestClass]
    public class JoinCourse_Should
    {
        [TestMethod]
        public void ThrowNUllReferenceException_WhenPassedNullCourse()
        {   // Arrange
            string validName = "Pesho Goshov";
            uint validId = 300;
            var student = new Student(validName, validId);
            // Act and Assert
            Assert.ThrowsException<NullReferenceException>(() => student.JoinCourse(null));
        }

        [TestMethod]
        public void AddCourseToCoursesOfTheStudent_WhenPassedValidCourse()
        {   // Arrange
            string validStudentName = "Pesho Goshov";
            uint validId = 300;
            var student = new Student(validStudentName, validId);
            var courseStub = new Mock<ICourse>().Object;
            // Act
            student.JoinCourse(courseStub);
            // Assert
            Assert.AreSame(courseStub, student.Courses.FirstOrDefault());
        }

        [TestMethod]
        public void AddStudentToStudentsOfTheCourse_WhenPassedValidCourse()
        {   // Arrange
            string validStudentName = "Pesho Goshov";
            uint validId = 300;
            var student = new Student(validStudentName, validId);
            var courseMock = new Mock<ICourse>();
            // Act
            student.JoinCourse(courseMock.Object);
            // Assert
            courseMock.Verify(x => x.AddStudent(It.IsAny<IStudent>()), Times.Once);
        }
    }
}