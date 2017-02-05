namespace SchoolSystem.Tests.Providers
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem.Providers;

    [TestClass]
    public class IdProvider_Should
    {
        [TestMethod]
        public void ThrowArgumentException_WhenMaximumIDReached()
        {   // Arrange
            uint startId = 1;
            uint endId = 2;
            var provider = new IdProvider(startId, endId);
            uint firstAvailabeId = provider.GenerateID();
            uint secondAvailableId = provider.GenerateID();
            // No available IDs should left
            // Act and Assert
            Assert.ThrowsException<InvalidOperationException>(() => provider.GenerateID());
        }

        [TestMethod]
        public void IncrementIDsByOne_WhenInvoked()
        {   // Arrange
            uint expected = 1U;
            uint startId = 2;
            uint endId = 10;
            var provider = new IdProvider(startId, endId);
            // Act
            uint firstId = provider.GenerateID();
            uint nextId = provider.GenerateID();
            // Assert
            Assert.AreEqual(expected, nextId - firstId);
        }
    }
}