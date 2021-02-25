using System.Collections.Generic;
using Domain.Enum;
using Domain.Interface;

namespace Domain.Entity
{
    public class Sale : BaseWarehouseTransaction
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int? ClosureId { get; set; }
        public double Total { get; set; }
        public double? TotalPayedTax { get; set; }
        public double? Profit { get; set; }
        public SaleState State { get; set; }

        public virtual Closure Closure { get; set; }
        
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual ICollection<SaleItem> Items { get; set; }
    }
}