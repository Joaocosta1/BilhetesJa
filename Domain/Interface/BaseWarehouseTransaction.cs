using System;
using Domain.Entity;

namespace Domain.Interface
{
    public abstract class BaseWarehouseTransaction : Auditable
    {
        public int EventId { get; set; }
        public DateTime? ProcessingDate { get; set; }
        public string ProcessingUserId { get; set; }
        public DateTime? CancellationDate{ get; set; }
        public string CancellationUserId { get; set; }

        public virtual ApplicationUser ProcessingUser { get; set; }
        public virtual ApplicationUser CancellationUser { get; set; }
        public virtual Event Event { get; set; }
    }
}