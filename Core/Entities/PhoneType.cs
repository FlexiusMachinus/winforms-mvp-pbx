using System;

namespace DB_CourseWork.Core
{
    public class PhoneType
    {
        public PhoneType(string name)
        {
            Name = name;
        }

        protected PhoneType()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
