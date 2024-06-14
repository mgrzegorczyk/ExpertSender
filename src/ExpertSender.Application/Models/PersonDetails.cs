using System.ComponentModel.DataAnnotations;

namespace ExpertSender.Application.Models;

public class PersonDetails
{
    public int Id { get; set; }
    [Required]
    [MinLength(3, ErrorMessage = "First Name must be at least 3 characters long.")]
    public string FirstName { get; set; }
    [Required]
    [MinLength(3, ErrorMessage = "Last Name must be at least 3 characters long.")]
    public string LastName { get; set; }
    public string Description { get; set; }
    public List<EmailDetails> Emails { get; set; } = new List<EmailDetails>();
}