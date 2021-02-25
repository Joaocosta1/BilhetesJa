using System.Collections.Generic;
using System.Security.Cryptography;

namespace Domain.Entity
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EventId { get; set; }

        public virtual Event Event { get; set; }

        public virtual ICollection<WarehouseProduct> Stock { get; set; }
    }
}