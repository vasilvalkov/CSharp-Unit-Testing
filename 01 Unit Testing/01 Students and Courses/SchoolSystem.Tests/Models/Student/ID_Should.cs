namespace SchoolSystem.Tests.Student
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class ID_Should
    {
        [TestMethod]
        public void ReturnStudentIDCorrectly_WhenRuquestingFromGetter()
        {   // Arrange
            uint expected = 10;
            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(st => st.ID).Returns(expected);
            // Act and Assert
            Assert.AreEqual(expected, studentMock.Object.ID);
        }

        [TestMethod]
        public void BeCalledOnlyOnce_WhenRuquestingFromGetter()
        {   // Arrange
            uint expected = 10;
            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(st => st.ID).Returns(expected);
            // Act
            uint id = studentMock.Object.ID;
            // Assert
            studentMock.VerifyGet(st => st.ID, Times.Once);
        }
    }
}