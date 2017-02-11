namespace Academy.Tests.Fakes
{
    using Academy.Models.Abstractions;

    internal class UserFake : User
    {
        public UserFake(string username) : base(username)
        {
        }
    }
}
