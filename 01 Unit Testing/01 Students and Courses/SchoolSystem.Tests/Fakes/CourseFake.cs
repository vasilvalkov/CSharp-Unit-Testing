namespace SchoolSystem.Tests.Fakes
{
    using SchoolSystem;

    internal sealed class CourseFake : Course
    {
        internal CourseFake(string name, byte maxStudents) : base(name, maxStudents)
        {
        }
        internal byte MaxStudents
        {
            get
            {
                return base.MaxStudentsInCourse;
            }
        }
    }
}
