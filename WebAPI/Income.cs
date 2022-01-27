using System;
using System.Collections.Generic;

namespace WebAPI
{
    public partial class Income
    {
        public int Id { get; set; }
        public int? UserPasswordsId { get; set; }
        public int? IncomeOptionsId { get; set; }
        public decimal? IncomeAmount { get; set; }
        public int? PaySchedule { get; set; }

        public virtual IncomeOption? IncomeOptions { get; set; }
        public virtual UserPassword? UserPasswords { get; set; }
    }
}
