using System;
using System.Collections.Generic;

namespace WebAPI
{
    public partial class Expense
    {
        public int Id { get; set; }
        public int? UserPasswordsId { get; set; }
        public int? ExpenseOptionsId { get; set; }
        public decimal? ExpenseAmount { get; set; }
        public int? EspenseFrequency { get; set; }
        public DateTime? ExpenseEnding { get; set; }
        public int? SeverityOfNeed { get; set; }

        public virtual ExpenseOption? ExpenseOptions { get; set; }
        public virtual UserPassword? UserPasswords { get; set; }
    }
}
