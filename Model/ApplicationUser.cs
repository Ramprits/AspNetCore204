using Microsoft.AspNetCore.Identity;

namespace AspNetCoreApplication.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        
    }
}