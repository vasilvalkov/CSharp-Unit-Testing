namespace SchoolSystem
{
    using Common;
    using System;
    using System.Collections.Generic;

    public class Student : IStudent
    {
        private readonly uint id;
        private string name;
        private ICollection<ICourse> courses;

        public Student(string name, uint id)
        {
            this.Name = name;
            this.id = id;
            this.courses = new List<ICourse>();
        }

        public uint ID
        {
            get
            {
                return this.id;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.CheckIfNullOrWhiteSpace(value, "The student must have a name");

                this.name = value;
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
                this.courses = value;
            }
        }

        public void JoinCourse(ICourse course)
        {
            Validator.CheckIfNull(course, "Parameter should not be null!");

            course.AddStudent(this);
            this.courses.Add(course);
        }

        public void LeaveCourse(ICourse course)
        {
            Validator.CheckIfNull(course, "Parameter should not be null!");

            course.RemoveStudent(this);
            this.courses.Remove(course);
        }
    }
}
