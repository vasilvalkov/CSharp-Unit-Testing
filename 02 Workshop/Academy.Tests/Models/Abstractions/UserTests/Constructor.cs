namespace Academy.Tests.Models.Abstractions.UserTests
{
    using Fakes;
    using NUnit.Framework;

    [TestFixture]
    public class Constructor
    {
        [Test]
        public void Ctor_ShouldSetPassedParametersCorrectly_WhenParametersAreValid()
        {
            // Arrange
            string validUserName = "Pesho Goshov";
            // Act
            var fakeUser = new UserFake(validUserName);
            // Assert
            Assert.AreSame(validUserName, fakeUser.Username);
        }
    }
}