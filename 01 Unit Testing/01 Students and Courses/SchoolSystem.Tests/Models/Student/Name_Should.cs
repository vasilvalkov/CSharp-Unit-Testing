namespace SchoolSystem.Tests.Student
{
    using Moq;
    using SchoolSystem;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Name_Should
    {
        [TestMethod]
        public void ReturnTheNameCorrectly_WhenRuquestingFromGetter()
        {   // Arrange
            string expected = "Gosho";
            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(st => st.Name).Returns(expected);
            // Act and Assert
            Assert.AreEqual(expected, studentMock.Object.Name);
        }

        [TestMethod]
        public void BeCalledOnlyOnce_WhenRuquestingFromGetter()
        {   // Arrange
            string expected = "Gosho";
            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(st => st.Name).Returns(expected);
            // Act
            string name = studentMock.Object.Name;
            // Assert
            studentMock.VerifyGet(st => st.Name, Times.Once);
        }
    }
}