namespace SchoolSystem.Tests.Course
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SchoolSystem;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class Students_Should
    {
        [TestMethod]
        public void NotBeNull_WhenCourseObjectIsCreated()
        {   // Arrange
            var course = new Course("C# Unit Testing", 29);
            // Assert
            Assert.IsNotNull(course.Students);
        }
        [TestMethod]
        public void ThrowNullReferenceException_WhenTryingToSetNullValue()
        {   // Arrange
            var course = new Course("C# Unit Testing", 29);
            // Act and Assert
            Assert.ThrowsException<NullReferenceException>(() => course.Students = null);
        }
        [TestMethod]
        public void ThrowInvalidOperationException_WhenPassedStudentsCountExceedsCourseMaxStudentsCount()
        {   // Arrange
            byte maxStudentsForTheCourse = 4;
            var course = new Course("C# Unit Testing", maxStudentsForTheCourse);
            var studentStub = new Mock<IStudent>();
            var studentsSetStub = new HashSet<IStudent>();
            uint call = 10000;

            for (int i = 0; i < maxStudentsForTheCourse + 1; i++)
            {
                var stub = new Mock<IStudent>();
                stub.Setup(st => st.Name).Returns(() => "Pesho" + call);
                stub.Setup(st => st.ID).Returns(call);
                studentsSetStub.Add(stub.Object);
                call++;
            }
            // Act and Assert
            Assert.ThrowsException<InvalidOperationException>(() => course.Students = studentsSetStub);
        }
    }
}
