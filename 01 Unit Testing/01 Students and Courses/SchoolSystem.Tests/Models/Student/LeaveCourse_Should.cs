namespace SchoolSystem.Tests.Student
{
    using Fakes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SchoolSystem;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class LeaveCourse_Should
    {
        [TestMethod]
        public void ThrowNullReferenceException_WhenPassedNullCourse()
        {   // Arrange
            string validName = "Pesho Goshov";
            uint validId = 300;
            var student = new Student(validName, validId);
            // Act and Assert
            Assert.ThrowsException<NullReferenceException>(() => student.LeaveCourse(null));
        }

        [TestMethod]
        public void RemoveCourseFromCoursesOfTheStudent_WhenPassedValidCourse()
        {   // Arrange
            string validStudentName = "Pesho Goshov";
            uint validId = 300;
            var studentFake = new StudentFake(validStudentName, validId);
            var courseStub = new Mock<ICourse>().Object;
            studentFake.ExposedCourses = new List<ICourse> { courseStub };
            // Act
            studentFake.LeaveCourse(courseStub);
            // Assert
            Assert.IsFalse(studentFake.Courses.Contains(courseStub));
        }

        [TestMethod]
        public void RemoveStudentFromStudentsOfTheCourse_WhenPassedValidCourse()
        {   // Arrange
            string validStudentName = "Pesho Goshov";
            uint validId = 300;
            var student = new Student(validStudentName, validId);
            var courseMock = new Mock<ICourse>();
            // Act
            student.LeaveCourse(courseMock.Object);
            // Assert
            courseMock.Verify(x => x.RemoveStudent(It.IsAny<IStudent>()), Times.Once);
        }
    }
}