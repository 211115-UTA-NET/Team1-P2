using System;
using System.Collections.Generic;

namespace WebAPI
{
    public partial class UserPassword
    {
        public UserPassword()
        {
            Expenses = new HashSet<Expense>();
            Incomes = new HashSet<Income>();
            Loans = new HashSet<Loan>();
            Savings = new HashSet<Saving>();
        }

        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? UserPassword1 { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual UserInfo UserInfo { get; set; } = null!;
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<Saving> Savings { get; set; }
    }
}
