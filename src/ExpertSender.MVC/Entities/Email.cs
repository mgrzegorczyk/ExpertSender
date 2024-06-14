using ExpertSender.MVC.Models;

namespace ExpertSender.MVC.Entities;

public class Email
{
    public int Id { get; set; }
    public string EmailAddress { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
}