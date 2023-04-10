
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedeSocial.Domain.Entities;

public class ProfileEntity : IdentityUser
{
    [PersonalData]
    public string? FirstName { get; set; }
    [PersonalData]
    public string? LastName { get; set; }
    [PersonalData]
    public DateTime? BirthOfDay { get; set; }

    [PersonalData]
    public string? ProfileUrlImage { get; set; }

    [NotMapped]
    public IFormFile? ImageFile { get; set; }
}
