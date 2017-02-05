namespace SchoolSystem
{
    using Common;
    using SchoolSystem.Providers;

    public class SchoolSystemFactory : ISchoolSystemFactory
    {
        private IIdProvider idProvider;

        public SchoolSystemFactory(IIdProvider provider)
        {
            Validator.CheckIfNull(provider, "Parameter cannot be null!");

            this.idProvider = provider;
        }

        public IStudent CreateStudent(string name)
        {
            Validator.CheckIfNullOrWhiteSpace(name, "Parameter cannot be null, empty or whitespace!");

            uint id = idProvider.GenerateID();
            return new Student(name, id);
        }

        public ICourse CreateCourse(string name, byte maxStudents)
        {
            Validator.CheckIfNullOrWhiteSpace(name, "Parameter cannot be null, empty or whitespace!");

            return new Course(name, maxStudents);
        }

        public ISchool CreateSchool(string name)
        {
            Validator.CheckIfNullOrWhiteSpace(name, "Parameter cannot be null, empty or whitespace!");

            return new School(name);
        }
    }
}