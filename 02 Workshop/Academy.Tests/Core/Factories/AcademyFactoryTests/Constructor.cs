namespace Academy.Tests.Core.Factories.AcademyFactoryTests
{
    using Academy.Core.Factories;
    using NUnit.Framework;

    [TestFixture]
    public class Constructor
    {
        [Test]
        public void Ctor_ShouldCreateNewFactoryInstance_WhenPropertyInstanceCalled()
        {
            // Arrange and Act
            var factory = AcademyFactory.Instance;
            // Assert
            Assert.IsInstanceOf(typeof(AcademyFactory), factory);
        }
    }
}
