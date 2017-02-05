namespace SchoolSystem
{
    using System.Collections.Generic;

    public interface IStudent
    {
        string Name { get; }

        uint ID { get; }

        ICollection<ICourse> Courses { get; }

        void JoinCourse(ICourse course);

        void LeaveCourse(ICourse course);
    }
}