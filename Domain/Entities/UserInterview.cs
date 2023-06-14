using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chilite.Domain.Entities;

public class UserInterview
{
    [Key]
    public Guid UserInterviewId { get; set; }

    [ForeignKey("UserId")]
    public string UserId { get; set; }

    public virtual ApplicationUser User { get; set; }

    [ForeignKey("InterviewId")]
    public Guid InterviewId { get; set; }

    public virtual Interview Interview { get; set; }

    public UserInterview()
    {
        UserInterviewId = Guid.NewGuid();
    }
}