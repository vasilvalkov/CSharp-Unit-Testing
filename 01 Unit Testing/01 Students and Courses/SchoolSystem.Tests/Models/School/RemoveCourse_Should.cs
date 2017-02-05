namespace SchoolSystem.Tests.School
{
    using Fakes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SchoolSystem;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class RemoveCourse_Should
    {
        [TestMethod]
        public void ThrowNullReferenceException_WhenPassedNullParameter()
        {   // Arrange
            string validName = "Vasil Levski";
            var school = new School(validName);
            // Act and Assert
            Assert.ThrowsException<NullReferenceException>(() => school.RemoveCourse(null));
        }

        [TestMethod]
        public void ThrowInvalidOperationException_WhenPassedCourseDoesNotExistInSchoolCourses()
        {   // Arrange
            string validName = "Vasil Levski";
            var schoolFake = new SchoolFake(validName);
            var existingCourseStub = new Mock<ICourse>().Object;
            var nonexistingCourseStub = new Mock<ICourse>().Object;

            schoolFake.ExposedCourses = new List<ICourse> { existingCourseStub};
            // Act and Assert
            Assert.ThrowsException<InvalidOperationException>(() => schoolFake.RemoveCourse(nonexistingCourseStub));
        }

        [TestMethod]
        public void RemovePassedCourseFromCourses_WhenCourseExists()
        {   // Arrange
            string validName = "Vasil Levski";
            var schoolFake = new SchoolFake(validName);
            int expectedCoursesCount = 1;
            var courseOneStub = new Mock<ICourse>().Object;
            var courseTwoStub = new Mock<ICourse>().Object;
            schoolFake.ExposedCourses = new List<ICourse> { courseOneStub, courseTwoStub };
            // Act
            schoolFake.RemoveCourse(courseOneStub);
            // Assert
            Assert.AreEqual(expectedCoursesCount, schoolFake.Courses.Count);
        }
    }
}
