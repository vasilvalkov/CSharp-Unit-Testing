namespace SchoolSystem.Tests.School
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SchoolSystem;
    using System;

    [TestClass]
    public class AddCourses_Should
    {
        [TestMethod]
        public void ThrowNullReferenceException_WhenPassedNullParameter()
        {   // Arrange
            string validName = "Vasil Levski";
            var school = new School(validName);
            // Act and Assert
            Assert.ThrowsException<NullReferenceException>(() => school.AddCourses(null));
        }

        [TestMethod]
        public void ThrowNullReferenceException_WhenPassedArrayOfCoursesWithOneNullCourse()
        {   // Arrange
            string validName = "Vasil Levski";
            var school = new School(validName);
            var coursesStub = new ICourse[]
            {
                new Mock<ICourse>().Object,
                new Mock<ICourse>().Object,
                new Mock<ICourse>().Object,
                null
            };
            int expectedCount = coursesStub.Length;
            // Act and Assert
            Assert.ThrowsException<NullReferenceException>(() => school.AddCourses(coursesStub));
        }

        [TestMethod]
        public void ThrowNullReferenceException_WhenPassedCoursesAsSeparateParametersWithOneNullCourse()
        {   // Arrange
            string validName = "Vasil Levski";
            var school = new School(validName);
            var courseOneStub = new Mock<ICourse>();
            var courseTwoStub = new Mock<ICourse>();
            var courseThreeStub = new Mock<ICourse>();
            // Act and Assert
            Assert.ThrowsException<NullReferenceException>(() => school.AddCourses(courseOneStub.Object, courseTwoStub.Object, null, courseThreeStub.Object));
        }

        [TestMethod]
        public void AddASingleCourse_WhenPassedASingleCourseAsParameter()
        {   // Arrange
            string validName = "Vasil Levski";
            var school = new School(validName);
            var courseStub = new Mock<ICourse>();
            int expectedCount = 1;
            // Act 
            school.AddCourses(courseStub.Object);
            // Assert
            Assert.AreEqual(expectedCount, school.Courses.Count);
        }

        [TestMethod]
        public void AddAllCourses_WhenPassedArrayOfCoursesAsParameter()
        {   // Arrange
            string validName = "Vasil Levski";
            var school = new School(validName);
            var coursesStub = new ICourse[]
            {
                new Mock<ICourse>().Object,
                new Mock<ICourse>().Object,
                new Mock<ICourse>().Object,
                new Mock<ICourse>().Object
            };
            int expectedCount = coursesStub.Length;
            // Act 
            school.AddCourses(coursesStub);
            // Assert
            Assert.AreEqual(expectedCount, school.Courses.Count);
        }

        [TestMethod]
        public void AddAllCourses_WhenPassedAsSeparateParameters()
        {   // Arrange
            string validName = "Vasil Levski";
            var school = new School(validName);
            var courseOneStub = new Mock<ICourse>();
            var courseTwoStub = new Mock<ICourse>();
            var courseThreeStub = new Mock<ICourse>();
            int expectedCount = 3;
            // Act 
            school.AddCourses(courseOneStub.Object, courseTwoStub.Object, courseThreeStub.Object);
            // Assert
            Assert.AreEqual(expectedCount, school.Courses.Count);
        }
    }
}
