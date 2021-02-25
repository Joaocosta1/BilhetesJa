using System;
using System.Collections.Generic;
using Domain.Interface;

namespace Domain.Entity
{
    public class Event : Auditable
    {
        public int Id { get; set; }
        public int? ProducerId { get; set; }
        public string Name { get; set; }

        public virtual Producer Producer { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<PointOfSale> PointsOfSale { get; set; }
        public virtual ICollection<PaymentType> PaymentTypes { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
        public virtual ICollection<Transfer> Transfers { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }

        public override string ToString() => $"{Id} - {Name}";
    }
}