namespace SchoolSystem
{
    public interface ISchoolSystemFactory
    {
        IStudent CreateStudent(string name);
        ICourse CreateCourse(string name, byte maxStudents);
        ISchool CreateSchool(string name);
    }
}