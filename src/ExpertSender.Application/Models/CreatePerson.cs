using System.ComponentModel.DataAnnotations;

namespace ExpertSender.Application.Models;

public class CreatePerson
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Description { get; set; }
    [EmailAddress]
    public string EmailAddress { get; set; }
}