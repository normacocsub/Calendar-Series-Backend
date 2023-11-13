using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class ApplicationRole : IdentityRole
{
    public string Description { get; set; }

    
    public ApplicationRole() : base()
    {
    }

    public ApplicationRole(string roleName) : base(roleName)
    {
    }
}