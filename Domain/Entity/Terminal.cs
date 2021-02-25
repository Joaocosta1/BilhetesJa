using System;

namespace Domain.Entity
{
    public class Terminal
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}