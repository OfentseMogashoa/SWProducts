using Microsoft.AspNetCore.Identity;

namespace SWProducts.Models
{
    public class SuperUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
    }
}
