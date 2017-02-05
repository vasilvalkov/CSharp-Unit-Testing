namespace SchoolSystem.Tests.School
{
    using SchoolSystem;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Name_Should
    {
        [TestMethod]
        public void ReturnTheNameCorrectly_WhenRuquestingFromGetter()
        {   // Arrange
            string expected = "Vasil Levski";
            var school = new School(expected);
            // Act and Assert
            Assert.AreEqual(expected, school.Name);
        }
    }
}