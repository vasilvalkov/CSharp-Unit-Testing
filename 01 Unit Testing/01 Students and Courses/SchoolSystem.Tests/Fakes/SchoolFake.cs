namespace SchoolSystem.Tests.Fakes
{
    using SchoolSystem;
    using System.Collections.Generic;

    internal sealed class SchoolFake : School
    {
        public SchoolFake(string name) : base(name)
        {
        }
        public ICollection<ICourse> ExposedCourses
        {
            set
            {
                base.Courses = value;
            }
        }
    }
}
