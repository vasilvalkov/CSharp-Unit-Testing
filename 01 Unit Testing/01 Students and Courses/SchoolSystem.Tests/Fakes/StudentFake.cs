namespace SchoolSystem.Tests.Fakes
{
    using SchoolSystem;
    using System.Collections.Generic;

    public sealed class StudentFake : Student
    {
        public StudentFake(string name, uint id) : base(name, id)
        {
        }

        internal ICollection<ICourse> ExposedCourses
        {
            set
            {
                base.Courses = value;
            }
        }

    }
}