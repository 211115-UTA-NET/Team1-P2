using System;
using System.Collections.Generic;

namespace WebAPI
{
    public partial class Loan
    {
        public int Id { get; set; }
        public int? UserPasswordsId { get; set; }
        public string LoanName { get; set; } = null!;
        public decimal? LoanAmount { get; set; }
        public double? LoanInterest { get; set; }
        public decimal? MonthlyPayments { get; set; }

        public virtual UserPassword? UserPasswords { get; set; }
    }
}
