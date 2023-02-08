using System;

namespace DB_CourseWork.Core
{
    public class SaveDataException : Exception
    {
        public SaveDataException() : base()
        {
        }

        public SaveDataException(string message) : base(message)
        {
        }
    }
}
