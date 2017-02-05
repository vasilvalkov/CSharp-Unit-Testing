namespace SchoolSystem.Tests.Course
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SchoolSystem;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class RemoveStudent_Should
    {
        [TestMethod]
        public void RemoveStudentSuccessfuly_WhenPassedStudentIsInTheCourse()
        {   // Arrange
            var studentStub = new Mock<IStudent>();
            var course = new Course("C# Unit Testing", 29);
            course.Students = new HashSet<IStudent> { studentStub.Object };
            // Act
            course.RemoveStudent(studentStub.Object);
            // Act and Assert
            Assert.IsTrue(course.Students.Count == 0);
        }

        [TestMethod]
        public void ThrowArgumentException_WhenPassedStudentIsNotJoinedToCourse()
        {   // Arrange
            var studentOneStub = new Mock<IStudent>();
            var studentTwoStub = new Mock<IStudent>();
            var course = new Course("C# Unit Testing", 29);
            course.Students = new HashSet<IStudent> { studentOneStub.Object };
            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => course.RemoveStudent(studentTwoStub.Object));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenCourseHasNoStudents()
        {   // Arrange
            var studentStub = new Mock<IStudent>();
            var course = new Course("C# Unit Testing", 29);
            course.Students = new HashSet<IStudent>();
            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => course.RemoveStudent(studentStub.Object));
        }

        [TestMethod]
        public void ThrowNullReferenceException_WhenPassedNullStudent()
        {   // Arrange
            var course = new Course("C# Unit Testing", 29);
            // Act and Assert
            Assert.ThrowsException<NullReferenceException>(() => course.RemoveStudent(null));
        }
    }
}