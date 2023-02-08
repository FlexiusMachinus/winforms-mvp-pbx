using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_CourseWork.Core
{
    public class PayphoneCard
    {
        public PayphoneCard(string number, int timeBalance, DateTime releaseDate) : this()
        {
            Number = number;
            TimeBalance = timeBalance;
            ReleaseDate = releaseDate;
        }

        protected PayphoneCard()
        {
            Calls = new List<Call>();
        }

        public int Id { get; set; }

        [RegularExpression(@"^[\d]{6}$")]
        public string Number { get; set; }

        public int TimeBalance { get; set; }

        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<Call> Calls { get; set; }
    }
}
