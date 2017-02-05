namespace SchoolSystem.Tests.Course
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SchoolSystem;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class AddStudent_Should
    {
        [TestMethod]
        public void AddStudentCorrectly_WhenPassedValidStudent()
        {   // Arrange
            var course = new Course("C# Unit Testing", 29);
            var studentStub = new Mock<IStudent>().Object;
            // Act
            course.AddStudent(studentStub);
            // Assert
            Assert.AreEqual(course.Students.First(), studentStub);
        }
        [TestMethod]
        public void ThrowInvalidOperationException_WhenNoMoreStudentsCanJoinTheCourse()
        {   // Arrange
            var course = new Course("C# Unit Testing", 29);
            var studentStub = new Mock<IStudent>();
            var studentsSetStub = new HashSet<IStudent>();
            uint call = 10000;

            for (int i = 0; i < 29; i++)
            {
                var stub = new Mock<IStudent>();
                stub.Setup(st => st.Name).Returns(() => "Pesho" + call);
                stub.Setup(st => st.ID).Returns(call);
                studentsSetStub.Add(stub.Object);
                call++;
            }
            course.Students = studentsSetStub;
            // Act and Assert
            Assert.ThrowsException<InvalidOperationException>(() => course.AddStudent(studentStub.Object));
        }
        [TestMethod]
        public void ThrowNullReferenceException_WhenPassedNullStudent()
        {   // Arrange
            var course = new Course("C# Unit Testing", 29);
            // Act and Assert
            Assert.ThrowsException<NullReferenceException>(() => course.AddStudent(null));
        }
    }
}