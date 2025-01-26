using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Domain.Entity.Identity;

[Table("AppUsers")]
public class AppUsers : IdentityUser<Guid>
{
    [MaxLength(50)]
    public string? FirstName { get; set; } = default!;

    [MaxLength(50)]
    public string? LastName { get; set; } = default!;

    public DateOnly? Dob { get; set; }

    public string? AccessToken { get; set; }

    public string? RefreshToken { get; set; }
}
