using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DB_CourseWork
{
    public class Payphone : Phone
    {
        public Payphone(string number, string address) : base(number)
        {
            Address = address;
        }

        private Payphone() : base(default)
        {
        }

        [DisplayName("Адрес")]
        [Required(AllowEmptyStrings = false)]
        public string Address { get; set; }

        [DisplayName("Статус")]
        public bool IsEnabled { get; set; }
    }
}
