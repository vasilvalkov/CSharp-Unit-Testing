﻿using Academy.Commands.Adding;
using Academy.Core.Contracts;

namespace Academy.Tests.Fakes
{
    internal class AddStudentToCourseCommandFake : AddStudentToCourseCommand
    {
        public AddStudentToCourseCommandFake(IAcademyFactory factory, IEngine engine) : base(factory, engine)
        {

        }

        internal IAcademyFactory Factory
        {
            get
            {
                return this.factory;
            }
        }

        internal IEngine Engine
        {
            get
            {
                return this.engine;
            }
        }
    }
}
