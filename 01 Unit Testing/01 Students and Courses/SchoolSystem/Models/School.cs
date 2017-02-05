namespace SchoolSystem
{
    using Common;
    using System;
    using System.Collections.Generic;

    public class School : ISchool
    {
        private readonly string name;
        private List<ICourse> courses;

        public School(string name)
        {
            Validator.CheckIfNullOrWhiteSpace(name, "The school should have a name!");

            this.name = name;
            this.courses = new List<ICourse>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public ICollection<ICourse> Courses
        {
            get
            {
                return new List<ICourse>(this.courses);
            }
            protected set
            {
                this.courses = value as List<ICourse>;
            }
        }

        public void AddCourses(params ICourse[] courses)
        {
            foreach (var course in courses)
            {
                Validator.CheckIfNull(course, "Parameter should not be null!");
            }

            this.courses.AddRange(courses);
        }

        public void RemoveCourse(ICourse course)
        {
            Validator.CheckIfNull(course, "Parameter should not be null!");

            if (!this.Courses.Contains(course))
            {
                throw new InvalidOperationException($"There is no \"{course.Name}\" course in this school!");
            }

            this.courses.Remove(course);
        }
    }
}
