using Microsoft.AspNetCore.Identity;

namespace Chilite.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public virtual List<Interview> Interviews { get; set; }
    public virtual List<UserInterview> UserInterviews { get; set; }
}
