using System.ComponentModel.DataAnnotations;

namespace ExpertSender.Application.Models;

public class EmailDetails
{
    public int Id { get; set; }
    [EmailAddress]
    public string EmailAddress { get; set; }
    public int PersonId { get; set; }
}