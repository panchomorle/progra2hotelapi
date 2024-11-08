using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public required string Role { get; set; }                 // Rol del usuario (Admin o Customer)
}
