using System;

namespace SchoolSystem.Common
{
    public static class Validator
    {
        public static void CheckIfNull(object obj, string message)
        {
            if (obj == null)
            {
                throw new NullReferenceException(message);
            }
        }

        public static void CheckIfNullOrWhiteSpace(string str, string message)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException(message);
            }
        }
    }
}
