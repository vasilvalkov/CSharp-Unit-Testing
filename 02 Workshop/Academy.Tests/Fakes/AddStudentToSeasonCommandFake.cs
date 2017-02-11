using Academy.Commands.Adding;
using Academy.Core.Contracts;

namespace Academy.Tests.Fakes
{
    internal class AddStudentToSeasonCommandFake : AddStudentToSeasonCommand
    {
        public AddStudentToSeasonCommandFake(IAcademyFactory factory, IEngine engine) : base(factory, engine)
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
