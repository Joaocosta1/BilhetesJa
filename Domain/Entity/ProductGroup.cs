using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class ProductGroup : Auditable
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Name { get; set; }
        
        public virtual Event Event { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
