namespace SchoolSystem
{
    using System.Collections.Generic;

    public interface ISchool
    {
        string Name { get; }

        ICollection<ICourse> Courses { get; }

        void AddCourses(params ICourse[] courses);

        void RemoveCourse(ICourse course);
    }
}