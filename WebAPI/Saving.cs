using System;
using System.Collections.Generic;

namespace WebAPI
{
    public partial class Saving
    {
        public int Id { get; set; }
        public int? UserPasswordsId { get; set; }
        public string SavingsName { get; set; } = null!;
        public decimal? SavingsAmount { get; set; }
        public double? SavingsInterest { get; set; }
        public decimal? SavingsAddedMonthly { get; set; }

        public virtual UserPassword? UserPasswords { get; set; }
    }
}
