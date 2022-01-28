using System;
using System.Collections.Generic;

namespace WebAPI
{
    public partial class ExpenseOption
    {
        public ExpenseOption()
        {
            Expenses = new HashSet<Expense>();
        }

        public int Id { get; set; }
        public string? ExpenseName { get; set; }
        public int? PriorityId { get; set; }

        public virtual Priority? Priority { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
