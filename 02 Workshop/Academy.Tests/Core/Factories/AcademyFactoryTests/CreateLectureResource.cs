namespace Academy.Tests.Core.Factories.AcademyFactoryTests
{
    using Academy.Core.Factories;
    using Academy.Models.Utils.LectureResources;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CreateLectureResource
    {
        [TestCase("Video")]
        [TestCase("Audio")]
        public void CreateLectureResource_ShouldThrowArgumentException_WhenPassedInvalidResourceType(string invalidType)
        {
            // Arrange
            var factory = AcademyFactory.Instance;
            string validResourceName = "Unit Testing";
            string validResourceUrl = "http://somewhere.com";
            // Act and Assert
            Assert.Throws<ArgumentException>(
                () => factory.CreateLectureResource(invalidType, validResourceName, validResourceUrl));
        }

        [TestCase("video", typeof(VideoResource))]
        [TestCase("presentation", typeof(PresentationResource))]
        [TestCase("demo", typeof(DemoResource))]
        [TestCase("homework", typeof(HomeworkResource))]
        public void CreateLectureResource_ShouldReturnCorrectInstances_WhenPassedValidResourceType 
            (string validType, Type expectedType)
        {
            // Arrange
            var factory = AcademyFactory.Instance;
            string validResourceName = "Unit Testing";
            string validResourceUrl = "http://somewhere.com";
            // Act 
            var createdResource = factory.CreateLectureResource(validType, validResourceName, validResourceUrl);
            // Assert
            Assert.IsTrue(expectedType.Equals(createdResource.GetType()));
        }

        [TestCase("video")]
        [TestCase("presentation")]
        [TestCase("demo")]
        [TestCase("homework")]
        public void CreateLectureResource_ShouldReturnResourceWithCorrectlyAssignedData_WhenPassedValidResourceType
            (string validResourseType)
        {
            // Arrange
            var factory = AcademyFactory.Instance;
            string validResourceName = "Unit Testing";
            string validResourceUrl = "http://somewhere.com";
            // Act 
            var createdResource = factory.CreateLectureResource(validResourseType, validResourceName, validResourceUrl);
            // Assert
            Assert.AreSame(validResourceName, createdResource.Name);
            Assert.AreSame(validResourceUrl, createdResource.Url);
        }
    }
}
