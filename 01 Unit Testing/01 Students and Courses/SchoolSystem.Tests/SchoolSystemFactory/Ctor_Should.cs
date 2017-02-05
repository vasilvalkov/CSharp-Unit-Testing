namespace SchoolSystem.Tests.SchoolSystemFactory
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using SchoolSystem;

    [TestClass]
    public class Ctor_Should
    {
        [TestMethod]
        public void ThrowNullReferenceException_WhenPassednullIdProvider()
        {   // Arrange, Act and Assert
            Assert.ThrowsException<NullReferenceException>(() => new SchoolSystemFactory(null));
        }
    }
}
