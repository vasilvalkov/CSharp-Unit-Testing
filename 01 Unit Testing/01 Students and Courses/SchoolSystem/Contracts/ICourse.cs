using System.Collections.Generic;

namespace SchoolSystem
{
    public interface ICourse
    {
        string Name { get; }

        ISet<IStudent> Students { get; set; }

        void AddStudent(IStudent student);

        void RemoveStudent(IStudent student);
    }
}