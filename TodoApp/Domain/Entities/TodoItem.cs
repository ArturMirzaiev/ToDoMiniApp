using System.ComponentModel.DataAnnotations;

namespace TodoApp.Domain.Entities;

public class TodoItem
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле обовʼязкове")]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;
    public bool IsDone { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? CompletedAt { get; set; }  
}