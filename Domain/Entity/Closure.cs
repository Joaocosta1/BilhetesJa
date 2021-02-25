using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Closure
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<ClosurePaymentType> ClosurePaymentTypes { get; set; }
    }
}