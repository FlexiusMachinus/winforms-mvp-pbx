using System;

namespace DB_CourseWork.Core
{
    public class Payphone : Phone
    {
        public Payphone(string number, string address) : base(number)
        {
            Address = address;
        }

        protected Payphone() : base(default)
        {
        }

        public string Address { get; set; }
        public bool IsEnabled { get; set; }
    }
}
