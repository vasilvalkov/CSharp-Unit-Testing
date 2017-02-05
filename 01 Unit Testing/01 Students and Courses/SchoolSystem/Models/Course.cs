namespace SchoolSystem
{
    using Common;
    using System;
    using System.Collections.Generic;

    public class Course : ICourse
    {
        private readonly byte maxStudentsInCourse;
        private ISet<IStudent> students;
        private string courseName;

        public Course(string name, byte maxStudents)
        {
            this.Name = name;
            this.maxStudentsInCourse = maxStudents;
            this.students = new HashSet<IStudent>();
        }

        protected byte MaxStudentsInCourse
        {
            get
            {
                return this.maxStudentsInCourse;
            }
        }

        public string Name
        {
            get
            {
                return this.courseName;
            }
            private set
            {
                Validator.CheckIfNullOrWhiteSpace(value, "The course should have a name!");
                
                this.courseName = value;
            }
        }

        public ISet<IStudent> Students
        {
            get
            {
                return new HashSet<IStudent>(students);
            }
            set
            {
                foreach (var student in value)
                {
                    Validator.CheckIfNull(student, "Cannot handle null student!"); 
                }

                if (value.Count > this.maxStudentsInCourse)
                {
                    throw new InvalidOperationException($"Course should have no more than {this.maxStudentsInCourse} students!");
                }

                this.students = value;
            }
        }

        public void AddStudent(IStudent student)
        {
            Validator.CheckIfNull(student, "Cannot add null student!");

            if (this.Students.Count == maxStudentsInCourse)
            {
                throw new InvalidOperationException("Maximum number of students in this course reached!");
            }

            this.students.Add(student);
        }

        public void RemoveStudent(IStudent student)
        {
            Validator.CheckIfNull(student, "Cannot remove null student!");

            if (this.Students.Count == 0 || !this.Students.Contains(student))
            {
                throw new ArgumentException("The student is not subscribed to this course!");
            }

            this.students.Remove(student);
        }
    }
}
