using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Domain.Entity
{
    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}