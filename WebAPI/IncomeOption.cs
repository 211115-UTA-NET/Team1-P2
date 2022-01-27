using System;
using System.Collections.Generic;

namespace WebAPI
{
    public partial class IncomeOption
    {
        public IncomeOption()
        {
            Incomes = new HashSet<Income>();
        }

        public int Id { get; set; }
        public string? IncomeName { get; set; }
        public int? PriorityId { get; set; }

        public virtual Priority? Priority { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }
    }
}
