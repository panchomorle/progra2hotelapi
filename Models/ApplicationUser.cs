using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string Role { get; set; }                 // Rol del usuario (Admin o Customer)
}
