using System.ComponentModel.DataAnnotations;

namespace Orderops.api.Models;

public class AddNoteRequest
{
    [Required]
    public string Author { get; set; } = string.Empty;

    [Required]
    [MaxLength(500)]
    public string Message { get; set; } = string.Empty;
}