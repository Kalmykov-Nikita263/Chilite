using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Chilite.Domain.Entities;

public class Answer
{
    [Required]
    public Guid AnswerId { get; set; }

    [Required]
    [Display(Name = "Текст ответа")]
    public string Text { get; set; }

    //Навигационные свойства EntityFramework
    [ForeignKey("QuestionId")]
    public Guid QuestionId { get; set; }

    public Question Question { get; set; }
}