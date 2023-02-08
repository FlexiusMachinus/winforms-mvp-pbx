using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_CourseWork
{
    public class PayphoneCard
    {
        public PayphoneCard(string number, int timeBalance, DateTime releaseDate) : this()
        {
            Number = number;
            TimeBalance = timeBalance;
            ReleaseDate = releaseDate;
        }

        private PayphoneCard()
        {
            Calls = new List<Call>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(6)]
        [DisplayName("Номер")]
        [Index(IsUnique = true)]
        [RegularExpression(@"^[\d]{6}$")]
        public string Number { get; set; }

        [DisplayName("Остаток минут")]
        public int TimeBalance { get; set; }

        [DisplayName("Дата выпуска")]
        public DateTime? ReleaseDate { get; set; }

        [NotMapped]
        public virtual ICollection<Call> Calls { get; set; }
    }
}
