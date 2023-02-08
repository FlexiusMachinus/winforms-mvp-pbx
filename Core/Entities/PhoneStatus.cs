using System;

namespace DB_CourseWork.Core
{
    public class PhoneStatus
    {
        public PhoneStatus(string name)
        {
            Name = name;
        }

        protected PhoneStatus()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
