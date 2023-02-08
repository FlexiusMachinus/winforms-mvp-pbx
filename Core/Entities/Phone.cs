using System;
using System.ComponentModel.DataAnnotations;

namespace DB_CourseWork.Core
{
    public abstract class Phone
    {
        protected Phone(string number)
        {
            Number = number;
        }

        public int Id { get; set; }

        [RegularExpression(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$")]
        public string Number { get; set; }
    }
}
