using Domain.Interface;

namespace Domain.Entity
{
    public class PointOfSale : Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EventId { get; set; }
        public string ApplicationUserId { get; set; }
        public int? TerminalId { get; set; }       
        public virtual Event Event { get; set; }
        public virtual Terminal Terminal { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}