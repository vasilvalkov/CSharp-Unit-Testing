namespace SchoolSystem.Tests.School
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem;
    using System.Collections.Generic;

    [TestClass]
    public class Courses_Should
    {
        [TestMethod]
        public void ReturnAListOfTheCourses_WhenInvoked()
        {   // Arrange
            string validName = "Vasil Levski";
            var school = new School(validName);
            var expected = new List<ICourse>();
            // Act and Assert
            Assert.IsInstanceOfType(school.Courses, typeof(List<ICourse>));
        }
    }
}
