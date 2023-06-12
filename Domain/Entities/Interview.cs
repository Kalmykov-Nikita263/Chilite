using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chilite.Domain.Entities;

public class Interview
{
    [Required]
    public Guid InterviewId { get; set; }

    [Required(ErrorMessage = "Заполните название интервью")]
    [Display(Name = "Название интервью")]
    public string Title { get; set; }

    [Display(Name = "Дата начала интервью")]
    public DateTime StartDate { get; set; }

    [Display(Name = "Дата окончания интервью")]
    public DateTime EndDate { get; set; }

    //Навигационное свойство для EntityFramework
    public virtual List<Question> Questions { get; set; }

    public string UserId { get; set; }

    [ForeignKey("UserId")]
    public virtual ApplicationUser User { get; set; }

    public string RoomId { get; set; }

    [ForeignKey("RoomId")]
    public virtual Room Room { get; set; }
}