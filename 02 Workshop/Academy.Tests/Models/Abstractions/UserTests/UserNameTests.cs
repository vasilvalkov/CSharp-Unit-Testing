namespace Academy.Tests.Models.Abstractions.UserTests
{
    using Fakes;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class UserNameTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("      ")]
        [TestCase("\r\n")]
        public void UsernameSetter_ShouldThrowArgumentException_WhenPassedNullOrWhitespaceString(string val)
        {
            // Arrange
            string validUserName = "Pesho Goshov";
            var fakeUser = new UserFake(validUserName);
            // Act and Assert
            Assert.Throws<ArgumentException>(() => fakeUser.Username = val);
        }

        [TestCase(2)]
        [TestCase(17)]
        public void UsernameSetter_ShouldThrowArgumentException_WhenPassedStringWithInvalidLength(int invalidLength)
        {
            // Arrange
            string validUserName = "Pesho Goshov";
            var fakeUser = new UserFake(validUserName);

            string usernameWithInvalidLength = new string('c', invalidLength);
            // Act and Assert
            Assert.Throws<ArgumentException>(
                () => fakeUser.Username = usernameWithInvalidLength);
        }

        [Test]
        public void UsernameSetter_ShouldNotThrow_WhenPassedValidString()
        {
            // Arrange
            string validUserName = "Pesho Goshov";
            var fakeUser = new UserFake(validUserName);

            string newValidUserName = "Gosho Peshov";
            // Act and Assert
            Assert.DoesNotThrow(
                () => fakeUser.Username = newValidUserName);
        }

        [Test]
        public void UsernameSetter_ShouldAssignCorrectly_WhenPassedValidString()
        {
            // Arrange
            string validUserName = "Pesho Goshov";
            var fakeUser = new UserFake(validUserName);

            string newValidUserName = "Gosho Peshov";
            // Act
            fakeUser.Username = newValidUserName;
            // Assert
            Assert.AreSame(newValidUserName, fakeUser.Username);
        }
    }
}