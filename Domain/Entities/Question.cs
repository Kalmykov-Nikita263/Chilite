using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Chilite.Domain.Entities;

public class Question
{
    [Required]
    public Guid QuestionId { get; set; }

    [Required]
    [Display(Name = "Текст вопроса")]
    public string Text { get; set; }

    public Guid InterviewId { get; set; }

    //Навигационные свойства для EntityFramework
    [ForeignKey("InterviewId")]
    public Interview Interview { get; set; }

    public List<Answer> Answers { get; set; }
}
