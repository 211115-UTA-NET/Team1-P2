using System;
using System.Collections.Generic;

namespace WebAPI
{
    public partial class Priority
    {
        public Priority()
        {
            ExpenseOptions = new HashSet<ExpenseOption>();
            IncomeOptions = new HashSet<IncomeOption>();
        }

        public int Id { get; set; }
        public string PriorityName { get; set; } = null!;

        public virtual ICollection<ExpenseOption> ExpenseOptions { get; set; }
        public virtual ICollection<IncomeOption> IncomeOptions { get; set; }
    }
}
