using Microsoft.AspNetCore.Identity;

namespace Domain.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public override string ToString() => $"{FirstName} {LastName}";
    }
}