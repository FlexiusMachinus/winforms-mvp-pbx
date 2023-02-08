using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_CourseWork
{
    public class PhoneStatus
    {
        public PhoneStatus(string name)
        {
            Name = name;
        }

        private PhoneStatus()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Название")]
        [MaxLength(32)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}
