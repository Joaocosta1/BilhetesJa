using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain.Interface;

namespace Domain.Entity
{
    public class Product : Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EventId { get; set; }
        public double SalePrice { get; set; }
        public double? PurchasePrice { get; set; }
        public int? GroupId { get; set; }

        public virtual Event Event { get; set; }
        
        public bool HaveComposition => Composition != null && Composition.Any();

        public virtual ICollection<ProductComposition> Composition { get; set; }
        public virtual ICollection<ProductComposition> Compositor { get; set; }
        
        public virtual ICollection<WarehouseProduct> WarehouseAvailability { get; set; }

        public virtual ProductGroup Group { get; set; }

        public override string ToString() => $"{Id}/{EventId} - {Name}";
    }
}